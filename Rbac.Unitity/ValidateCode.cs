using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Rbac.Unitity
{
    public class ValidateCode
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private IConfiguration configuration;


        public ValidateCode(IHttpContextAccessor _httpContextAccessor, IConfiguration _configuration)
        {
            this.httpContextAccessor = _httpContextAccessor;
            this.configuration = _configuration;
        }

        private string GeneratorString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 48; i <= 90; i++)
            {
                if (i < 58 || i > 64)
                    stringBuilder.Append((char)i);
            }

            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            string code = stringBuilder.ToString();

            char[] char_code = new char[6];

            for (int i = 0; i < 6; i++)
            {
                char_code[i] = code[random.Next(0, code.Length)];
            }

            return string.Join("", char_code);
        }

        public MemoryStream GeneratorCode()
        {
            Bitmap bitmap = new Bitmap(6 * 15, 24);

            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.White);

            Font font = new Font("微软雅黑", 12, FontStyle.Bold | FontStyle.Italic);

            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.Red, Color.Blue, 30);

            //SolidBrush brush = new SolidBrush(Color.Red);

            string validatecode = GeneratorString();


            graphics.DrawString(validatecode, font, linearGradientBrush, rectangle);

            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            //画线
            for (int i = 0; i < 10; i++)
            {
                graphics.DrawLine(new Pen(Color.FromArgb(100, 0, 0, 255)), random.Next(bitmap.Width), random.Next(bitmap.Height), random.Next(bitmap.Width), random.Next(bitmap.Height));
            }

            MemoryStream memoryStream = new MemoryStream();

            bitmap.Save(memoryStream, ImageFormat.Jpeg);

            httpContextAccessor.HttpContext.Response.Cookies.Append("SetCode", MD5Helper.Encrypt($"{validatecode.ToLower()}{configuration["JwtConfig:CookiesKey"]}"));

            return memoryStream;
        }
    }
}
