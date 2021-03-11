using System;
using System.Collections.Generic;
using RavenDemo.Classes.ProductFactory;

namespace ProductLibrary.ProductFactory
{
    public class TestHandler : IProductHandler
    {
        public Product GetProduct(string name)
        {
            Product product = null;

            switch(name)
            {
                case "TestProduct":
                    product = new Product {ProductName = "TestProduct"};
                    break;
            }

            return product;
        }


        public bool CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
