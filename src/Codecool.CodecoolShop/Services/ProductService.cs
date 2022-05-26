using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;
using System.Linq;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = this.productCategoryDao.Get(categoryId);
            return this.productDao.GetBy(category);
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
    }
}
