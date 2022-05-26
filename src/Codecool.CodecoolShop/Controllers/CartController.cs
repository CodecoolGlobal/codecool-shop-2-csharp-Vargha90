using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        public ProductService ProductService { get; set; }
        public CartController()
        {
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
        }
        public IActionResult Index()
        {
            var products = ProductService.GetProductsForCategory(1);
            return View(products.ToList());
        }

        [HttpPost]
        public IActionResult Index(decimal totalPrice, string name, string email, string phone,
            string billingCountry, string billingCity, string billingZip, string billingAddress,
            string shippingCountry, string shippingCity, string shippingZip, string shippingAddress)
        {
            CustomerData data = new CustomerData(name, email, phone,
                billingCountry, billingCity, billingZip, billingAddress,
                shippingCountry, shippingCity, shippingZip, shippingAddress);
            Util.CreateJson(data);
            return RedirectToAction("Index", "Payment", new {price = totalPrice});
        }
    }
}
