using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos
{
    public interface IOrderRepository
    {
        public IQueryable<Product> Products { get; }
        public IQueryable<ProductCategory> ProductCategories { get; }
        public IQueryable<Supplier> Suppliers { get; }

        void Add<EntityType>(EntityType entity);
        void Update<EntityType>(EntityType entity);
        void Delete<EntityType>(EntityType entity);
        void SaveChanges();
    }
}
