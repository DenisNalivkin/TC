using System;
using System.IO;
using System.Text;

namespace ReflectionJsonSettingsSiteMonitoring
{
    public class Logger : InterfaceILogger.InterfaceILogger
    {
        public string Path { get; private set; } 

        public Logger (string path)
        {
            Path = path;
        }

        public  void WriteMessage(string message)
        {
            using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
            {
                sw.WriteLine($" { DateTime.Now.ToString("HH:mm:ss tt")}  {message}");
            }
        }
    }
}
