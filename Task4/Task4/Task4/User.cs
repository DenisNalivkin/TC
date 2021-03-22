using System.Collections.Generic;

namespace Task4
{
    /// <summary>
    /// User class stores name and data describing the position of the user's windows on the screen.
    /// </summary>
    public class User
    {
        public string Name { get; private set; }

        public List<WindowsSettings> ListWindowsSettings { get; set; }
       

        /// <summary>
        /// The public constructor initializes the fields of the user class object.
        /// </summary>
        /// <param name="name"> Value for field Name. </param>
        /// <param name="main"> Value for field MainWin. </param>
        /// <param name="help"> Value for field HelpWin. </param>
        public User(string name, WindowsSettings main, WindowsSettings help)
        {
            this.Name = name;
            this.MainWin = main;
            this.HelpWin = help;
        }
    }
}
