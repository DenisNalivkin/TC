namespace Task4
{/// <summary>
 /// WindowsSettings class stores users settings determining the position of the window on the screen.
 /// </summary>
    public class WindowsSettings
    {
       public UserSettings UserSetting { get; private set; }
       public string Title { get; private set; }

        /// <summary>
        /// The public constructor initializes the fields of the WindowsSettings class object.
        /// </summary>
        /// <param name="UserSetting"> Value for filed UserSetting. </param>
        /// <param name="title">  Value for filed Title. </param>
        public WindowsSettings (UserSettings UserSetting, string title)
        {
            this.UserSetting = UserSetting;
            this.Title = title;
        }
    }
}
