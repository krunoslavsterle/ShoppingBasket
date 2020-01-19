using System;

namespace ShoppingBasket
{
    public class DiscountCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountCondition"/> class.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The product quantity.</param>
        public DiscountCondition(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Gets the quantity.
        /// </summary>
        public int Quantity { get; }
    }
}
