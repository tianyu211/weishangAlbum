using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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


        public MainForm()
        {
            InitializeComponent();
            browserForm = new BrowserForm();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string res = HttpHelper.SendDataByGET("https://www.szwego.com/service/mp/pc_login_operation.jsp?act=get_param&_=" + DateTime.Now.ToString("yyyyMMdd"));
            if (res == null)
            {
                MessageBox.Show("你的网络可能不太好，请换个环境再试试吧。");
                return;
            }
            var result = (JObject)JsonConvert.DeserializeObject(res);
            var operationBody = result["result"];
            string url = string.Format(@"https://open.weixin.qq.com/connect/qrconnect?appid={0}&redirect_uri={1}&state={2}&scope=snsapi_login&login_type=jssdk&self_redirect=default&styletype=&sizetype=&bgcolor=&rst=&style=white",
                operationBody["appid"].ToString(), operationBody["redirect_uri"].ToString(), operationBody["state"].ToString());
            Console.WriteLine(url);
            browserForm.Show();
            browserForm.chromeBrowser.Load(url);
            //  启动线程
            Task.Run(() => Logined(url), TaskSource.Token);
        }


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
            
            Task.Run(() => GetUserInfo(),TaskSource.Token);
            Task.Run(() => GetAlbum(), TaskSource.Token);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        private void GetUserInfo()
        {
            //string InfoUrl = "https://www.szwego.com/service/account/get_user_system_status.jsp?&_=" + get_milliseconds().ToString();
            //string res = HttpHelper.SendDataByGET(InfoUrl,"",browserForm.cookieContainer);
        }

        /// <summary>
        /// 获取关注的人
        /// </summary>
        private void GetAlbum()
        { 

            int page = 1;
            int residue = 1;
            List<JToken> AllShopList = new List<JToken>();
            //browserForm.chromeBrowser.Hide();
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
                        foreach(var shop_info in result["result"]["shop_list"])
                        {
                            if (bool.Parse(shop_info["is_my_album"].ToString()))
                            {
                                continue;
                            }
                            AllShopList.Add(shop_info);
                            Console.WriteLine(shop_info["shop_id"].ToString() + " --- " +shop_info["shop_name"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show(result["errmsg"].ToString());
                        return;
                    }
                }
                page++;
                Thread.Sleep(500);
            } while (residue > 0);
            Console.WriteLine("获取关注列表完成，一共：" + AllShopList.Count + " 个 ");
        }

        private void GetPersonalList(string albumId)
        {

        }

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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                TaskSource.Cancel();
                TaskSource.Dispose();
            }catch(Exception ex)
            {
                Console.WriteLine("关闭Task失败：" + ex.Message);
            }
        }
    }
}
