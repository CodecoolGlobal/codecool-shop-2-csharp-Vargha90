using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class LineItemDaoMemory : ILineItemDao
    {
        private List<LineItem> data = new();
        private static LineItemDaoMemory instance = null;

        private LineItemDaoMemory()
        {
        }

        public static LineItemDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new LineItemDaoMemory();
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
