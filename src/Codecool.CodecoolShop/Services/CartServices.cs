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

        public void AddLineItem(LineItemModel lineItem) => _lineItemDao.Add(lineItem);

        public IEnumerable<LineItemModel> GetAllLineItems() => _lineItemDao.GetAll();

        public void RemoveLineItem(LineItemModel lineItem) => _lineItemDao.Remove(lineItem);
    }
}
