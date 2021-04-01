using System;
using System.Diagnostics;
using InterfaceIListener;

namespace EventLogListener
{
    /// <summary>
    ///  EventLogListener class captures message in Windows Event Log.
    /// </summary>
    public class EventLogListener: IListener
    {
        public string Source { get;  set; }
        public LogLevel Loglevel { get; set; }

        /// <summary>
        /// Public constructor EventLogListener initialize field Source.
        /// </summary>
        /// <param name="source"> Value for field source. </param>
        public EventLogListener(string source)
        {
            Source = source;
        }

        /// <summary>
        /// WriteMessage method captures message in Windows Event Log.
        /// </summary>
        /// <param name="message"> Text to write. </param>
        /// <param name="inputlogLevel"> Loglevel for event. </param>
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
    }
}
