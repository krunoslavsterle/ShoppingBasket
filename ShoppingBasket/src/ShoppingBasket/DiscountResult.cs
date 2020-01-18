using System.Collections.Generic;

namespace ShoppingBasket
{
    public class DiscountResult
    {
        public DiscountResult()
        {
            AppliedDiscounts = new Dictionary<string, int>();
        }

        public decimal TotalDiscount { get; set; }
        public Dictionary<string, int> AppliedDiscounts { get; set; }
    }
}
