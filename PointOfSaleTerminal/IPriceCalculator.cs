namespace PointOfSaleTerminal
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(int productsCount, decimal discountRate);
    }
}