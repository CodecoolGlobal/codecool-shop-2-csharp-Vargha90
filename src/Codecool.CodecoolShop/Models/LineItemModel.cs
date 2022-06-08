namespace Codecool.CodecoolShop.Models
{
    public class LineItemModel : BaseModel
    {
        public int Quantity { get; set; } = 1;
        public int UnitPrice { get; set; }
        //public float Total { get => UnitPrice * Quantity; }

    }
}
