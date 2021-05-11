using System;
using System.IO;
using System.Text;

namespace SiteMonitoring
{
    /// <summary>
    /// Logger class writes to the log file if the site being checked is available.
    /// </summary>
    public class Logger : InterfaceILogger.InterfaceILogger
    {
        public string Path { get; private set; }

        /// <summary>
        /// Public constructor initialize field Path of class Logger.
        /// </summary>
        /// <param name="path"> Value for filed Path. </param>
        public Logger (string path)
        {
            Path = path;
        }

        /// <summary>
        /// WriteMessage method writes to the log file if the site is available.
        /// </summary>
        /// <param name="message"> Text for write. </param>
        public void WriteMessage(string message)
        {
            using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
            {
                sw.WriteLine($" { DateTime.Now.ToString("HH:mm:ss tt")}  {message}");
            }
        }
    }
}
