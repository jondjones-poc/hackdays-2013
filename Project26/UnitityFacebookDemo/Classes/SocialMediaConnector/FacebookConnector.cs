using System;
using Facebook;

namespace UnitityFacebookDemo.Classes.SocialMediaConnector
{
    public class FacebookConnector : ISocialMediaConnector
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserInformation GetUserInformation(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(); 
            }

            UserInformation facebookContent = null;

            try
            {
                var client = new FacebookClient();
                dynamic resultsFromFacebook = client.Get(name);
                facebookContent = ConvertToDisplayItem(resultsFromFacebook);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return facebookContent;
        }

        private UserInformation ConvertToDisplayItem(dynamic resultsFromFacebook)
        {
            var name = string.Format("{0} {1}", resultsFromFacebook.first_name, resultsFromFacebook.last_name);
            return new UserInformation(name, resultsFromFacebook.username, resultsFromFacebook.link);
        }
    }
}