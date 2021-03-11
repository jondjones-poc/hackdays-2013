using System;
using System.Collections.Generic;

namespace ProductLibrary.ProductFactory
{
    public class TestHandler : IProductHandler
    {
        public List<Product> GetProducts(string name)
        {
            Product product = null;

            switch(name)
            {
                case "TestProduct":
                    product = new Product {ProductName = "TestProduct"};
                    break;
            }

            return null;
        }


        public bool CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
