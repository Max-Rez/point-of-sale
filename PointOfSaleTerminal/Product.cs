using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminal
{
    public class Product
    {
        public Product(string code, IPriceCalculator priceCalculator)
        {
            Code = code;
            PriceCalculator = priceCalculator;
        }
        public string Code { get; private set; }
        public IPriceCalculator PriceCalculator { get; private set; }
    }
}
