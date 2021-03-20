using System;
using System.IO;
using System.Text;
using InterfaceIListener;

namespace TextListener
{
    public class Textlistener:IListener
    {
        public string Path { get; set; }
        public LogLevel Loglevel { get; set; }

        public Textlistener(string path)
        {
            Path = path;
        }

        public Textlistener()
        {

        }

        public void WriteMessage(string message, LogLevel inputlogLevel )
        {
            using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
            {
                if ((inputlogLevel >= this.Loglevel))
                {
                    sw.WriteLine($"{inputlogLevel}  {DateTime.Now.ToString("HH:mm:ss tt")}  {message}");                  
                }                            
            }
        }

        public void SetPathOrSource(string pathOrSource)
        {
            Path = pathOrSource;
        }
    }
}
