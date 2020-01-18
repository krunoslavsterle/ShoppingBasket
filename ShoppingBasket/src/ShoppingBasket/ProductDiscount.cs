using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ProductDiscount
    {
        private ICollection<DiscountCondition> _discountConditions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDiscount"/> class.
        /// </summary>
        /// <param name="name">The name of the discount.</param>
        /// <param name="discountPercentage">The discount percentage.</param>
        public ProductDiscount(string name, decimal discountPercentage)
        {
            Name = name;
            DiscountPercentage = discountPercentage;

            _discountConditions = new List<DiscountCondition>();
        }

        /// <summary>
        /// Gets the discount name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the discount percentage.
        /// </summary>
        public decimal DiscountPercentage { get; }

        /// <summary>
        /// Gets the collection of <see cref="DiscountCondition"/>.
        /// </summary>
        public IEnumerable<DiscountCondition> DiscountConditions => _discountConditions;

        /// <summary>
        /// Adds a new <see cref="DiscountCondition"/>.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity condition for a given product.</param>
        public void AddCondition(Guid productId, int quantity)
        {
            if (_discountConditions.Any(p => p.ProductId == productId))
                throw new Exception($"Discount Condition already exists for {productId} Product"); // TODO: CUSTOM EXCEPTIONS?

            if (quantity < 1)
                throw new ArgumentOutOfRangeException("Quantity must be greater than 0");

            _discountConditions.Add(new DiscountCondition(productId, quantity));
        }
    }
}
