using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminal
{
    public class ProductItemsCounter
    {
        private readonly IPriceCalculator _priceCalculator;
        private int _productsCount = 0;

        public ProductItemsCounter(IPriceCalculator priceCalculator)
        {
            this._priceCalculator = priceCalculator;
        }

        public void AddItem()
        {
            _productsCount++;
        }

        public decimal GetTotalPrice(decimal discountRate)
        {
            return _priceCalculator.CalculatePrice(_productsCount, discountRate);
        }
    }
}
