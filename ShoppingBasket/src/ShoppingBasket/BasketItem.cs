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

        public BasketItem(Guid id, string name, decimal unitPrice, int quantity = 1)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            _quantity = quantity;
            Discounts = new List<ProductDiscount>();
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal UnitPrice { get; }
        public int Quantity => _quantity;
        
        public ICollection<ProductDiscount> Discounts { get; }

        public void UpdateQuantity(int quantity)
        {
            _quantity = quantity;
        }
    }
}
