using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Drawing.Design;
using System.IO;
using System.Drawing;

namespace DDIWebApp
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class checkcode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            this.CreateCheckCodeImage(context); 

        }
        
        private void CreateCheckCodeImage(HttpContext context)
        {
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random1 = new Random();

            for (int i = 0; i < 4; i++)
            {
                number = random1.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                checkCode += code.ToString();
            }
            context.Response.Cookies.Add(new HttpCookie("checkcode", checkCode));
           
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(checkCode.Length * 20, 40);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器   
                Random random = new Random();
                //清空图片背景色  
 
                //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //g.SmoothingMode = SmoothingMode.HighQuality;
                //g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //g.CompositingMode = CompositingMode.SourceOver;
                //g.CompositingQuality = CompositingQuality.HighQuality;
                //g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                //g.PageUnit = GraphicsUnit.Pixel;
                //g.Clear(Color.Blue);
                //画图片的背景噪音线   
                //for (int i = 0; i < 25; i++)
                //{
                //    int x1 = random.Next(image.Width);
                //    int x2 = random.Next(image.Width);
                //    int y1 = random.Next(image.Height);
                //    int y2 = random.Next(image.Height);
                //    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                //}

                Font font = new System.Drawing.Font("Arial", 20, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Yellow, Color.Yellow, 1.2f, true);
                g.DrawString(checkCode, font, brush,2,5);
                //画图片的前景噪音点   
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线   
                //g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //清楚背景，生成透明背景图片
                image = MakeTransparentGif(image, Color.Blue);
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                context.Response.ClearContent();
                context.Response.ContentType = "image/Gif";
                context.Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Make the image transparent. 
        /// The input is the color which you want to make transparent.
        /// </summary>
        /// <param name="color">The color to make transparent.</param>
        /// <param name="bitmap">The bitmap to make transparent.</param>
        /// <returns>New memory stream containing transparent background gif.</returns>
        public Bitmap MakeTransparentGif(Bitmap bitmap, Color color)
        {
            byte R = color.R;
            byte G = color.G;
            byte B = color.B;

            MemoryStream fin = new MemoryStream();
            bitmap.Save(fin, System.Drawing.Imaging.ImageFormat.Gif);

            MemoryStream fout = new MemoryStream((int)fin.Length);
            int count = 0;
            byte[] buf = new byte[256];
            byte transparentIdx = 0;
            fin.Seek(0, SeekOrigin.Begin);
            //header
            count = fin.Read(buf, 0, 13);
            if ((buf[0] != 71) || (buf[1] != 73) || (buf[2] != 70)) return null; //GIF

            fout.Write(buf, 0, 13);

            int i = 0;
            if ((buf[10] & 0x80) > 0)
            {
                i = 1 << ((buf[10] & 7) + 1) == 256 ? 256 : 0;
            }

            for (; i != 0; i--)
            {
                fin.Read(buf, 0, 3);
                if ((buf[0] == R) && (buf[1] == G) && (buf[2] == B))
                {
                    transparentIdx = (byte)(256 - i);
                }
                fout.Write(buf, 0, 3);
            }

            bool gcePresent = false;
            while (true)
            {
                fin.Read(buf, 0, 1);
                fout.Write(buf, 0, 1);
                if (buf[0] != 0x21) break;
                fin.Read(buf, 0, 1);
                fout.Write(buf, 0, 1);
                gcePresent = (buf[0] == 0xf9);
                while (true)
                {
                    fin.Read(buf, 0, 1);
                    fout.Write(buf, 0, 1);
                    if (buf[0] == 0) break;
                    count = buf[0];
                    if (fin.Read(buf, 0, count) != count) return null;
                    if (gcePresent)
                    {
                        if (count == 4)
                        {
                            buf[0] |= 0x01;
                            buf[3] = transparentIdx;
                        }
                    }
                    fout.Write(buf, 0, count);
                }
            }
            while (count > 0)
            {
                count = fin.Read(buf, 0, 1);
                fout.Write(buf, 0, 1);
            }
            fin.Close();
            fout.Flush();

            return new Bitmap(fout);
        } 
    }
}
