using System.Collections.Generic;

namespace Task4
{
    /// <summary>
    /// User class stores name and data describing the position of the user's windows on the screen.
    /// </summary>
    public class User
    {
        public string Name { get; private set; }
        public List<WindowsSettings> ListWinSettings { get; private set; }
       
        /// <summary>
        /// The public constructor initializes the fields of the user class object.
        /// </summary>
        /// <param name="name"> Value for field Name. </param>
        public User(string name)
        {          
            this.Name = name;
            ListWinSettings = new List<WindowsSettings>();
        }
    }
}
