using System;
namespace Task4
{
   public class User
    {
        public string Login { get;  set; }
        public string MainSettings { get;  set; }
        public string HelpSettings { get;  set; }
        public bool сorrectСonfiguration { get; set; }

        public User (string Logins, string MainSettings, string HelpSettings)
        {
            this.Login = Logins;
            this.MainSettings = MainSettings;
            this.HelpSettings = HelpSettings;
            this.сorrectСonfiguration = false;
        }

        public string this[string str]
        {
            get
            {
                if( str.ToLower() == "main" )
                {
                    return MainSettings;
                }
                else  if( str.ToLower() == "help" )
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
                if (str.ToLower() == "main")
                {
                    MainSettings = value; 
                }
              else if (str.ToLower() == "help")
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
