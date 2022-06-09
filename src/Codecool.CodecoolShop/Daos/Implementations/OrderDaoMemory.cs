using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class OrderDaoMemory : ILineItemDao
    {
        private List<LineItemModel> data = new List<LineItemModel>();
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

        public void Add(LineItemModel item)
        {
            
            if (data.Any(e => e.Name == item.Name))
            {
                data[item.Id-1].Quantity++;
            }
            else
            {
                item.Id = data.Count + 1;
                data.Add(item);
            }
            
        }

        /// DO NOT USE THIS <summary>
        /// DO NOT USE THIS
        /// </summary>
        /// <param name="id"></param>
        [System.Obsolete]
        public void Remove(int id)
        {
            data.Remove(Get(id));
        }

        public void Remove(LineItemModel item)
        {
            if (data[item.Id-1].Quantity == 1)
            {
                data.RemoveAt(item.Id-1);
            }
            else
            {
                data[item.Id - 1].Quantity--;
            }
        }

        public LineItemModel Get(int id)
        {
            return data.Find(x => x.Id == id);
        }
        // redundant
        [System.Obsolete]
        public IEnumerable<LineItemModel> GetAll()
        {
            return data;
        }
    }
}
