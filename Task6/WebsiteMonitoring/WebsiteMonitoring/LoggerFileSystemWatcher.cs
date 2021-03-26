using System;
using System.IO;
using System.Threading;

namespace WebsiteMonitoring
{
    public  class LoggerFileSystemWatcher
    {
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        
        public LoggerFileSystemWatcher()
        {
            watcher = new FileSystemWatcher("D:\\Task6");         
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
            watcher.Filter = "ConfigWebSiteMonitoring.json";
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;          
            while(true)
            {
                Thread.Sleep(1000);
            }                  
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }
      
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);
        }
        
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
    
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
      
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "удален";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter("D:\\Task6\\templog.txt", false))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
    }
}

