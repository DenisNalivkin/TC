using Newtonsoft.Json;

namespace SiteMonitoring
{
    /// <summary>
    /// The ReflectionJsonSettingsSiteMonitoring class stores an array of objects with sites and their settings for checking.
    /// </summary>
    class ReflectionJsonSettingsSiteMonitoring
    {
        [JsonProperty("WebsiteMonitoringSettings")]
        public SettingsWebSiteMonitoring.SettingsWebSiteMonitoring [] _WebsiteMonitoringSettings { get; private set; }      
    }
}
