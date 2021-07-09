using CefSharp;
using CefSharp.WinForms;
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
    public partial class BrowserForm : Form
    {

        public string cookies;
        public CookieContainer cookieContainer = new CookieContainer();
        public string source;
        public string token = "";
        public BrowserForm()
        {
            InitializeComponent();
            
            var setting = new CefSettings();
            setting.Locale = "zh-CN";
            setting.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.114 Safari/537.36";

            CefSharp.Cef.Initialize(setting, true);
            //chromeBrowser.FrameLoadEnd += FrameLoadEnd_GetSource;

        }


        private void chromeBrowser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();

            CookieVisitor visitor = new CookieVisitor();
            visitor.SendCookie += visitor_SendCookie;
            cookieManager.VisitAllCookies(visitor);
        }

        private void visitor_SendCookie(CefSharp.Cookie obj)
        {
            cookies += obj.Domain.TrimStart('.') + "^" + obj.Name + "^" + obj.Value + "$";
            if (obj.Name == "token")
            {
                token = obj.Value;
                Console.WriteLine(string.Format("设置Cookie：{0} -- {1} : {2}", "www.szwego.com", obj.Name, obj.Value));
                cookieContainer.Add(new System.Uri("https://www.szwego.com"), new System.Net.Cookie(obj.Name, obj.Value));
            }
        }
    }
}
