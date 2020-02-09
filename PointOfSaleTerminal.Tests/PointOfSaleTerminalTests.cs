using System;
using System.Collections.Generic;
using PointOfSaleTerminal.DiscountCalculation;
using Xunit;

namespace PointOfSaleTerminal.Tests
{
    public class PointOfSaleTerminalTests
    {

        private const char DefaultProductCode = 'b';

        [Theory]
        [InlineData("", 0.0)]
        [InlineData("AAA", 3.0)]
        [InlineData("ABCDABA", 13.25)]
        [InlineData("CCCCCCC", 6.0)]
        [InlineData("ABCD", 7.25)]
        public void ScanProductsSequence_WithDefaultPricesSet_CorrectTotalValue(string productCodes, decimal expectedResult)
        {

            ProductsPriceSetBuilder productsPriceSetBuilder = new ProductsPriceSetBuilder();
            productsPriceSetBuilder.AddProduct("A", 1.25M, 3, 3.0M);
            productsPriceSetBuilder.AddProduct("B", 4.25M);
            productsPriceSetBuilder.AddProduct("C", 1.0M, 6, 5.0M);
            productsPriceSetBuilder.AddProduct("D", 0.75M);

            IEnumerable<Product> products = productsPriceSetBuilder.GetAllProducts();

            var terminal = new Terminal(products);

            ScanStringAsChars(terminal, productCodes);

            Assert.Equal(expectedResult, terminal.CalculateTotal());
        }

        [Fact]
        public void ScanNonExistingProduct_WithEmptyPricesSet_ExceptionThrown()
        {
            var terminal = new Terminal(new Product[0]);

            Assert.Throws<ArgumentException>(() => terminal.Scan("A"));
        }

        [Theory]
        [InlineData(1, 990.0)]
        [InlineData(2, 970.0)]
        [InlineData(5, 950.0)]
        [InlineData(10, 930.0)]
        public void DiscountRateChanges_WithDefaultDiscountCard_CorrectTotalValue(int productsCount, decimal expectedResult)
        {
            var discountCard = CreateDefaultDiscountCard();

            ScanItems(productsCount, discountCard);
            decimal actualResult = ScanItems(1, discountCard);

            Assert.Equal(expectedResult, actualResult);
        }


        private decimal ScanItems(int count, DiscountCard discountCard)
        {
            var terminal = new Terminal(new ProductsPriceSetBuilder().AddProduct(DefaultProductCode.ToString(), 1000.0M).ToArray());
            ScanStringAsChars(terminal, new string(DefaultProductCode, count));
            return terminal.CalculateTotal(discountCard);
        }

        private DiscountCard CreateDefaultDiscountCard()
        {
            return new DiscountCard(new[]
            {
                new DiscountModel(9999.0M, 7),
                new DiscountModel(2000.0M, 3),
                new DiscountModel(5000.0M, 5),
                new DiscountModel(1000.0M, 1)
            });
        }

        private void ScanStringAsChars(Terminal terminal, string productCodes)
        {
            foreach (char ch in productCodes)
            {
                terminal.Scan(ch.ToString());
            }
        }
    }
}
