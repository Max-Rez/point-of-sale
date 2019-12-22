using System;
using System.Collections.Generic;
using System.Text;
using PointOfSaleTerminal.PriceCalculation;

namespace PointOfSaleTerminal
{
    public class ProductsPriceSetBuilder
    {
        private readonly List<Product> products = new List<Product>();

        public List<Product> AddProduct(string productCode, decimal singleProductPrice)
        {
            AddProduct(productCode, new SingleProductPriceCalculalator(singleProductPrice));
            return products;
        }

        public Product[] GetAllProducts()
        {
            return products.ToArray();
        }

        public List<Product> AddProduct(string productCode, decimal singleProductPrice, int productsPerShareCount, decimal specialPrice)
        {
            AddProduct(productCode, new ComplexPriceCalculator(singleProductPrice, productsPerShareCount, specialPrice));
            return products;
        }

        private void AddProduct(string productCode, IPriceCalculator priceCalculator)
        {
            products.Add(new Product(productCode, priceCalculator));
        }

    }
}
