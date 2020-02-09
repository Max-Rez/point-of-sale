using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminal.PriceCalculation
{
    internal class SingleProductPriceCalculalator : IPriceCalculator
    {
        private readonly decimal _singleProductPrice;

        public SingleProductPriceCalculalator(decimal singleProductPrice)
        {
            _singleProductPrice = singleProductPrice;
        }
        public decimal CalculatePrice(int productsCount, decimal discountRate)
        {
            return productsCount * _singleProductPrice * (1.0M - discountRate);
        }
    }
}
