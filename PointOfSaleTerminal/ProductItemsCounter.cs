using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminal
{
    public class ProductItemsCounter
    {
        private readonly IPriceCalculator priceCalculator;
        private int productsCount = 0;

        public ProductItemsCounter(IPriceCalculator priceCalculator)
        {
            this.priceCalculator = priceCalculator;
        }

        public void AddItem()
        {
            productsCount++;
        }

        public decimal GetTotalPrice()
        {
            return priceCalculator.CalculatePrice(productsCount);
        }
    }
}
