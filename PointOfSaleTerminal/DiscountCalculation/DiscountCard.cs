using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace PointOfSaleTerminal.DiscountCalculation
{
    public class DiscountCard
    {
        private readonly List<DiscountModel> _points;
        private decimal _total = 0.0M;

        public DiscountCard(IEnumerable<DiscountModel> discountPoints)
        {
            _points = discountPoints.OrderByDescending(x => x.DiscountPercent).ToList();
        }

        public int DiscountPercent
        {
            get
            {
                return _points.First(x => x.Amount <= _total).DiscountPercent;
            }
            
        }

        public void AddTotal(decimal sum)
        {
            _total += sum;
        }
    }
}
