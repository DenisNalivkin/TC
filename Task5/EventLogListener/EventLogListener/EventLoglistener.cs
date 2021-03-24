using System;
using System.Diagnostics;
using InterfaceIListener;

namespace EventLogListener
{
    public class EventLogListener: IListener
    {
        public string Source { get;  set; }
        public LogLevel Loglevel { get; set; }
        public EventLogListener(string path)
        {
            Source = path;
        }
        public EventLogListener()
        {
            
        }
        public void WriteMessage(string message, LogLevel inputlogLevel)
        {
            if (inputlogLevel >= this.Loglevel)
            {
             
                if (!EventLog.SourceExists("EventLogListener"))
                {
                    EventLog.CreateEventSource("EventLogListener", "NewLog");
                }
                EventLog myLog = new EventLog();
                myLog.Source = Source;
                myLog.WriteEntry($"{inputlogLevel} {DateTime.Now.ToString("HH:mm:ss tt")}  {message}");            
            }          
        }
        public void SetSource(string pathOrSource)
        {
            Source = pathOrSource;
        }
    }
}
