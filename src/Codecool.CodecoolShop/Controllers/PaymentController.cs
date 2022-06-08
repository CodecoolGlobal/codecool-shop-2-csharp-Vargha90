using System;
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

        //public static IRestResponse SendSimpleMessage()
        //{
        //    RestClient client = new RestClient();
        //    client.BaseUrl = new Uri("https://api.mailgun.net/v3"); "

        //    client.Authenticator = '

        //    new HttpBasicAuthenticator("api",
        //        "YOUR_API_KEY");
        //    RestRequest request = new RestRequest();
        //    request.AddParameter("domain", "YOUR_DOMAIN_NAME", ParameterType.UrlSegment);
        //    request.Resource = "{domain}/messages";
        //    request.AddParameter("from", "Excited User <mailgun@YOUR_DOMAIN_NAME>");
        //    request.AddParameter("to", "bar@example.com");
        //    request.AddParameter("to", "YOU@YOUR_DOMAIN_NAME");
        //    request.AddParameter("subject", "Hello");
        //    request.AddParameter("text", "Testing some Mailgun awesomness!");
        //    request.Method = Method.POST;
        //    return client.Execute(request);
        //}

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

                    using (SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587))
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
