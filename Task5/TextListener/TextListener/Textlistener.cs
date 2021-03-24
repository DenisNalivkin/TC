using System;
using System.IO;
using System.Text;
using InterfaceIListener;

namespace TextListener
{
    public class TextListener:IListener
    {
        public string Source { get; set; }
        public LogLevel Loglevel { get; set; }

        public TextListener(string source)
        {
            Source = source;
        }
        public TextListener()
        {
           
        }
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

        public void SetSource(string source)
        {
            this.Source = source;
        }
    }
}
