﻿using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos
{
    public interface ILineItemDao : IDao<LineItemModel>
    {
       
        void Remove(LineItemModel lineItem);
    }
}
