using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    /// <summary>
    /// BasketItem implementation.
    /// </summary>
    public class BasketItem
    {
        private int _quantity = 0;
        private ICollection<ProductDiscount> _discounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketItem"/> class.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productName">The product name.</param>
        /// <param name="unitPrice">The price of one unit.</param>
        /// <param name="quantity">The product quantity.</param>
        public BasketItem(Guid productId, string productName, decimal unitPrice, int quantity = 1)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            _quantity = quantity;
            _discounts = new List<ProductDiscount>();
        }

        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Gets the product name.
        /// </summary>
        public string ProductName { get; }

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        public decimal UnitPrice { get; }

        /// <summary>
        /// Gets the quantity.
        /// </summary>
        public int Quantity => _quantity;

        /// <summary>
        /// Gets the discounts.
        /// </summary>
        public IEnumerable<ProductDiscount> Discounts => _discounts;

        /// <summary>
        /// Updates the quantity.
        /// </summary>
        /// <param name="quantity">The new quantity.</param>
        public void UpdateQuantity(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException("Quantity must be greater than 0");

            _quantity = quantity;
        }

        /// <summary>
        /// Adds a new discount.
        /// </summary>
        /// <param name="discount">The new discount.</param>
        public void AddDiscount(ProductDiscount discount)
        {
            _discounts.Add(discount);
        }
    }
}
