namespace UnitityFacebookDemo.Classes.SocialMediaConnector
{
    public class UserInformation
    {
        public UserInformation(string name, string username, string url)
        {
            Name = name;
            Username = username;
            Url = url;
        }

        public string Name { get; internal set; }

        public string Username { get; internal set; }

        public string Url { get; internal set; }
    }
}
