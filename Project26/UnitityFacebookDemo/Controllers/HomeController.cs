using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitityFacebookDemo.Classes.SocialMediaConnector;
using UnitityFacebookDemo.Models;

namespace UnitityFacebookDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ISocialMediaConnector _socialMediaConnector;

        public HomeController(ISocialMediaConnector socialMediaConnector)
        {
            if (socialMediaConnector == null)
            {
                throw new ArgumentException();
            }

            _socialMediaConnector = socialMediaConnector;
        }

        public ActionResult Index(string UserName)
        {
            SocialDisplayModel socialDisplayModel = null;

            try
            {
                socialDisplayModel = new SocialDisplayModel();
                ViewBag.Message = "Let's Get  Social.";
                socialDisplayModel.UserInformation = _socialMediaConnector.GetUserInformation(UserName);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return View(socialDisplayModel);
        }
    }
}
