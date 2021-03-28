using Newtonsoft.Json;

namespace SiteMonitoring
{
    class ReflectionJsonSettingsSiteMonitoring
    {
        [JsonProperty("WebsiteMonitoringSettings")]
        public SettingsWebSiteMonitoring.SettingsWebSiteMonitoring [] _WebsiteMonitoringSettings { get; private set; }     
    }
}
