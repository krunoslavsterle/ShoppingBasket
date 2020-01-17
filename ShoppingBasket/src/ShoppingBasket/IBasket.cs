using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    public interface IBasket
    {
        IEnumerable<BasketItem> BasketItems { get;  }

        void AddToBasket(BasketItem basketItem);
        void RemoveFromBasket(Guid id);
        BasketResult GetTotals();
    }
}
