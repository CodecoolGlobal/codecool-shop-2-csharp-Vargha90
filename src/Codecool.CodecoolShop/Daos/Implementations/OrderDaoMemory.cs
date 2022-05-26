using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Linq;

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
            
            if (data.Any(e => e.Id == item.Id))
            {
                item.Quantity++;
            }
            else
            {
                item.Id = data.Count + 1;
                data.Add(item);
            }
            
        }

        // DO NOT USE THIS
        public void Remove(int id)
        {
            data.Remove(Get(id));
        }

        public void Remove(LineItem item, int id)
        {
            if (item.Quantity == 1)
            {
                data.Remove(Get(id));
            }
            else
            {
                item.Quantity--;
            }
        }

        public LineItem Get(int id)
        {
            return data.Find(x => x.Id == id);
        }
        // redundant
        public IEnumerable<LineItem> GetAll()
        {
            return data;
        }
    }
}
