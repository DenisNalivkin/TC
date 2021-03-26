using Newtonsoft.Json;

namespace SiteAdministrator
{
    public class SiteAdministrator
    {
        [JsonProperty("administratorName")]
        public string administratorName { get; private set; }
        [JsonProperty("siteName")]
        public string siteName { get; private set; }
        [JsonProperty("websiteAddress")]
        public string websiteAddress { get; private set; }
        [JsonProperty("adminEmailAddress")]
        public string adminEmailAddress { get; private set; }

        public  SiteAdministrator(string administratorName,  string siteName, string websiteAddress, string adminEmailAddress)
        {
            this.administratorName = administratorName;
            this.siteName = siteName;
            this.websiteAddress = websiteAddress;
            this.adminEmailAddress = adminEmailAddress;
        }
    }
}
