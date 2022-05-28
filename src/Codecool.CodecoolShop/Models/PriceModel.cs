namespace Codecool.CodecoolShop.Models
{
    public class PriceModel
    {
        public string TotalPrice { get; set; }

        public PriceModel(string price)
        {
                TotalPrice = price;
        }
    }
}
