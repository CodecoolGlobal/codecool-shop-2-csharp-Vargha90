using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public class CartServices : ICartServices
    {
        private readonly ILineItemDao _lineItemDao;

        public CartServices(ILineItemDao lineItemDao)
        {
            _lineItemDao = lineItemDao;
        }
        public IEnumerable<LineItem> GetAllLineItems() => _lineItemDao.GetAll();
    }
}
