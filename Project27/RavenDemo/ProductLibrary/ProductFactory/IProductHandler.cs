using System.Collections.Generic;

namespace ProductLibrary.ProductFactory
{
    public interface IProductHandler
    {
        List<Product> GetProducts(string name);

        bool CreateProduct(Product product);
    }
}
