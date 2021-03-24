using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceIListener
{
  public enum LogLevel
    {
        Trace,
        Info,
        Warning,
        Error
    }
    public interface IListener
    {      
        string Source { get;  set; }
        LogLevel Loglevel { get; set; }
        void WriteMessage(string str, LogLevel InputlogLevel);
        void SetSource(string pathOrSource);
    }
}
