using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
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
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
        }
        public IActionResult Index()
        {
            var model = new ViewModel();
            model.Products = ProductService.GetAllProducts();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(decimal totalPrice, string name, string email, string phone,
            string billingCountry, string billingCity, string billingZip, string billingAddress,
            string shippingCountry, string shippingCity, string shippingZip, string shippingAddress)
        {
            CustomerData data = new CustomerData(totalPrice.ToString("C2"), name, email, phone,
                billingCountry, billingCity, billingZip, billingAddress,
                shippingCountry, shippingCity, shippingZip, shippingAddress);
            TempData["tPrize"] = totalPrice.ToString("C2");
            TempData["email"] = email;
            Util.CreateJson(data);
            return RedirectToAction("Index", "Payment");
        }
    }
}
