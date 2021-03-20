using System;
using System.Diagnostics;
using InterfaceIListener;

namespace EventLogListener
{
    public class EventLoglistener: IListener
    {
        public string Source { get; set; }
        public LogLevel Loglevel { get; set; }

        public EventLoglistener(string path)
        {
            Source = path;
        }
        public EventLoglistener()
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

        public void SetPathOrSource(string pathOrSource)
        {
            Source = pathOrSource;
        }
    }
}
