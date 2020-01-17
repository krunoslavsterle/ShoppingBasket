using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    /// <summary>
    /// BasketCalculator implementation.
    /// </summary>
    public class BasketCalculator : IBasketCalculator
    {
        public BasketResult Calculate(IEnumerable<BasketItem> basketItems)
        {
            var result = new BasketResult
            {
                BaseAmount = basketItems.Sum(p => p.UnitPrice * p.Quantity)
            };

            return result;
        }
    }
}
