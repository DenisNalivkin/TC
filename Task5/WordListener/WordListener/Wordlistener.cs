using System;
using InterfaceIListener;
using Microsoft.Office.Interop.Word;

namespace WordListener
{
    public class Wordlistener:IListener
    {
        public string Path { get; set; }
        public LogLevel Loglevel { get; set; }

        public Wordlistener(string path, LogLevel logLevel)
        {
            Path = path;
            Loglevel = logLevel;
        }

        public Wordlistener()
        {
           
        }

        public void WriteMessage(string message, LogLevel inputlogLevel)
        {
            Application app = new Application();
            Document doc = app.Documents.Open(Path);
            if( inputlogLevel >= this.Loglevel)
            {
                doc.Content.Text += inputlogLevel + " " + DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss tt") + "  " + message;
                app.Visible = true;
                doc.Save();               
            }             
        }

        public void SetPathOrSource(string pathOrSource)
        {
            Path = pathOrSource;
        }
    }
}
