using System;

namespace ShoppingBasket
{
    public class BasketItemResult
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the item base amount.
        /// </summary>
        public decimal BaseAmount { get; set; }

        /// <summary>
        /// Gets or sert the item total amount.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the item discount result.
        /// </summary>
        public DiscountResult DiscountResult { get; set; }
    }
}
