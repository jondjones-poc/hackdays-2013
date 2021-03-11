using SocialDisplay.Classes.POCO;
using System;
using System.Linq;
using TweetSharp;

namespace SocialDisplay.Classes.SocialMediaConnectors
{
    public class TwitterConnector : ISocialMediaConnector
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SocialMediaName = "Twitter";

        public IQueryable<DisplayItem> GetSocialInfomation(string name)
        {
            IQueryable<DisplayItem> items = null;

            try
            {
                var twitterClientInfo = new TwitterClientInfo();
                twitterClientInfo.ConsumerKey = SettingsHelper.ConsumerKey;
                twitterClientInfo.ConsumerSecret = SettingsHelper.ConsumerSecret; 

                var twitterService = new TwitterService(twitterClientInfo);
                twitterService.AuthenticateWith(SettingsHelper.AccessToken, SettingsHelper.AccessSecret);
                var searchOptions = new SearchOptions
                {
                    Q = name,  
                };

                var searchResults = twitterService.Search(searchOptions);
                items = searchResults.Statuses.Select(x => ConvertToDataItem(x)).AsQueryable();
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }

            return items;
        }

        private DisplayItem ConvertToDataItem(TwitterStatus status)
        {
            return new DisplayItem
            {
                MediaPlatform = SocialMediaName,
                Data = status.TextAsHtml,
                Username = status.User.ScreenName,
                Url = status.User.Url
            };
        }
    }

}