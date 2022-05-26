using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Codecool.CodecoolShop.Models
{
    public class PriceModel
    {
        public decimal TotalPrice { get; set; }

        public PriceModel(decimal price)
        {
                TotalPrice = price;
        }
    }
}
