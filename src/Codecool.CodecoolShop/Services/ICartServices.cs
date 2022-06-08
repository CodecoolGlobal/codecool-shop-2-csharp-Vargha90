using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface ICartServices
    {
        public IEnumerable<LineItem> GetAllLineItems();
        
        public void AddLineItem(LineItem lineItem);
        public void RemoveLineItem(LineItem lineItem);
    }
}
