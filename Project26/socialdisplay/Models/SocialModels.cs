using System.Linq;
using SocialDisplay.Classes.POCO;

namespace SocialDisplay.Models
{
    public class SocialModel
    {
        public SocialModel()
        {
            SocialMediaItems = null;
        }

        public IQueryable<DisplayItem> SocialMediaItems { get; set; }

        public string SearchName { get; set; }
    }
}
