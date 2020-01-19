using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class BasketResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasketResult"/> class.
        /// </summary>
        public BasketResult()
        {
            BasketItemResults = new List<BasketItemResult>();
        }

        /// <summary>
        /// Gets the basket base amount.
        /// </summary>
        public decimal BaseAmount => BasketItemResults.Sum(p => p.BaseAmount);

        /// <summary>
        /// Gets the basket discount amount.
        /// </summary>
        public decimal DiscountAmount => BasketItemResults.Sum(p => p.DiscountResult.TotalDiscount);

        /// <summary>
        /// Gets the basket total amount.
        /// </summary>
        public decimal TotalAmount => BasketItemResults.Sum(p => p.TotalAmount);

        /// <summary>
        /// Gets or sets the individual basket item results.
        /// </summary>
        public ICollection<BasketItemResult> BasketItemResults { get; set; }
    }
}
