using System;
using System.IO;
using System.Text;
using InterfaceIListener;

namespace TextListener
{
    /// <summary>
    ///TextListener class writes messages to a txt file.
    /// </summary>
    public class TextListener:IListener
    {
        public string Source { get; set; }
        public LogLevel Loglevel { get; set; }

        /// <summary>
        /// Public constructor TextListener initialize Source field.
        /// </summary>
        /// <param name="source"> Value for field source. </param>
        public TextListener(string source)
        {
            Source = source;
        }

        /// <summary>
        /// WriteMessage method captures message to a txt file. 
        /// </summary>
        /// <param name="message"> Text for write. </param>
        /// <param name="inputlogLevel"> Loglevel for event. </param>
        public void WriteMessage(string message, LogLevel inputlogLevel )
        {
            using (StreamWriter sw = new StreamWriter(Source, true, Encoding.Default))
            {
                if ((inputlogLevel >= this.Loglevel))
                {
                    sw.WriteLine($"{inputlogLevel}  {DateTime.Now.ToString("HH:mm:ss tt")}  {message}");                  
                }                            
            }
        }
    }
}
