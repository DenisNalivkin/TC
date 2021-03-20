using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceIListener
{
  public enum LogLevel
    {        
        Info,
        Warning,
        Error
    }
    public interface IListener
    {
        void WriteMessage(string str, LogLevel InputlogLevel);

        void SetPathOrSource(string pathOrSource);
        LogLevel Loglevel { get; set; }
    }
}
