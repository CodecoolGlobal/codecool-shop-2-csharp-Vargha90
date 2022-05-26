using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public interface IProductService
    {
        public ProductCategory GetProductCategory(int categoryId);
        public IEnumerable<Product> GetProductsForCategory(int categoryId);

        public IEnumerable<ProductCategory> GetAllCategories();

        public IEnumerable<Product> GetAllProducts();

        public IEnumerable<Supplier> GetAllSuppliers();

        public IEnumerable<Product> GetProductsForSupplier(string supplier);

        public IEnumerable<Supplier> GetSuppliersForCategory(int categoryId);
    }
}
