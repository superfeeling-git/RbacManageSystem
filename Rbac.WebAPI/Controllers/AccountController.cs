using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Drawing.Drawing2D;
using System.Text;
using Rbac.Unitity;

namespace Rbac.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private IConfiguration configuration;

        public AccountController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }



        [HttpGet]
        public IActionResult ValidateCode()
        {
            Bitmap bitmap = new Bitmap(6 * 15, 24);

            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.White);

            ValidateCode validateCode = new ValidateCode();

            Font font = new Font("微软雅黑", 12, FontStyle.Bold | FontStyle.Italic);

            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.Red, Color.Blue, 30);

            //SolidBrush brush = new SolidBrush(Color.Red);

            string validatecode = validateCode.GeneralCode();


            graphics.DrawString(validatecode, font, linearGradientBrush, rectangle);

            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            //画线
            for (int i = 0; i < 10; i++)
            {
                graphics.DrawLine(new Pen(Color.FromArgb(100, 0, 0, 255)), random.Next(bitmap.Width), random.Next(bitmap.Height), random.Next(bitmap.Width), random.Next(bitmap.Height));
            }

            MemoryStream memoryStream = new MemoryStream();

            bitmap.Save(memoryStream, ImageFormat.Jpeg);

            HttpContext.Response.Cookies.Append("SetCode", MD5Helper.Encrypt($"{validatecode}{configuration["JwtConfig:CookiesKey"]}"));

            return File(memoryStream.ToArray(), "image/jpeg");
        }



        [HttpPost]
        public IActionResult Login()
        {
            var cookies = Request.Cookies["SetCode"];
            return Ok();
        }
    }

    public class ValidateCode
    {
        /// <summary>
        /// 生成随机串
        /// </summary>
        /// <returns></returns>
        public string GeneralCode()
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
    }
}
