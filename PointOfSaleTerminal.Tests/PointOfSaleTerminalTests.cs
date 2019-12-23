using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSaleTerminal.Tests
{
    public class PointOfSaleTerminalTests
    {

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

        private void ScanStringAsChars(Terminal terminal, string productCodes)
        {
            foreach (char ch in productCodes)
            {
                terminal.Scan(ch.ToString());
            }
        }
    }
}
