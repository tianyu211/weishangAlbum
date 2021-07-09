using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class MainForm : Form
    {

        /// <summary>
        /// Browser组件
        /// </summary>
        public BrowserForm browserForm;

        /// <summary>
        /// 窗体关闭时候统一关闭线程
        /// </summary>
        private CancellationTokenSource TaskSource = new CancellationTokenSource();

        /// <summary>
        /// 关注列表数据
        /// </summary>
        private DataTable DTFollow;

        public MainForm()
        {
            InitializeComponent();
            browserForm = new BrowserForm();
            
            //  绑定关注列表数据源
            DTFollow = new DataTable();
            BindDgvFollow(DTFollow);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string res = HttpHelper.SendDataByGET("https://www.szwego.com/service/mp/pc_login_operation.jsp?act=get_param&_=" + DateTime.Now.ToString("yyyyMMdd"));
            if (res == null)
            {
                ErrorMsg("你的网络可能不太好，请换个环境再试试吧。");
                return;
            }
            var result = (JObject)JsonConvert.DeserializeObject(res);
            var operationBody = result["result"];
            string url = string.Format(@"https://open.weixin.qq.com/connect/qrconnect?appid={0}&redirect_uri={1}&state={2}&scope=snsapi_login&login_type=jssdk&self_redirect=default&styletype=&sizetype=&bgcolor=&rst=&style=white",
                operationBody["appid"].ToString(), operationBody["redirect_uri"].ToString(), operationBody["state"].ToString());
            Console.WriteLine(url);
            ShowHideBrowser(true);
            browserForm.chromeBrowser.Load(url);
            //  启动线程
            Task.Run(() => Logined(url), TaskSource.Token);
        }


        /// <summary>
        /// 登陆后的方法
        /// </summary>
        /// <param name="url"></param>
        private void Logined(string url)
        {
            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("等待扫码");
            } while (browserForm.chromeBrowser.Address.Equals(url));

            while (browserForm.chromeBrowser.IsLoading)
            {
                Thread.Sleep(500);
                Console.WriteLine("等待页面加载完成");
            }
            Console.WriteLine("扫码完成");
            Console.WriteLine("当前Cookie：" + browserForm.cookies);
            //
            ShowHideBrowser(false);
            //  登陆完成后信息处理   
            Task.Run(() => GetUserInfo(),TaskSource.Token);
            Task.Run(() => GetAlbum(), TaskSource.Token);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        private void GetUserInfo()
        {
            string InfoUrl = "https://www.szwego.com/service/account/get_user_system_status.jsp?&_=" + get_milliseconds().ToString();
            string res = HttpHelper.SendDataByGET(InfoUrl, "", browserForm.cookieContainer);
            if (res == null)
            {
                ErrorMsg("网络异常");
                return;
            }
            var result = (JObject)JsonConvert.DeserializeObject(res);
            if (int.Parse(result["errcode"].ToString()) != 0)
            {
                ErrorMsg(result["errmsg"].ToString());
                return;
            }
            DisplayName(result["result"]["user"]["user_name"].ToString());
            DisplayAvatar(result["result"]["user"]["user_icon"].ToString());
            DisplayBackground(result["result"]["user"]["user_baner_img"].ToString());
            DisplayShopID(result["result"]["user"]["shop_id"].ToString());
            DisplayShopName(result["result"]["user"]["shop_name"].ToString());
        }

        /// <summary>
        /// 获取关注的人
        /// </summary>
        private void GetAlbum()
        { 
            int page = 1;
            int residue = 1;        
            do
            {
                string url = "https://www.szwego.com/service/album/get_album_list.jsp?act=attention&search_value=&page_index=" + page.ToString() + "&tag_id=&_=" + get_milliseconds().ToString();
                Console.WriteLine("获取关注列表："+url);
                string res = HttpHelper.SendDataByGET(url,"", browserForm.cookieContainer);
                if (res != null)
                {
                    var result = (JObject)JsonConvert.DeserializeObject(res);
                    if(int.Parse(result["errcode"].ToString()) == 0)
                    {
                        residue = int.Parse(result["total_page"].ToString()) - page;
                        DataRow newRow;
                        foreach (var shop_info in result["result"]["shop_list"])
                        {
                            if (bool.Parse(shop_info["is_my_album"].ToString()))
                            {
                                continue;
                            }
                              //  绑定数据
                            newRow = DTFollow.NewRow();
                            //foreach (DataColumn col in DTFollow.Columns) 
                            //{
                            //    dr[col.ToString()] = shop_info[col.ToString()].ToString();
                            //    Console.WriteLine(col.ToString() + "------" + shop_info[col.ToString()].ToString());
                            //}
                            newRow["店铺ID"] = shop_info["shop_id"].ToString();
                            newRow["店铺名称"] = shop_info["shop_name"].ToString();
                            newRow["是否VIP"] = shop_info["is_vip"].ToString();
                            newRow["总商品数"] = shop_info["total_goods"].ToString();
                            newRow["上新商品"] = shop_info["new_goods"].ToString();
                            Console.WriteLine(shop_info["new_goods"].ToString());

                            DTFollow.Rows.Add(newRow);
                        }
                    }
                    else
                    {
                        ErrorMsg(result["errmsg"].ToString());
                        return;
                    }
                }
                page++;
                Thread.Sleep(500);
            } while (residue > 0);
            BindDgvFollow(DTFollow);
            Console.WriteLine("获取关注列表完成，一共：" + DTFollow.Rows.Count + " 个 ");

            
        }

        private void GetPersonalList(string albumId)
        {

        }


        #region 控件代理
        private delegate void DisplayNameDelegate(string name);
        private void DisplayName(string name)
        {
            if (this.lbl_uname.InvokeRequired)
            {
                this.lbl_uname.Invoke(new DisplayNameDelegate(DisplayName), name);
            }
            else
            {
                lbl_uname.Text = name;
            }
        }

        private delegate void DisplayAvatarDelegate(string avatar);
        private void DisplayAvatar(string avatar)
        {
            if (this.pic_avatar.InvokeRequired)
            {
                this.pic_avatar.Invoke(new DisplayNameDelegate(DisplayAvatar), avatar);
            }
            else
            {
                pic_avatar.Image = Image.FromStream(System.Net.WebRequest.Create(@avatar).GetResponse().GetResponseStream());
            }
        }

        private delegate void DisplayBackgroundDelegate(string banner);
        private void DisplayBackground(string banner)
        {
            if (this.grb_user.InvokeRequired)
            {
                this.grb_user.Invoke(new DisplayBackgroundDelegate(DisplayBackground), banner);
            }
            else
            {
                grb_user.BackgroundImage = Image.FromStream(System.Net.WebRequest.Create(@banner).GetResponse().GetResponseStream());
            }
        }

        private delegate void DisplayShopIDDelegate(string shopid);
        private void DisplayShopID(string shopid)
        {
            if (this.lbl_shop_id.InvokeRequired)
            {
                this.lbl_shop_id.Invoke(new DisplayShopIDDelegate(DisplayShopID), shopid);
            }
            else
            {
                lbl_shop_id.Text = shopid;
            }
        }

        private delegate void DisplayShopNameDelegate(string shopid);
        private void DisplayShopName(string shopid)
        {
            if (this.lbl_shop_name.InvokeRequired)
            {
                this.lbl_shop_name.Invoke(new DisplayShopNameDelegate(DisplayShopName), shopid);
            }
            else
            {
                lbl_shop_name.Text = shopid;
            }
        }

        private delegate void ShowHideBrowserDelegate(bool Show);
        private void ShowHideBrowser(bool Show = false)
        {
            if (browserForm.InvokeRequired)
            {
                browserForm.Invoke(new ShowHideBrowserDelegate(ShowHideBrowser),Show);
            }
            else
            {
                if (browserForm.IsDisposed)
                {
                    browserForm = new BrowserForm();
                }
                if (Show)
                {
                    browserForm.Show();
                    browserForm.Visible = true;
                }
                else
                {
                    browserForm.Hide();
                    browserForm.Visible = false;
                }
            }
        }

        private delegate void BindDgvFollowDelegate(DataTable dt);

        private void BindDgvFollow(DataTable dt)
        {
            if (dgv_follows.InvokeRequired)
            {
                Console.WriteLine("BindDgvFollow");
                dgv_follows.Invoke(new BindDgvFollowDelegate(BindDgvFollow),dt);
            }
            else
            {
                if (!dt.Columns.Contains("店铺ID"))
                {
                    dt.Columns.Add("店铺ID", Type.GetType("System.String"));
                    dt.Columns.Add("店铺名称", Type.GetType("System.String"));
                    dt.Columns.Add("是否VIP", Type.GetType("System.String"));
                    dt.Columns.Add("总商品数", Type.GetType("System.String"));
                    dt.Columns.Add("上新商品", Type.GetType("System.String"));
                }
                dgv_follows.DataSource = null;
                dgv_follows.DataSource = dt;
                //dgv_follows.AutoGenerateColumns = true;
            }
        }
        #endregion

        #region 获取毫秒
        /// <summary>
        /// 获取毫秒
        /// </summary>
        /// <returns></returns>
        private long get_milliseconds()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            return (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒秒数
        }

        /// <summary>
        /// 获取指定日期毫秒数
        /// </summary>
        /// <param name="dateTime">new DateTime(2021, 6, 1, 0, 0, 0)</param>
        /// <returns></returns>
        private long get_milliseconds(DateTime dateTime)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            return (long)(dateTime - startTime).TotalMilliseconds; // 相差毫秒秒数
        }
        #endregion

        #region 窗体事件
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Console.WriteLine("主窗体关闭，关闭所有Task");
                browserForm.Close();
                TaskSource.Cancel();
                TaskSource.Dispose();
            }catch(Exception ex)
            {
                Console.WriteLine("关闭Task失败：" + ex.Message);
            }
        }

        private void ErrorMsg(string msg)
        {
            throw new Exception(msg);
            //MessageBox.Show(msg);
        }
        #endregion
    }
}
