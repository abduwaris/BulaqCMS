using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BulaqCMS.Admin
{
    /// <summary>
    /// ImageCode 的摘要说明
    /// </summary>
    public class ImageCode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.BufferOutput = true;
            string validate;
            byte[] buffer = ValidateCode.CreateValidateGraphic(4, out validate);
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Session[AdminBasePage.ImageCodeInSession] = validate;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }




    }

    /// <summary>
    /// تەستىق كود ھاسىللاش تۈرى
    /// </summary>
    public class ValidateCode
    {
        /// <summary>
        /// تەستىق كود مەزمۇنى ھاسىللاش
        /// </summary>
        /// <param name="length">تەستىق كودنىڭ ئوزۇنلۇقى</param>
        /// <returns>تەستىق كود مەزمۇنىنى قايتۇرىدۇ</returns>
        public static string CreateValidateCode(int length)
        {
            string validateNumberStr = "";
            string str = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            Random RAN = new Random();
            for (int i = 0; i < length; i++) validateNumberStr += str[RAN.Next(0, str.Length)];
            return validateNumberStr;
        }

        /// <summary>
        /// تەستىق كود رەسىمىنى ھاسىللايدۇ
        /// </summary>
        /// <param name="validateNum">تەستىق كود</param>
        /// <returns>ھاسىللىغان تەستىق كود رەسىمىنىڭ ئىككىلىك مەزمۇنىنى قايتۇرىدۇ</returns>
        public static byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 28.0), 42);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                g.Clear(Color.White);
                //تەسىر سىزىقى سىزىش
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                for (int i = 0; i < image.Width; i += 6)
                {
                    //  |||
                    g.DrawLine(new Pen(ColorTranslator.FromHtml("#ffa8a8"), 2), i, 0, i, image.Height);
                }
                for (int j = 0; j < image.Height; j += 6)
                {
                    /// -----+++++
                    /// -----+++++
                    g.DrawLine(new Pen(Color.Green, 2), 0, j, image.Width, j);
                }
                Font font = new Font("Arial", 20, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                 Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                //رەسىمنىڭ ئالدى يۈز تەسىر قىسمىنى سىزىش
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //رەسىمنىڭ قىرىنى سىزىش
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //رەسىم مەزمۇنى ساقلاش
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //رەسىم ھۆججەت ئېقىمىنى قايتۇرۇش
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// تەستىق كود رەسىمى ۋە تەستىق كودنى ھاسىللايدۇ
        /// </summary>
        /// <param name="length">تەستىق كود ئوزۇنلۇقى</param>
        /// <param name="validateCode">ھاسىللانغان تەستىق كود</param>
        /// <returns>تەستىق كود رەسىمى</returns>
        public static byte[] CreateValidateGraphic(int length, out string validateCode)
        {
            validateCode = CreateValidateCode(length);
            return CreateValidateGraphic(validateCode);
        }
    }
}