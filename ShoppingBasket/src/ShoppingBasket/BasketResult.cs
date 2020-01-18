using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class BasketResult
    {
        public BasketResult()
        {
            BasketItemResults = new List<BasketItemResult>();
        }

        public decimal BaseAmount => BasketItemResults.Sum(p => p.BaseAmount);
        public decimal DiscountAmount => BasketItemResults.Sum(p => p.Discount.TotalDiscount);
        public decimal TotalAmount => BaseAmount - DiscountAmount;

        public ICollection<BasketItemResult> BasketItemResults { get; set; }
    }
}
