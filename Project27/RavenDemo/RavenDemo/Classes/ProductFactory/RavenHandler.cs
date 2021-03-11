using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Raven.Client.Embedded;

namespace RavenDemo.Classes.ProductFactory
{
    public class RavenHandler : IProductHandler
    {
        private readonly IDocumentStore _store;

        public RavenHandler()
        {
            _store = new EmbeddableDocumentStore() {RunInMemory = true}.Initialize();
        }

        public bool CreateProduct(Product product)
        {
            var success = false;

            try
            {
                if (ProductDoesNotExisit(product.ProductName))
                {
                    using (var session = _store.OpenSession())
                    {
                        session.Store(product);
                        session.SaveChanges();
                    }

                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
        }

        public Product GetProduct(string name)
        {
            Product product = null;

            using (var session1 = _store.OpenSession())
            {
                product = session1.Load<Product>(name);
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = null;

            using (var session = _store.OpenSession())
             {
                products = session.Query<Product>().ToList();
             }

             return products;

        }

        public bool ProductDoesNotExisit(string name)
        {
            return GetProduct(name) == null;
        }
    }
}