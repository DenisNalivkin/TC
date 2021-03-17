namespace Task4
{/// <summary>
/// UserSettings class stores values ​​for determining the position of the window on the screen.
/// </summary>
    public class UserSettings
    {
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
          if( Top != null && Left != null && Width != null && Height != null || Top == null && Left == null && Width == null && Height == null )
            {
                result = true;
            }
            return result;         
        }       
    }
}
