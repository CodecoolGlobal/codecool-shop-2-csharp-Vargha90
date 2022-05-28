using System.Net;
using System.Net.Mail;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        public ActionResult Index()
        {
            string totalPrice;

            if (TempData.ContainsKey("tPrize"))
            {
                totalPrice = TempData["tPrize"].ToString();
                PriceModel price = new PriceModel(totalPrice);
                return View(price);
            }

            return View();
        }

        public IActionResult SendEmail()
        {
            string email;
            using (MailMessage mail = new MailMessage())
            {
                if (TempData.ContainsKey("email"))
                { 
                    email = TempData["email"].ToString();
                    EmailModel model = new EmailModel(email);
                    mail.From = new MailAddress(model.Email);
                    mail.To.Add(email);
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
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
