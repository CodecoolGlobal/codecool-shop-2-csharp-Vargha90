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
    }
}
