using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class OrderDaoMemory : ILineItemDao
    {
        private List<LineItem> data = new List<LineItem>();
        private static OrderDaoMemory instance = null;

        private OrderDaoMemory()
        {
        }

        public static OrderDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new OrderDaoMemory();
            }

            return instance;
        }

        public void Add(LineItem item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public LineItem Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<LineItem> GetAll()
        {
            return data;
        }
    }
}
