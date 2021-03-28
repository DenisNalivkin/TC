using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Threading;
using System.Net.Mail;

namespace SiteMonitoring
{
    public class WebsiteMonitoring
    {
        public string JsonPath { get; private set; }
        public string PathLog { get; private set; }
        public List<SettingsWebSiteMonitoring.SettingsWebSiteMonitoring> ListWebSiteSettings { get; private set; }
        public Logger Logger { get; private set; }
        private object Locker;
        private bool ConfigChanged;
        private bool ConfigDeleted;
        private FileSystemWatcher fileSystemWatcher;

        public WebsiteMonitoring(string path, string pathLog)
        {
            JsonPath = path;
            PathLog = pathLog;
            ListWebSiteSettings = new List<SettingsWebSiteMonitoring.SettingsWebSiteMonitoring>();
            Logger = new Logger(PathLog);
            ParseConfig(JsonPath);
            Locker = new object();
            ConfigChanged = false;
            ConfigDeleted = false;
            InitializeFileSystemWatcher();
        }
   
        private void ParseConfig(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonString = File.ReadAllText(path);
                ReflectionJsonSettingsSiteMonitoring WebSites = JsonConvert.DeserializeObject<ReflectionJsonSettingsSiteMonitoring>(jsonString);
                for (int i = 0; i < WebSites._WebsiteMonitoringSettings.Length; i++)
                {
                    ListWebSiteSettings.Add(new SettingsWebSiteMonitoring.SettingsWebSiteMonitoring(WebSites._WebsiteMonitoringSettings[i].IntervalBetweenChecksSeconds, WebSites._WebsiteMonitoringSettings[i].MaxExpectedServerResponseTimeSeconds,
                     WebSites._WebsiteMonitoringSettings[i].UrlSiteForCheck, WebSites._WebsiteMonitoringSettings[i].DataAdministrator));
                }
            }
        }

        public void CheckUrl(object obj)
        {         
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            int leadTime = 0;
            Action method = null;
            Task task = null;
            Thread threadWebSite = null;           
            Dictionary<string, Thread> threadsSitesDict = new Dictionary<string, Thread>();
            List<string> keys = new List<string>();

            foreach (var webSite in ListWebSiteSettings)
            {
                threadsSitesDict[webSite.UrlSiteForCheck] = null;
            }

            while (true)
            {
                if(ConfigChanged)
                {
                    ParseChangedConfig();
                    ConfigChanged = false;
                    UpdateThreadsSitesDict(threadsSitesDict);
                }

                if(ConfigDeleted)
                {
                    break;
                }
                                            
                foreach (var webSite in ListWebSiteSettings)
                {
                    if (threadsSitesDict[webSite.UrlSiteForCheck] == null)
                    {
                        threadWebSite = new Thread(new ParameterizedThreadStart(StartCheckingUrl));       
                        threadsSitesDict[webSite.UrlSiteForCheck] = threadWebSite;
                        threadWebSite.Start(webSite);
                    }               
                }
                keys = new List<string>(threadsSitesDict.Keys);
                foreach ( var key in keys)
                {
                    if(!threadsSitesDict[key].IsAlive)
                    {
                        threadsSitesDict[key] = null;
                    }
                }                                     
            }
        }
      
        private async void SendMessageAdmin(SettingsWebSiteMonitoring.SettingsWebSiteMonitoring webSite, string message)
        {
            MailAddress from = new MailAddress("denisnalivkin1992@gmail.com");
            MailAddress to = new MailAddress(webSite.DataAdministrator.adminEmailAddress);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Notification.";
            m.Body = message;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("denisnalivkin1992@gmail.com", "");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }

        private void StartCheckingUrl(object obj)
        {
            SettingsWebSiteMonitoring.SettingsWebSiteMonitoring webSite = (SettingsWebSiteMonitoring.SettingsWebSiteMonitoring)obj;
            try
            {        
                DateTime start = DateTime.Now;
                WebClient wc = new WebClient();
                string HTMLSource = wc.DownloadString(webSite.UrlSiteForCheck);
                DateTime finish = DateTime.Now;
                int leadTime = (int)finish.Second - (int)start.Second;
                string message = "Attention! Method CheckUrl has checked ";
                if (leadTime < webSite.MaxExpectedServerResponseTimeSeconds)
                {                   
                lock (Locker) 
                {
                    Logger.WriteMessage($"WebSite {webSite.DataAdministrator.siteName} with addres {webSite.UrlSiteForCheck} has been opened successfully.");                           
                }                                     
                }
                else
                {                                
                    SendMessageAdmin(webSite, message + $"{webSite.DataAdministrator.siteName} webSite with addres {webSite.UrlSiteForCheck}. This webSite is not available." );                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(webSite.IntervalBetweenChecksSeconds * 1000);
        }

        private void InitializeFileSystemWatcher ()
        {
            fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName((JsonPath)));
            fileSystemWatcher.Deleted += Watcher_Deleted;
            fileSystemWatcher.Changed += Watcher_Changed;
            fileSystemWatcher.Filter = Path.GetFileName((JsonPath));
            fileSystemWatcher.EnableRaisingEvents = true;         
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            ConfigChanged = true;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            ConfigDeleted = true;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void ParseChangedConfig ()
        {
            bool configIsAvailable = false;
            while (!configIsAvailable)
            {
                try
                {
                    ListWebSiteSettings.Clear();
                    ParseConfig(JsonPath);
                    configIsAvailable = true;
                }
                catch (Exception)
                {

                }              
            }
        }

        private void UpdateThreadsSitesDict (Dictionary<string, Thread> threadsSitesDict)
        {
            if(ListWebSiteSettings.Count > threadsSitesDict.Count)
            {
                foreach (var webSite in ListWebSiteSettings)
                {
                    if (!threadsSitesDict.ContainsKey(webSite.UrlSiteForCheck))
                    {
                        threadsSitesDict[webSite.UrlSiteForCheck] = null;
                    }
                }
            }
            if(ListWebSiteSettings.Count < threadsSitesDict.Count)
            {
                SettingsWebSiteMonitoring.SettingsWebSiteMonitoring result = null;
                List<string> keys =  new List<string>(threadsSitesDict.Keys);
                foreach (var webSite in keys)
                {
                    result = ListWebSiteSettings.Find( (_webSite) => _webSite.UrlSiteForCheck == webSite);
                    if(result == null)
                    {
                        threadsSitesDict.Remove(webSite);
                    }                  
                }
            }                  
        }
    }
}



        
    
