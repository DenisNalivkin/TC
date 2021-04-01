using Newtonsoft.Json;

namespace SettingsWebSiteMonitoring
{
    /// <summary>
    /// SettingsWebSiteMonitoring class stores data about the site being checked.
    /// </summary>
    public class SettingsWebSiteMonitoring
    {
        [JsonProperty("intervalBetweenChecksSeconds")]
        public int IntervalBetweenChecksSeconds { get; private set; }
        [JsonProperty("maxExpectedServerResponseTimeSeconds")]
        public int MaxExpectedServerResponseTimeSeconds { get; private set; }
        [JsonProperty("addressPageBeingChecked")]
        public string UrlSiteForCheck { get;  private set; }
        [JsonProperty("dataAdministrator")]
        public SiteAdministrator.SiteAdministrator DataAdministrator { get; private set; }

        /// <summary>
        /// Public constructor initialize fields of class SettingsWebSiteMonitoring.
        /// </summary>
        /// <param name="intervalBetweenChecksSeconds"> Value for field intervalBetweenChecksSeconds. </param>
        /// <param name="maxExpectedServerResponseTimeSeconds"> Value for field maxExpectedServerResponseTimeSeconds.</param>
        /// <param name="addressPageBeingChecked"> Value for field addressPageBeingChecked. </param>
        /// <param name="dataAdministrator"> Value for field dataAdministrator.</param>
        public SettingsWebSiteMonitoring(int intervalBetweenChecksSeconds, int maxExpectedServerResponseTimeSeconds, string addressPageBeingChecked, SiteAdministrator.SiteAdministrator dataAdministrator)
        {
            IntervalBetweenChecksSeconds = intervalBetweenChecksSeconds;
            MaxExpectedServerResponseTimeSeconds = maxExpectedServerResponseTimeSeconds;
            UrlSiteForCheck = addressPageBeingChecked;
            DataAdministrator = dataAdministrator;
        }     
    }
}
