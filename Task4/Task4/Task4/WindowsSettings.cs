namespace Task4
{
   public class WindowsSettings
    {
       public UserSettings UserSetting { get; private set; }
       public string Title { get; private set; }

        public WindowsSettings (UserSettings UserSetting, string title)
        {
            this.UserSetting = UserSetting;
            this.Title = title;
        }
    }
}
