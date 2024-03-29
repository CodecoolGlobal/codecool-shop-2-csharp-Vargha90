﻿using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        public CartServices CartService { get; set; }
        public CartController()
        {
            CartService = new CartServices(OrderDaoMemory.GetInstance());
        }


        public IActionResult Index()
        {
            var model = CartService.GetAllLineItems();
            return View(model);
        }

        public IActionResult AddItem()
        {
            var price = Request.Form["price"];
            var name = Request.Form["name"];
            var idStr = Request.Form["id"];
            var id = int.Parse(idStr);
            var priceInt = float.Parse(price);
            LineItemModel item = new LineItemModel() { Name = name, UnitPrice = (int)priceInt, Id = id };
            CartService.AddLineItem(item);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveItem()
        {
            var price = Request.Form["price"];
            var name = Request.Form["name"];
            var idStr = Request.Form["id"];
            var id = int.Parse(idStr);
            var priceInt = float.Parse(price);
            LineItemModel item = new LineItemModel() { Name = name, UnitPrice = (int)priceInt, Id = id };
            CartService.RemoveLineItem(item);
            return RedirectToAction(nameof(Index));
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
