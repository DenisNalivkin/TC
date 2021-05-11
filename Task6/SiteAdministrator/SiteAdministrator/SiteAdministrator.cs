using Newtonsoft.Json;

namespace SiteAdministrator
{
    /// <summary>
    ///  The SiteAdministrator class stores information about the administrator of the site being checked.
    /// </summary>
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

        /// <summary>
        /// Public constructor initialize fields of class SiteAdministrator.
        /// </summary>
        /// <param name="administratorName"> Value for field administratorName. </param>
        /// <param name="siteName"> Value for field siteName. </param>
        /// <param name="websiteAddress"> Value for field websiteAddress. </param>
        /// <param name="adminEmailAddress"> Value for field adminEmailAddress.</param>
        public SiteAdministrator(string administratorName,  string siteName, string websiteAddress, string adminEmailAddress)
        {
            this.administratorName = administratorName;
            this.siteName = siteName;
            this.websiteAddress = websiteAddress;
            this.adminEmailAddress = adminEmailAddress;
        }        
    }
}
