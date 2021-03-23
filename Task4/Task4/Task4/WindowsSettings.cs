namespace Task4
{/// <summary>
 /// WindowsSettings class stores users settings determining the position of the window on the screen.
 /// </summary>
    public class WindowsSettings
    {
        public string Title { get; private set; }
        public int? Top { get; private set; }
        public int? Left { get; private set; }
        public int? Width { get; private set; }
        public int? Height { get; private set; }

        /// <summary>
        /// IsSettingsCorrect method check the user's settings.
        /// </summary>
        /// <returns> Will return true if the configuration contains the settings for a window named main, and for that window there are all four nested elements(top, left, width, height)  or the config does not contain settings for a window named main. Otherwise will return false. </returns>
        public  bool IsSettingsCorrect()
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
        /// <param name="title"> Value for filed Title.</param>
        /// <param name="top"> Value for filed Top. </param>
        /// <param name="left">  Value for filed Left. </param>
        /// <param name="width">  Value for filed Width. </param>
        /// <param name="height"> Value for filed Height. </param>
        public WindowsSettings (string title, int? top, int? left, int? width, int? height)
        {           
            this.Title = title;
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;           
        }      
    }
}
