using System.Net;
using System.Net.Mail;
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
            return RedirectToAction("Index", "Product");
        }
    }
}
