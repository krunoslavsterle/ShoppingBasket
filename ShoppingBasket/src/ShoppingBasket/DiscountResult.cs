using System.Collections.Generic;

namespace ShoppingBasket
{
    public class DiscountResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountResult"/> class.
        /// </summary>
        public DiscountResult()
        {
            AppliedDiscounts = new Dictionary<string, int>();
        }

        /// <summary>
        /// Gets or sets the total discount.
        /// </summary>
        public decimal TotalDiscount { get; set; }

        /// <summary>
        /// Gets or sets the dictionary with applied discounts and number of times each discount was applied.
        /// </summary>
        public Dictionary<string, int> AppliedDiscounts { get; set; }
    }
}
