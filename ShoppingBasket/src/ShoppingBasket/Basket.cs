using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket
{
    /// <summary>
    /// The Basket facade.
    /// </summary>
    public class Basket : IBasket
    {
        private ICollection<BasketItem> _basketItems;
        private readonly IBasketCalculator _basketCalculator;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Basket"/> class.
        /// </summary>
        /// <param name="basketCalculator">The basket calculator.</param>
        public Basket(IBasketCalculator basketCalculator, ILogger<Basket> logger)
        {
            _basketCalculator = basketCalculator;
            _logger = logger;
            _basketItems = new List<BasketItem>();
        }

        /// <summary>
        /// Gets the collection of <see cref="BasketItem"/> in Basket.
        /// </summary>
        public IEnumerable<BasketItem> BasketItems => _basketItems;

        /// <summary>
        /// Adds a new <see cref="BasketItem"/> to the Basket.
        /// </summary>
        /// <param name="basketItem">The basket item.</param>
        public void AddToBasket(BasketItem basketItem)
        {
            var existing = _basketItems.FirstOrDefault(p => p.ProductId == basketItem.ProductId);
            if (existing == null)
                _basketItems.Add(basketItem);
            else
                existing.UpdateQuantity(existing.Quantity + 1);
        }

        /// <summary>
        /// Removes the <see cref="BasketItem"/> from the Basket.
        /// </summary>
        /// <param name="id">The basket item identifier.</param>
        public void RemoveFromBasket(Guid id)
        {
            var existing = _basketItems.FirstOrDefault(p => p.ProductId == id);
            if (existing == null)
                return;

            if (existing.Quantity > 1)
                existing.UpdateQuantity(existing.Quantity - 1);
            else
                _basketItems.Remove(existing);
        }

        /// <summary>
        /// Gets the Basket totals.
        /// </summary>
        /// <returns>The <see cref="BasketResult"/>.</returns>
        public BasketResult GetTotals()
        {
            var result = _basketCalculator.Calculate(BasketItems);
            if (_logger != null)
                LogTotals(result);

            return result;
        }

        private void LogTotals(BasketResult result)
        {
            var message = new StringBuilder();
            message.AppendLine(".GetTotals()");
            message.AppendLine($"\tBase Amount: {result.BaseAmount.ToString("c")}");
            message.AppendLine($"\tTotal Discount: {result.DiscountAmount.ToString("c")}");
            message.AppendLine($"\tTotal Amount: {result.TotalAmount.ToString("c")}");
            message.AppendLine($"\tItems:");

            foreach (var item in result.BasketItemResults)
            {
                message.AppendLine($"\t\tProductId: {item.ProductId}; Quantity: {item.Quantity}; Base Amount: {item.BaseAmount.ToString("c")}; TotalAmount: {item.TotalAmount.ToString("c")};");

                if (item.DiscountResult.AppliedDiscounts.Any())
                    foreach (var discount in item.DiscountResult.AppliedDiscounts)
                        message.AppendLine($"\t\t\tApplied Discount: {discount.Key}; Number of times applied: {discount.Value}; Total Discount Amount: {item.DiscountResult.TotalDiscount.ToString("c")}");
            }

            _logger.LogInformation(message.ToString());
        }
    }
}
