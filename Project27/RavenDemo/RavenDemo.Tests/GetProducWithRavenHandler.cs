using System;
using NUnit.Framework;
using ProductLibrary;
using ProductLibrary.ProductFactory;
using RavenDemo.Classes.ProductFactory;

namespace RavenDemo.Tests
{
    [TestFixture]
    public class GetProducWithRavenHandler
    {
        private readonly ProductHelper _productHelper = null;

        private readonly string _productName = "TestProduct";

        public GetProducWithRavenHandler()
        {
            _productHelper = new ProductHelper(new RavenHandler());

            var testProduct = new Product { ProductName = _productName };
            _productHelper.AddProduct(testProduct);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetProductWithNull()
        {
            _productHelper.GetProduct(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetProductWithEmpty()
        {
            _productHelper.GetProduct(string.Empty);
        }

        [Test]
        public void GetProductInvalid()
        {
            Assert.IsNull(_productHelper.GetProduct("ewrhjehjkhrjke"));
        }
    }
}
