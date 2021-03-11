using System;
using NUnit.Framework;
using UnitityFacebookDemo.Classes.SocialMediaConnector;

namespace UnitityFacebookDemo.Tests
{
    [TestFixture]
    public class SocialMediaConnectorTests
    {
        private readonly string _validUserName = "jondjones";

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNull()
        {
            var fb = new FacebookConnector();
            fb.GetUserInformation(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyString()
        {
            var fb = new FacebookConnector();
            fb.GetUserInformation(string.Empty);
        }

        [Test]
        public void TestValidUser()
        {
            var fb = new FacebookConnector();
            Assert.IsNotNull(fb.GetUserInformation(_validUserName));
        }

        [Test]
        public void DoeInheritFromInterface()
        {
            var fb = new FacebookConnector();
            Assert.IsTrue(fb is ISocialMediaConnector);
        }

        [Test]
        public void TestInvalidChacters()
        {
            var fb = new FacebookConnector();
            Assert.IsNull(fb.GetUserInformation("£$%^!&*(&*(&()*_"));
        }
    }
}
