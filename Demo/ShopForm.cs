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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class ShopForm : Form
    {
        private string shop_id;
        private CookieContainer cookieContainer;
        private string next_url;
        public ShopForm(string _shop_id, CookieContainer _cookieContainer)
        {
            InitializeComponent();
            shop_id = _shop_id;
            cookieContainer = _cookieContainer;
            next_url = string.Format("https://www.szwego.com/album/personal/all?&albumId={0}&searchValue=&searchImg=&startDate=&endDate=&sourceId=&requestDataType=", shop_id);
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {

            GetMore();
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
                MessageBox.Show(result["errmsg"].ToString()); return;
            }
            //  处理数据
            foreach(var x in result["result"]["items"])
            {
                Console.WriteLine(x["title"].ToString());
            }
            
            
            
            //  组织链接
            if (Boolean.Parse(result["result"]["pagination"]["isLoadMore"].ToString()))
            {
                //  加载更多
                string timestamp = result["result"]["pagination"]["pageTimestamp"].ToString();
                next_url = string.Format("https://www.szwego.com/album/personal/all?&albumId={0}&searchValue=&searchImg=&startDate={2}&endDate={3}&sourceId=&slipType=1&timestamp={1}&requestDataType=", shop_id, timestamp,startDate,endDate);

            }
            else
            {
                Console.WriteLine("加载完毕");
            }
        }

    }
}
