using SocialDisplay.Classes.POCO;
using System.Linq;

namespace SocialDisplay.Classes.SocialMediaConnectors
{
    public interface  ISocialMediaConnector 
    {
        IQueryable<DisplayItem> GetSocialInfomation(string name);

    }
}