using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string email, string phone,
                                   string billingCountry, string billingCity, string billingZip, string billingAddress,
                                   string shippingCountry, string shippingCity, string shippingZip, string shippingAddress)
        {
            CustomerData data = new CustomerData(name, email, phone,
                                                 billingCountry, billingCity, billingZip, billingAddress,
                                                 shippingCountry, shippingCity, shippingZip, shippingAddress);
            Util.CreateJson(data);
            return RedirectToAction("Index", "Payment");
        }
    }
}
