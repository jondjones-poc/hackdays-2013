using System;
using NUnit.Framework;
using ProductLibrary;
using ProductLibrary.ProductFactory;

namespace RavenDemo.Tests
{
    [TestFixture]
    public class GetProductTestsWithTestHandler
    {
        private readonly ProductHelper _productHelper = null;

        public GetProductTestsWithTestHandler()
        {
            _productHelper = new ProductHelper(new TestHandler());
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

        [Test]
        public void GetProductValid()
        {
            Assert.IsNotNull(_productHelper.GetProduct("TestProduct"));
        }

        [Test]
        public void GetProductInValid()
        {
            Assert.IsNull(_productHelper.GetProduct("InvalidProduct"));
        }

    }
}
