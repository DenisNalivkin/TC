using Newtonsoft.Json;

namespace ReflectionJsonSettingsSiteMonitoring
{
    class ReflectionJsonSettingsSiteMonitoring
    {
        [JsonProperty("WebsiteMonitoringSettings")]
        public SettingsWebSiteMonitoring.SettingsWebSiteMonitoring [] _WebsiteMonitoringSettings { get; set; }     
    }
}
