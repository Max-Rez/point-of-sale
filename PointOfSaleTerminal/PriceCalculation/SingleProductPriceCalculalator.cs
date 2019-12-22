using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminal.PriceCalculation
{
    internal class SingleProductPriceCalculalator : IPriceCalculator
    {
        private readonly decimal singleProductPrice;

        public SingleProductPriceCalculalator(decimal singleProductPrice)
        {
            this.singleProductPrice = singleProductPrice;
        }
        public decimal CalculatePrice(int productsCount) => productsCount * singleProductPrice;
    }
}
