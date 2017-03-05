using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Web
{
    public partial class AuthCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //创建图片对象
            Bitmap map = new Bitmap(100, 30);

            //创建画图对象
            Graphics g = Graphics.FromImage(map);
            g.Clear(Color.White);

            //创建数组 
            string array = "0123456789abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";

            string result = string.Empty;

            SolidBrush[] brushs = new SolidBrush[] { new SolidBrush(Color.Black), new SolidBrush(Color.Black), new SolidBrush(Color.Green), new SolidBrush(Color.Blue), new SolidBrush(Color.Green) };
            Font[] fonts = new Font[] { new Font("宋体", 16, FontStyle.Bold), new Font("隶书", 16, FontStyle.Bold), new Font("幼圆", 20, FontStyle.Bold), new Font("楷体_GB2312", 20, FontStyle.Bold), new Font("华文琥珀", 20, FontStyle.Bold) };

            //随机生成4个数 
            Random rom = new Random();
            for (int i = 0; i < 4; i++)
            {
                int number = rom.Next(0, array.Length);
                result += array[number];
                g.DrawString(array[number].ToString(), fonts[number / 13], brushs[number / 13], i * 20f, 2f);

            }
            //Random r = new Random(4);
            //for (int i = 0; i < 100; i++)
            //{
            //    int number = rom.Next(0, 100);
            //    int num = r.Next(0, 50);

            //    g.DrawEllipse(new Pen(brushs[number / 20]), number, num, 1f, 1f);
            //}


            //声明流
            MemoryStream stream = new MemoryStream();
            map.Save(stream, ImageFormat.Jpeg);

            //返回结果
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(stream.ToArray());

            HttpCookie cookie = new HttpCookie("ValidateCode");
            cookie.Values.Add("code", result);
            Response.Cookies.Add(cookie);
        }
    }
}