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

        public void AddProduct(Product product);

        public void AddProductCategory(ProductCategory category);

        public void AddSupplier(Supplier supplier);



        public void RemoveProduct(int productId);
        public void RemoveProductCategory(int categoryId);
        public void RemoveSupplier(int supplierId);
    }
}
