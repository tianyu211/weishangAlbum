using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Captcha
    {
        //生成數組和字母組合的隨機字符串
        public string GenerateRandomCode()
        {
            //定義驗證碼長度
            int CODELENGTH = 4;
            int number;
            string RandomCode = string.Empty;
            Random r = new Random();
            for (int i = 0; i < CODELENGTH; i++)
            {
                number = r.Next();
                //字符從0~9, A~Z中隨機產生,對應的ASCII碼分別為48~57, 65~90 a-z 97~122
                number = number % 36;
                if (number < 10)
                    number += 48;
                else
                    number += 55;
                RandomCode += ((char)number).ToString();
            }
            //  生成驗證碼
            return RandomCode;
        }

        //生成驗證碼圖片，返回base64編碼
        public string CreateRandomCodeImage(string randomCode)
        {
            string Base64Str = "";
            //若驗證碼為空，則直接返回
            if (randomCode == null || randomCode.Trim() == string.Empty)
                return Base64Str;
            //根據驗證碼的長度確定輸出圖片的寬度
            int iWidth = (int)Math.Ceiling(randomCode.Length * 15m);
            int iHeight = 20;
            //創建圖像
            Bitmap image = new Bitmap(iWidth, iHeight);
            //從圖像獲取一個繪圖面
            Graphics g = Graphics.FromImage(image);

            try
            {
                Random r = new Random();
                //清空圖片背景色
                g.Clear(Color.White);
                //畫圖片的背景噪音線10條
                for (int i = 0; i < 10; i++)
                {
                    int x1 = r.Next(image.Width);
                    int x2 = r.Next(image.Width);
                    int y1 = r.Next(image.Height);
                    int y2 = r.Next(image.Height);
                    //用銀色畫出噪音線
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                //畫圖片的前景噪音點50個
                for (int i = 0; i < 50; i++)
                {
                    int x = r.Next(image.Width);
                    int y = r.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(r.Next()));
                }
                //畫圖片的框線
                g.DrawRectangle(new Pen(Color.SaddleBrown), 0, 0, image.Width - 1, image.Height - 1);
                //定義繪制文字的字體
                Font f = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                //線性漸變畫刷
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Purple, 1.2f, true);
                g.DrawString(randomCode, f, brush, 2, 2);
                //創建內存流用於輸出圖片
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    //圖片格式制定為png
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Base64Str = Convert.ToBase64String(ms.ToArray());
                }
            }
            finally
            {
                //釋放Bitmap對象和Graphics對象
                g.Dispose();
                image.Dispose();
            }

            return Base64Str;
        }

        /// <summary>
        /// 将Base64字符串转换为Image对象
        /// </summary>
        /// <param name="base64Str">base64字符串</param>
        /// <returns></returns>
        public Bitmap Base64StrToImage(string base64Str)
        {
            Bitmap bitmap = null;

            try
            {
                byte[] arr = Convert.FromBase64String(base64Str);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                ms.Close();
                bitmap = bmp;
            }
            catch (Exception ex)
            {
            }

            return bitmap;
        }

    }
}
