using System.Diagnostics;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;


namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }
        public CartServices CartServices { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            CartServices = new CartServices(OrderDaoMemory.GetInstance());
        }
        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = ProductService.GetAllSuppliers();
            var categories = ProductService.GetAllCategories();
            var products = ProductService.GetAllProducts();
            ViewModel model = new ViewModel();
            model.Products = products;
            model.Categories = categories;
            model.Suppliers = suppliers;
            //HttpContext.Session.SetString("test", "hello");
            //string value = HttpContext.Session.GetString("test");
            return View(model);
        }

        

        //[HttpPost]
        //public IActionResult Filter(string name)
        //{
        //    IEnumerable<Product> products;
        //    if (name != null)
        //        products = ProductService.GetProductsForSupplier(name);
        //    else 
        //        products = ProductService.GetAllProducts();
        //    return RedirectToAction("Index", "Product", products);
        //}

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(Product product)
        {
            // Name and Price here
            var show = product.Name;
            var price = Request.Form["price"];
            var name = Request.Form["name"];
            var priceInt = float.Parse(price);
            LineItemModel item = new LineItemModel() { Name = name, UnitPrice = (int)priceInt };
            CartServices.AddLineItem(item);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
