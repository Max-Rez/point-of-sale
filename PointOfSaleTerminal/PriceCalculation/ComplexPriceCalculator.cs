using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminal.PriceCalculation
{
    internal class ComplexPriceCalculator : IPriceCalculator
    {
        private readonly SingleProductPriceCalculalator singleProductPriceCalculator;
        private readonly decimal specialPrice;
        private readonly int productsPerShareCount;

        public ComplexPriceCalculator(decimal singleProductPrice, int productsPerShareCount, decimal specialPrice)
        {
            singleProductPriceCalculator = new SingleProductPriceCalculalator(singleProductPrice);
            this.productsPerShareCount = productsPerShareCount;
            this.specialPrice = specialPrice;
        }

        public decimal CalculatePrice(int productsCount)
        {
            return (productsCount / productsPerShareCount) * specialPrice +
                   singleProductPriceCalculator.CalculatePrice(productsCount % productsPerShareCount);
        }
    }
}
