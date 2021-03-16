namespace Task4
{
   public class WindowsSettings
    {
       public User UserSetting { get; private set; }
       public string Title { get; private set; }

        public WindowsSettings (User UserSetting, string title)
        {
            this.UserSetting = UserSetting;
            this.Title = title;
        }
    }
}
