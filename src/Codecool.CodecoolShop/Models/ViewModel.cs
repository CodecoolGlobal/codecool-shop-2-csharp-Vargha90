using System.Collections;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
    }
}
