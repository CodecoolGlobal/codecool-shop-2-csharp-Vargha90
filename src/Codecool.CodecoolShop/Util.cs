using System;
using System.IO;
using System.Text.Json;

namespace Codecool.CodecoolShop
{
    public static class Util
    {
        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd/ HH-mm-ss");
        }

        public static void CreateJson(CustomerData data)
        {
            int id = GenerateOrderId();
            string currentTime = GetTimestamp(DateTime.Now);
            var customerData = new
            {
                data = new[]
                {
                    new
                    {
                        name = data.Name,
                        email = data.Email,
                        phone = data.Phone,
                        billingCountry = data.BillingCountry,
                        billingCity = data.BillingCity,
                        billingZip = data.BillingZip,
                        billingAddress = data.BillingAddress,
                        shippingCountry = data.ShippingCountry is null ? data.BillingCountry : data.ShippingCountry,
                        shippingCity = data.ShippingCity is null ? data.BillingCity : data.ShippingCity,
                        shippingZip = data.ShippingZip is null ? data.BillingZip : data.ShippingZip,
                        shippingAddress = data.ShippingAddress is null ? data.BillingAddress : data.ShippingAddress
                    }
                }
            };
            var jsonData = JsonSerializer.Serialize(customerData);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            System.IO.File.WriteAllText($"{path}/Order-data/{id + 1} {currentTime}.json", jsonData);
            System.IO.File.WriteAllText($"{path}/Order-data/Order-number.txt", (id + 1).ToString());
        }

        private static int GenerateOrderId()
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
