using System;

namespace Task4
{
    public class User
    {
        public string Name { get; private set; }
        public WindowsSettings MainWin { get; private set; }
        public WindowsSettings HelpWin { get; private set; }

        public User(string name, WindowsSettings main, WindowsSettings help)
        {
            this.Name = name;
            this.MainWin = main;
            this.HelpWin = help;
        }      
    }
}
