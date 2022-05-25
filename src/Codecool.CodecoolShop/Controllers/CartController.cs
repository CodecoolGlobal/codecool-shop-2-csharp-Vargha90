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
        public IActionResult Index(CustomerData data)
        {
            Util.CreateJson(data);
            return RedirectToAction("Index", "Payment");
        }
    }
}
