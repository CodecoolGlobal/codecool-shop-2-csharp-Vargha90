using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierDao;
        private readonly ILineItemDao lineItemDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;
        }


        public Product GetProduct(int productId) => productDao.Get(productId);

        public IEnumerable<Product> GetAllProducts() => productDao.GetAll();

        public ProductCategory GetProductCategory(int categoryId) => productCategoryDao.Get(categoryId);

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = productCategoryDao.Get(categoryId);
            return productDao.GetBy(category);
        }

        public IEnumerable<Product> GetProductsForSupplier(int supplierId)
        {
            Supplier supplier = supplierDao.Get(supplierId);
            return productDao.GetBy(supplier);
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return supplierDao.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return productCategoryDao.GetAll();
        }

        public IEnumerable<Supplier> GetSuppliersForCategory(int categoryId)
        {
            ProductCategory chosenCategory = GetProductCategory(categoryId);
            return productDao.GetAll().Where(p => p.ProductCategory.Equals(chosenCategory)).Select(p => p.Supplier);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productDao.GetAll();
        }

        public IEnumerable<Product> GetProductsForSupplier(string supplier)
        {
            return productDao.GetAll().Where(p => p.Supplier.Name.Equals(supplier));
        }



        public void AddProduct(Product product) => productDao.Add(product);

        public void AddProductCategory(ProductCategory category) => productCategoryDao.Add(category);

        public void AddSupplier(Supplier supplier) => supplierDao.Add(supplier);



        public void RemoveProduct(int productId) => productDao.Remove(productId);
        public void RemoveProductCategory(int categoryId) => productCategoryDao.Remove(categoryId);
        public void RemoveSupplier(int supplierId) => productCategoryDao.Remove(supplierId);



    }
}
