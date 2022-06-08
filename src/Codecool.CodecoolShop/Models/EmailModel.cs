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
        public EmailModel(string email)
        {
            To = email;
            Subject = "Order confirmation";
            Body = "Thank you for your order!";
            Email = "nukashop@outlook.com";
            Password = "Asptorpedo";
        }
    }
}
