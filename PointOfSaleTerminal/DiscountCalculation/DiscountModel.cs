using System;

namespace PointOfSaleTerminal.DiscountCalculation
{
    public struct DiscountModel
    {
        public DiscountModel(decimal amount, int discountPercent)
        {
            Amount = amount;
            DiscountPercent = discountPercent;
        }

        public decimal Amount { get; set; }
        public int DiscountPercent { get; set; }
    }
}
