using Codecool.CodecoolShop.Daos;
using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;

namespace Codecool.CodecoolShop.Models
{
    public class OrderDbRepository : IOrderRepository
    {
        public readonly OrderDBContext _db;

        public OrderDbRepository(OrderDBContext db)
        {
            _db = db;
        }

        public IQueryable<Product> Products => _db.Products;

        public IQueryable<ProductCategory> ProductCategories => _db.Categories;

        public IQueryable<Supplier> Suppliers => _db.Suppliers;

        public void Add<EntityType>(EntityType entity) => _db.Add(entity);

        public void Delete<EntityType>(EntityType entity) => _db.Remove(entity);

        public void SaveChanges() => _db.SaveChanges();

        public void Update<EntityType>(EntityType entity) => _db.Update(entity);
    }
}
