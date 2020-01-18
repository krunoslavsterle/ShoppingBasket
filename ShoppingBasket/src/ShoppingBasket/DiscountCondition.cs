using System;

namespace ShoppingBasket
{
    public class DiscountCondition
    {
        public DiscountCondition(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductId { get; }
        public int Quantity { get; }
    }
}
