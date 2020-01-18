using System;

namespace ShoppingBasket
{
    public class BasketItemResult
    {
        public Guid BasketItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DiscountResult Discount { get; set; }
    }
}
