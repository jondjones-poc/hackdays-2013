using SocialDisplay.Classes.POCO;
using SocialDisplay.Classes.SocialMediaConnectors;
using SocialDisplay.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;

namespace SocialDisplay.Classes
{
    public static class SocialMediaFactory
    {
        public static ISocialMediaConnector GetSocialMediaConnector(SocialMediaTypes socialMediaType)
        {
            return ObjectFactory.GetNamedInstance<ISocialMediaConnector>(socialMediaType.ToString());
        }
    }
}