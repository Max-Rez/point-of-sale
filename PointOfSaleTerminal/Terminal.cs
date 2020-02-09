using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PointOfSaleTerminal.DiscountCalculation;

namespace PointOfSaleTerminal
{
    public class Terminal
    {
        private readonly Dictionary<string, ProductItemsCounter> _data;

        public Terminal(IEnumerable<Product> products)
        {
            _data = products.ToDictionary(p => p.Code, p => new ProductItemsCounter(p.PriceCalculator));
        }

        public void Scan(string productCode)
        {
            if (!_data.ContainsKey(productCode))
            {
                throw new ArgumentException("Unknown product code");
            }

            _data[productCode].AddItem();
        }

        public decimal CalculateTotal()
        {
            return DoCalculateTotal();
        }

        public decimal CalculateTotal(DiscountCard discountCard)
        {
            decimal discountRate = discountCard.DiscountPercent / 100.0M;
            discountCard.AddTotal(DoCalculateTotal());
            return DoCalculateTotal(discountRate);
        }


        private decimal DoCalculateTotal(decimal discountRate = 0)
        {
            return _data.Aggregate(0.0M, (a, pr) => a + pr.Value.GetTotalPrice(discountRate));
        }
    }
}
