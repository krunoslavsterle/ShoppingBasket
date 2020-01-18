using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    /// <summary>
    /// The DiscountCalculator implementation.
    /// </summary>
    public class DiscountCalculator : IDiscountCalculator
    {
        /// <summary>
        /// Calculates the discounts for a given product.
        /// </summary>
        /// <param name="basketItems">The collection of <see cref="BasketItem"/>.</param>
        /// <param name="productId">The product identifier for which to calculate discounts.</param>
        /// <returns>The <see cref="DiscountResult"/>.</returns>
        public DiscountResult Calculate(IEnumerable<BasketItem> basketItems, Guid productId)
        {
            var result = new DiscountResult();
            var basketItem = basketItems.First(p => p.Id == productId);
            
            foreach(var discount in basketItem.Discounts)
            {
                int? appliedNo = (int?)null;
                foreach(var condition in discount.DiscountConditions)
                {
                    // check if there is condition product present in the basket, if not, skip this discount.
                    var conditionBItem = basketItems.SingleOrDefault(p => p.Id == condition.ProductId);
                    if (conditionBItem == null)
                    {
                        appliedNo = 0;
                        break;
                    }

                    var conditionAppliedNo = ValidateDiscountCondition(condition, conditionBItem);
                    if (!appliedNo.HasValue)
                        appliedNo = conditionAppliedNo;
                    else
                        appliedNo = appliedNo.Value > conditionAppliedNo ? conditionAppliedNo : appliedNo.Value;
                }

                if (appliedNo.HasValue && appliedNo.Value > 0)
                {
                    // Can't be applied more times than the quantity of given product in basket.
                    appliedNo = appliedNo.Value > basketItem.Quantity ? basketItem.Quantity : appliedNo.Value;
                    result.TotalDiscount += (Decimal.Round((basketItem.UnitPrice * (discount.DiscountPercentage / 100)), 2) * appliedNo.Value);
                    result.AppliedDiscounts.Add(discount.Name, appliedNo.Value);
                }
            }

            return result;
        }

        private int ValidateDiscountCondition(DiscountCondition discountCondition, BasketItem basketItem)
        {
            // Calculate the number of times the discount can be applied based on this condition.
            return (int)(basketItem.Quantity / discountCondition.Quantity);
        }
    }
}
