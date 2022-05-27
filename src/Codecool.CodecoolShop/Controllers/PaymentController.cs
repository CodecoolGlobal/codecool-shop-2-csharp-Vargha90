using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        [Route("Payment/Index/{price}")]
        public IActionResult Index(decimal price)
        {
            PriceModel totalPrice = new PriceModel(price);
            return View(totalPrice);
        }

        //[HttpPost]
        public IActionResult SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                EmailModel model = new EmailModel();
                mail.From = new MailAddress(model.Email);
                mail.To.Add("varghalaszlo90@gmail.com");
                mail.Subject = model.Subject;
                mail.Body = model.Body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(model.Email, model.Password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            //EmailModel model = new EmailModel();
            //using (MailMessage message = new MailMessage(model.Email, model.To))
            //{
            //    message.Subject = model.Subject;
            //    message.Body = model.Body;
            //    message.IsBodyHtml = false;

            //    using (SmtpClient smtp = new SmtpClient())
            //    {
            //        smtp.Host = "smtp.gmail.com";
            //        smtp.EnableSsl = true;
            //        NetworkCredential credential = new NetworkCredential(model.Email, model.Password);
            //        smtp.UseDefaultCredentials = true;
            //        smtp.Credentials = credential;
            //        smtp.Port = 587;
            //        smtp.Send(message);
            //    }
            //}

            return RedirectToAction("Index", "Product");
        }
    }
}
