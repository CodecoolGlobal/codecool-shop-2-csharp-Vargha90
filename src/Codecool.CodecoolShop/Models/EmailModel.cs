using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Codecool.CodecoolShop.Models
{
    public class EmailModel
    {
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        //public IFormFile Attachment { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public EmailModel()
        {
            To = "varghalaszlo90@gmail.com";
            Subject = "Order confirmation";
            Body = "Thank you for your order!";
            Email = "nukaflammenwerfertorpedo@gmail.com";
            Password = "Asptorpedo";
        }
    }
}
