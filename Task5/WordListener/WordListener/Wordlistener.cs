using System;
using InterfaceIListener;
using Microsoft.Office.Interop.Word;

namespace WordListener
{
    public class WordListener:IListener
    {
        public string Source { get; set; }
        public LogLevel Loglevel { get; set; }

        public WordListener(string path, LogLevel logLevel)
        {
            Source = path;
            Loglevel = logLevel;
        }
        public WordListener()
        {

        }

        public void WriteMessage(string message, LogLevel inputlogLevel)
        {
            Application app = new Application();
            Document doc = app.Documents.Open(Source);
            if( inputlogLevel >= this.Loglevel)
            {
                doc.Content.Text += inputlogLevel + " " + DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss tt") + "  " + message;
                app.Visible = true;
                doc.Save();               
            }             
        }

        public void SetSource(string source)
        {
            Source = source;
        }
    }
}
