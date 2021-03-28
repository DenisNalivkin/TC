using Newtonsoft.Json;

namespace SettingsWebSiteMonitoring
{
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
       
        public SettingsWebSiteMonitoring(int intervalBetweenChecksSeconds, int maxExpectedServerResponseTimeSeconds, string addressPageBeingChecked, SiteAdministrator.SiteAdministrator dataAdministrator)
        {
            IntervalBetweenChecksSeconds = intervalBetweenChecksSeconds;
            MaxExpectedServerResponseTimeSeconds = maxExpectedServerResponseTimeSeconds;
            UrlSiteForCheck = addressPageBeingChecked;
            DataAdministrator = dataAdministrator;
        }     
    }
}
