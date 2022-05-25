using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {

        private string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd/ HH-mm-ss");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string email, string phone,
            string bCountry, string bCity, string bZip, string bAddress,
            string sCountry, string sCity, string sZip, string sAddress)
        {
            string currentTime = GetTimestamp(DateTime.Now);
            int id = GenerateOrderId();
            CreateJson(name, email, phone, bCountry, bCity, bZip, bAddress, sCountry, sCity, sZip, sAddress, id, currentTime);
            return View();
        }

        private void CreateJson(string name, string email, string phone,
            string bCountry, string bCity, string bZip, string bAddress,
            string sCountry, string sCity, string sZip, string sAddress, int id,
            string currentTime)
        {
            var customerData = new
            {
                data = new[]
                {
                    new
                    {
                        name = name,
                        email = email,
                        phone = phone,
                        billingCountry = bCountry,
                        billingCity = bCity,
                        billingZip = bZip,
                        billingAddress = bAddress,
                        shippingCountry = sCountry,
                        shippingCity = sCity,
                        shippingZip = sZip,
                        shippingAddress = sAddress
                    }
                }
            };
            var jsonData = JsonSerializer.Serialize(customerData);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            System.IO.File.WriteAllText($"{path}/Order-data/{id + 1} {currentTime}.json", jsonData);
            System.IO.File.WriteAllText($"{path}/Order-data/Order-number.txt", (id + 1).ToString());
        }

        private int GenerateOrderId()
        {
            try
            {
                int orderId = Int32.Parse(System.IO.File.ReadAllText
                    ($"{AppDomain.CurrentDomain.BaseDirectory}/Order-data/Order-number.txt"));
                return orderId;
            }
            catch (FileNotFoundException ex)
            {
                return 0;
            }
        }
    }
}
