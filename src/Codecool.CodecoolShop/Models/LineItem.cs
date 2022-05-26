namespace Codecool.CodecoolShop.Models
{
    public class LineItem : BaseModel
    {
        //public string Name { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        //public float Total { get => UnitPrice * Quantity; }

    }
}
