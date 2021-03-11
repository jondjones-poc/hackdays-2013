using System;
using System.Web.Mvc;
using RavenDemo.Classes.ProductFactory;
using RavenDemo.Models;

namespace RavenDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IProductHandler _products;

        public HomeController(IProductHandler products)
        {
            if (products == null)
            {
                throw new ArgumentException("products");
            }

            _products = products;
        }

        public ActionResult Index(string productName)
        {
            RavenDemoModel model = null;

            try
            {
                model = new RavenDemoModel();
                ViewBag.Message = "Let's Get  Social.";

                if (!string.IsNullOrEmpty(productName))
                {
                    var product = new Product {Id = productName, ProductName = productName};
                    _products.CreateProduct(product);
                }

                model.Products = _products.GetProducts();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return View(model);
        }
    }
}
