using System;

namespace ShoppingBasket
{
    public class BasketItemResult
    {
        public Guid BaskettemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal BaseAmount { get; set; }
        public DiscountResult Discount { get; set; }
    }
}
