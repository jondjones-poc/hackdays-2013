using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Linq;

namespace ProductLibrary.ProductFactory
{
    public class RavenHandler : IProductHandler
    {
        private readonly IDocumentStore _store = null;

        public RavenHandler()
        {
             _store = new EmbeddableDocumentStore()
            {
                Configuration =
                    {
                        RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true,
                        RunInMemory = true,
                    }
            };

            _store.Initialize();
        }

        public List<Product> GetProducts(string name)
        {
            var product = _store.OpenSession().Query<Product>().Where(x => x.ProductName == name).ToList();
           return product;
        }

        public bool DoesProductExisit(string name)
        {

                return _store.OpenSession().Query<Product>().Any(x => x.ProductName == name);
        }

        public bool CreateProduct(Product product)
        {
            var success = false;

            try
            {
                if (!DoesProductExisit(product.ProductName))
                {
                    using (var session = _store.OpenSession())
                    {
                        session.Store(product);
                        session.SaveChanges();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
        }
    }
}
