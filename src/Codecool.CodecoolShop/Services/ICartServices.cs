using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface ICartServices
    {
        public IEnumerable<LineItem> GetAllLineItems();
        
    }
}
