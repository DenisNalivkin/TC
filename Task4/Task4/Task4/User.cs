using System;

namespace Task4
{/// <summary>
 /// User class stores the user name as well as data describing the position of the main and help windows on the screen.
 /// </summary>
    public class User
    {
        public string Login { get; private set; }
        public UserSettings MainSettings { get; private set; }
        public UserSettings HelpSettings { get; private set; }

        /// <summary>
        /// Public constructor initializing the fields of the User class object.
        /// </summary>
        /// <param name="Logins"> Value for field Login. </param>
        public User(string Logins)
        {
            this.Login = Logins;
            this.MainSettings = new UserSettings();
            this.HelpSettings = new UserSettings();
        }
        /// <summary>
        /// Indexator retrieves property by input string.
        /// </summary>
        /// <param name="str"> Value to get the property. </param>
        /// <returns> Property if input string is correct, otherwise throwing exception.  </returns>
        public UserSettings this[string str]
        {
            get
            {
                if ( str.ToLower() == "main" )
                {
                    return MainSettings;
                }
                else if ( str.ToLower() == "help" )
                {
                    return HelpSettings;
                }
                else
                {
                    throw new ArgumentException("You wrote incorrect setting name.");
                }

            }

            set
            {
                if ( str.ToLower() == "main" )
                {
                    MainSettings = value;
                }
                else if ( str.ToLower() == "help" )
                {
                    HelpSettings = value;
                }
                else
                {
                    throw new ArgumentException("You wrote incorrect setting name.");
                }
            }
        }
    }
}
