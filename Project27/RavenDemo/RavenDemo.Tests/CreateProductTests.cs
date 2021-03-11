using System;
using NUnit.Framework;
using ProductLibrary;
using ProductLibrary.Helpers;
using ProductLibrary.ProductFactory;
using RavenDemo.Classes.ProductFactory;

namespace RavenDemo.Tests
{
    [TestFixture]
    public class CreateProductTests
    {
        private readonly ProductHelper _productHelper = null;

        public CreateProductTests()
        {
            var raven = new RavenHandler();
            _productHelper = new ProductHelper(raven);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateProductWithNull()
        {
            _productHelper.AddProduct(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateProductWithEmptyString()
        {
            _productHelper.AddProduct(null);
        }

        [Test]
        public void CreateProduct()
        {

            var randomName = Helper.GetRandomName();
            var product = new Product { ProductName = randomName };
            Assert.IsTrue(_productHelper.AddProduct(product));
        }

        [Test]
        public void CreateAndGetProduct()
        {
            var name = Helper.GetRandomName();
            Assert.IsTrue(_productHelper.AddProduct(new Product { Id = name, ProductName = name }));
            Assert.IsTrue(_productHelper.GetProduct(name).ProductName == name);
        }

        [Test]
        public void AddDuplicateProducts()
        {
            var name = Helper.GetRandomName();
            Assert.IsTrue(_productHelper.AddProduct(new Product { Id = name, ProductName = name }));
            Assert.IsFalse(_productHelper.AddProduct(new Product { Id = name, ProductName = name }));
        }



    }

 

}
