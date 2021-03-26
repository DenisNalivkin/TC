using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Threading;
using System.Net.Mail;

namespace ReflectionJsonSettingsSiteMonitoring
{
    public class WebsiteMonitoring
    {
        public static string JsonPath { get; private set; }
        public static string PathLog { get; private set; }
        public List<SettingsWebSiteMonitoring.SettingsWebSiteMonitoring> _WebSiteSettings { get; private set; }
        public static Logger Logger { get; private set; }
        private static object Locker;
        private static object LockerLoggerFileSystemWatcher;

        public WebsiteMonitoring(string path, string pathLog)
        {
            JsonPath = path;
            PathLog = pathLog;
            _WebSiteSettings = new List<SettingsWebSiteMonitoring.SettingsWebSiteMonitoring>();
            Logger = new Logger(PathLog);
            ParseConfig(JsonPath);
            Locker = new object();
            LockerLoggerFileSystemWatcher = new object();
        }
   
        private void ParseConfig(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonString = File.ReadAllText(path);
                ReflectionJsonSettingsSiteMonitoring WebSites = JsonConvert.DeserializeObject<ReflectionJsonSettingsSiteMonitoring>(jsonString);
                for (int i = 0; i < WebSites._WebsiteMonitoringSettings.Length; i++)
                {
                    _WebSiteSettings.Add(new SettingsWebSiteMonitoring.SettingsWebSiteMonitoring(WebSites._WebsiteMonitoringSettings[i].IntervalBetweenChecksSeconds, WebSites._WebsiteMonitoringSettings[i].MaxExpectedServerResponseTimeSeconds,
                     WebSites._WebsiteMonitoringSettings[i].AddressPageBeingChecked, WebSites._WebsiteMonitoringSettings[i].DataAdministrator));
                }
            }
        }

        public void CheckUrl(object obj)
        {
            List<SettingsWebSiteMonitoring.SettingsWebSiteMonitoring> _webSiteSettings = (List<SettingsWebSiteMonitoring.SettingsWebSiteMonitoring>)obj;
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            int leadTime = 0;
            Action method = null;
            Task task = null;
            Thread myThread = null;
            Dictionary<string, Thread> threadsDict = new Dictionary<string, Thread>();        
            foreach (var elem in _webSiteSettings)
            {
                threadsDict[elem.DataAdministrator.websiteAddress] = null;
            }
            while (true)
            {
                foreach (var webSite in _webSiteSettings)
                {
                    if (threadsDict[webSite.DataAdministrator.websiteAddress] == null)
                    {
                        myThread = new Thread(new ParameterizedThreadStart(StartCheckingUrl));
        
                        threadsDict[webSite.DataAdministrator.websiteAddress] = myThread;
                        myThread.Start(webSite);
                    }               
                }
                List<string> keys = new List<string>(threadsDict.Keys);
                foreach ( var key in keys)
                {
                    if(!threadsDict[key].IsAlive)
                    {
                        threadsDict[key] = null;
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
            smtp.Credentials = new NetworkCredential("denisnalivkin1992@gmail.com", "1A2b3CNM");
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
                string HTMLSource = wc.DownloadString(webSite.AddressPageBeingChecked);
                DateTime finish = DateTime.Now;
                int leadTime = (int)finish.Second - (int)start.Second;
                string message = "Attention! Method CheckUrl has checked ";
                if (leadTime < webSite.MaxExpectedServerResponseTimeSeconds)
                {                   
                lock (Locker) 
                {
                    Logger.WriteMessage($"WebSite {webSite.DataAdministrator.siteName} with addres {webSite.DataAdministrator.websiteAddress}  has been opened successfully.");                           
                }                                     
                }
                else
                {                                
                    SendMessageAdmin(webSite, message + $"{webSite.DataAdministrator.siteName} webSite with addres {webSite.DataAdministrator.websiteAddress} . This webSite is not available." );                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(webSite.IntervalBetweenChecksSeconds * 1000);
        }
    }
}



        
    
