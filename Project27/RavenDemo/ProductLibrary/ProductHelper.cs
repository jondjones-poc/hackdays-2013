using System;
using System.Collections.Generic;
using System.Linq;
using ProductLibrary.ProductFactory;

namespace ProductLibrary
{
    public class ProductHelper
    {
        private readonly IProductHandler _handler;

        public ProductHelper(IProductHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentException();
            }

            _handler = handler;
        }


        public List<Product> GetProduct(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
               throw  new ArgumentException();
            }

            return _handler.GetProducts(productName);
        }

        public bool AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException();
            }

            return _handler.CreateProduct(product);
        }
    }
}
