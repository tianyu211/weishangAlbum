using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class ShopForm : Form
    {
        /// <summary>
        /// 当前用户店铺ID
        /// </summary>
        private string shop_id;
        /// <summary>
        /// 用户登录cookie
        /// </summary>
        private CookieContainer cookieContainer;

        private string next_url;
        /// <summary>
        /// 存储所有商品数据
        /// </summary>
        private List<JToken> ShopList;
        /// <summary>
        /// 窗体关闭时候统一关闭线程
        /// </summary>
        private CancellationTokenSource TaskSource = new CancellationTokenSource();

        private int CurrentPage = 1;

        public ShopForm(string _shop_id, CookieContainer _cookieContainer)
        {
            InitializeComponent();
            shop_id = _shop_id;
            cookieContainer = _cookieContainer;
            next_url = string.Format("https://www.szwego.com/album/personal/all?&albumId={0}&searchValue=&searchImg=&startDate=&endDate=&sourceId=&requestDataType=", shop_id);
            ShopList = new List<JToken>();
            Cbx_pageSize.SelectedItem = 10;
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("稍等片刻，数据加载完毕后会展示在这里...");
            Task.Run(() => GetMore(),TaskSource.Token);
            
        }


        private void GetMore(string startDate = "",string endDate = "")
        {
            Console.WriteLine(next_url);
            string res = HttpHelper.SendDataByGET(next_url, "", cookieContainer);
            if (res == null)
            {
                MessageBox.Show("网络有问题");
                return;
            }
            var result = (JObject)JsonConvert.DeserializeObject(res);
            if (int.Parse(result["errcode"].ToString()) != 0)
            {
                MessageBox.Show(result["errmsg"].ToString());
                return;
            }
            //  处理数据
            foreach (var x in result["result"]["items"])
            {
                ShopList.Add(x);
            }
            

            //  组织链接
            if (Boolean.Parse(result["result"]["pagination"]["isLoadMore"].ToString()))
            {
                //  加载更多
                string timestamp = result["result"]["pagination"]["pageTimestamp"].ToString();
                next_url = string.Format("https://www.szwego.com/album/personal/all?&albumId={0}&searchValue=&searchImg=&startDate={2}&endDate={3}&sourceId=&slipType=1&timestamp={1}&requestDataType=", shop_id, timestamp,startDate,endDate);
                Thread.Sleep(300);
                GetMore(startDate,endDate);
            }
            else
            {
                MessageBox.Show("预加载完毕");
                deal_data(1);
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Console.WriteLine("下一页");
            deal_data(++CurrentPage);
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            deal_data(--CurrentPage);
        }

        private void deal_data(int page)
        {
            DataTable dtSource = new DataTable();
            string[] getFields = new string[] { "shop_name", "goods_id", "title", "mark_code", "itemPrice", "time" };
            foreach (string field in getFields)
            {
                if (!dtSource.Columns.Contains(field))
                {
                    dtSource.Columns.Add(field);
                }
            }

            foreach (var shop_info in ShopList)
            {
                DataRow newRow = dtSource.NewRow();
                foreach (string field in getFields) 
                {
                    newRow[field] = shop_info[field].ToString();
                }
                //try
                //{
                //    newRow["imgsSrc"] = shop_info["imgsSrc"];
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("提取shop_info出错了：" + ex.Message);
                //    continue;
                //}
                dtSource.Rows.Add(newRow);
            }
            BindDgvShop(dtSource);
            return;

            //int pageSize = int.Parse(Cbx_pageSize.SelectedItem.ToString());
            //Console.WriteLine("当前页码："+page+ "，当前页面大小："+pageSize);
            
            
            
            //List<JToken> getData = new List<JToken>();
            
            //if ((page - 1) * pageSize > ShopList.Count)
            //{
            //    //  初始页够了
            //    int getCount = 0;
            //    if(page * pageSize > ShopList.Count)
            //    {
            //        getCount = ShopList.Count - page * pageSize;
            //    }
            //    else
            //    {
            //        getCount = pageSize;
            //    }
                
            //    getData = ShopList.GetRange((page - 1) * pageSize, getCount);
            //}

            //if(getData.Count > 0)
            //{
            //    foreach (var shop_info in getData)
            //    {
            //        DataRow newRow = dtSource.NewRow();

            //        string[] getFields = new string[]{"shop_name","goods_id","title", "mark_code", "itemPrice", "time"};
            //        foreach(string field in getFields)
            //        {
            //            newRow[field] = shop_info[field].ToString();
            //        }
            //        try
            //        {
            //            newRow["imgsSrc"] = shop_info["imgsSrc"];
            //        }catch(Exception ex)
            //        {
            //            Console.WriteLine("提取shop_info出错了："+ex.Message);
            //            continue;
            //        }
            //    }
            //}

            

        }


        private delegate void BindDgvShopDelegate(DataTable dt);

        private void BindDgvShop(DataTable dt)
        {
            if (dgv_shop.InvokeRequired)
            {
                Console.WriteLine("BindDgvFollow");
                dgv_shop.Invoke(new BindDgvShopDelegate(BindDgvShop), dt);
            }
            else
            {
                dgv_shop.DataSource = null;
                dgv_shop.DataSource = dt;
            }
        }
        private void ShopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Console.WriteLine("商品窗体关闭，关闭所有Task");
                
                TaskSource.Cancel();
                TaskSource.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("关闭Task失败：" + ex.Message);
            }
        }
    }
}
