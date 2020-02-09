using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminal.PriceCalculation
{
    internal class ComplexPriceCalculator : IPriceCalculator
    {
        private readonly SingleProductPriceCalculalator _singleProductPriceCalculator;
        private readonly decimal _specialPrice;
        private readonly int _productsPerShareCount;

        public ComplexPriceCalculator(decimal singleProductPrice, int productsPerShareCount, decimal specialPrice)
        {
            _singleProductPriceCalculator = new SingleProductPriceCalculalator(singleProductPrice);
            _productsPerShareCount = productsPerShareCount;
            _specialPrice = specialPrice;
        }

        public decimal CalculatePrice(int productsCount, decimal discountRate)
        {
            return (productsCount / _productsPerShareCount) * _specialPrice +
                   _singleProductPriceCalculator.CalculatePrice(productsCount % _productsPerShareCount, discountRate);
        }
    }
}
