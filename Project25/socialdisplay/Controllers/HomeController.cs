using SocialDisplay.Classes;
using SocialDisplay.Classes.POCO;
using System;
using System.Web.Mvc;
using SocialDisplay.Classes.SocialMediaConnectors;
using SocialDisplay.Models;

namespace SocialDisplay.Controllers
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

        public ActionResult Index(string searchName)
        {
            SocialModel socialModel = null;

            try
            {
                socialModel = new SocialModel();
                var restuls = _socialMediaConnector.GetSocialInfomation(searchName);
                socialModel.SocialMediaItems = restuls;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return View(socialModel);
        }
    }
}
