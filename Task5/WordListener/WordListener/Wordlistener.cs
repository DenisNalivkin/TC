using System;
using InterfaceIListener;
using Microsoft.Office.Interop.Word;

namespace WordListener
{
    /// <summary>
    /// WordListener class  writes messages to a word-file.
    /// </summary>
    public class WordListener:IListener
    {
        public string Source { get; set; }
        public LogLevel Loglevel { get; set; }

        /// <summary>
        /// Public constructor WordListener initialize Source field.
        /// </summary>
        /// <param name="source"> Value for field source. </param>
        public WordListener(string source)
        {
            Source = source;
        }

        /// <summary>
        /// WriteMessage method captures message to a word-file.
        /// </summary>
        /// <param name="message"> Text for write. </param>
        /// <param name="inputlogLevel"> Loglevel for event. </param>
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
    }
}
