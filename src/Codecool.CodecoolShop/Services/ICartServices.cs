using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface ICartServices
    {
        public IEnumerable<LineItemModel> GetAllLineItems();
        
        public void AddLineItem(LineItemModel lineItem);
        public void RemoveLineItem(LineItemModel lineItem);
    }
}
