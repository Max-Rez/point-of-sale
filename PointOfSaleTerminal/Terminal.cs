using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSaleTerminal
{
    public class Terminal
    {
        private readonly Dictionary<string, ProductItemsCounter> data;
        public Terminal(IEnumerable<Product> products)
        {
            data = products.ToDictionary(p=>p.Code, p=>new ProductItemsCounter(p.PriceCalculator));
        }

        public void Scan(string productCode)
        {
            if (!data.ContainsKey(productCode))
            {
                throw new ArgumentException("Unknown product code");
            }

            data[productCode].AddItem();
        }

        public decimal CalculateTotal()
        {
            return DoCalculateTotal();
        }


        private decimal DoCalculateTotal()
        {
            return data.Aggregate(0.0M, (a, pr) => a + pr.Value.GetTotalPrice());
        }
}
}
