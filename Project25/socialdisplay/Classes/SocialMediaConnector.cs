using SocialDisplay.Classes.POCO;
using System;
using System.Linq;
using SocialDisplay.Classes.SocialMediaConnectors;

namespace SocialDisplay.Classes
{
    public class SocialMediaConnector
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ISocialMediaConnector _socialMediaConnector;

        public SocialMediaConnector(ISocialMediaConnector SocialMediaConnector)
        {
            if (SocialMediaConnector == null)
            {
                throw new ArgumentException();
            }

            _socialMediaConnector = SocialMediaConnector;  
        }

        public IQueryable<DisplayItem> GetSocialInfomation(string name)
        {
            IQueryable<DisplayItem> dislayItems = null;

            try
            {
                dislayItems = _socialMediaConnector.GetSocialInfomation(name);
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
            return dislayItems;
        }
    }
}