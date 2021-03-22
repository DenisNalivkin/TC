namespace Task4
{/// <summary>
 /// WindowsSettings class stores users settings determining the position of the window on the screen.
 /// </summary>
    public class WindowsSettings
    {
       public string Title { get; private set; }
        public int? Top { get; set; }
        public int? Left { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        /// <summary>
        /// IsSettingsCorrect method check the user's settings.
        /// </summary>
        /// <returns> Will return true if the configuration contains the settings for a window named main, and for that window there are all four nested elements(top, left, width, height)  or the config does not contain settings for a window named main. Otherwise will return false. </returns>
        public bool IsSettingsCorrect()
        {
            bool result = false;
            if (Top != null && Left != null && Width != null && Height != null || Top == null && Left == null && Width == null && Height == null)
            {
                result = true;
            }
            return result;
        }

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
