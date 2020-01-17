using System.Collections.Generic;

namespace ShoppingBasket
{
    /// <summary>
    /// BasketCalculator contract.
    /// </summary>
    public interface IBasketCalculator
    {
        BasketResult Calculate(IEnumerable<BasketItem> basketItems);
    }
}
