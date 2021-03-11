using System.Collections.Generic;
using ProductLibrary;

namespace RavenDemo.Classes.ProductFactory
{
    public interface IProductHandler
    {
        Product GetProduct(string name);

        List<Product> GetProducts();

        bool CreateProduct(Product product);
    }
}
