using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
namespace Task4
{/// <summary>
/// XmlUserParser class reads from an xml document name of user and data describing the position of the window on the screen.
/// </summary>
    public class XmlUserParser
    {
        public XAttribute[] UserNames { get; private set; }
        public List<User> ListUsers { get; private set; }

        /// <summary>
        ///  The public constructor initializes the field of the XmlUserParser class object.
        /// </summary>
        /// <param name="xDoc"> Value for field UserNames. </param>
        public XmlUserParser(XDocument xDoc)
        {
            ListUsers = new List<User>();
            ParseLogins(xDoc);
        }

        private void ParseLogins(XDocument xDoc)
        {
            var nestedElements = xDoc.Root.Elements("login");
            this.UserNames = new XAttribute[nestedElements.Count()];
            var loginFirstAtr = nestedElements.Select((curentLogin) => curentLogin.FirstAttribute);
            ParseWinSettings(xDoc, loginFirstAtr);
        }

        private void ParseWinSettings( XDocument xDoc, IEnumerable<XAttribute> loginFirstAtr)
        {
            for (int i = 0; i < UserNames.Length; i++)
            {
                this.UserNames[i] = loginFirstAtr.ElementAtOrDefault(i);
                var currentLogin = xDoc.Root.Elements("login").Where((login) => login.Attribute("name").Value == (string)UserNames[i]);
                var nestedWinElemCurrentLogin = currentLogin.Elements("window");
                ListUsers.Add(new User(UserNames[i].Value.ToString()));

                foreach (var winElem in nestedWinElemCurrentLogin)
                {
                    string title = (string)winElem.Attribute("title");
                    string topValue = IsNotEmpry(winElem, "top");
                    string leftValue = IsNotEmpry(winElem, "left");
                    string widthValue = IsNotEmpry(winElem, "width");
                    string heightValue = IsNotEmpry(winElem, "height");
                    ListUsers[i].ListWinSettings.Add(new WindowsSettings(title, topValue == null ? null : (int?)int.Parse(topValue), leftValue == null ? null : (int?)int.Parse(leftValue), widthValue == null ? null : (int?)int.Parse(widthValue), heightValue == null ? null : (int?)int.Parse(heightValue)));
                }
            }
        }
        private string IsNotEmpry(XElement winElem, string elemName)
        {
            string value = null;
            try
            {
                value = winElem.Elements(elemName).Select((el) => el.Value).First().ToString();
            }
            catch
            {
                return value;
            }
            return value;
        }

        /// <summary>
        ///  Shows logins with incorrect settings.
        /// </summary>
        public void ShowLoginsIncorrectConfiguration()
        {
            IEnumerable<bool> win = null;
            IEnumerable<bool> amountMain = null;
            List<string> usersIncorrectConfig = new List<string>();
            foreach (var user in ListUsers)
            {
                win = user.ListWinSettings.Select((u) => u.Title == "main");
                amountMain = win.Where((boolValue) => boolValue == true);
                if (amountMain.Count() > 1)
                {
                    usersIncorrectConfig.Add(user.Name);
                    continue;
                }

                for (int i = 0; i < user.ListWinSettings.Count; i++)
                {
                    if (user.ListWinSettings[i].Title == "main")
                    {
                        if (!user.ListWinSettings[i].IsSettingsCorrect())
                        {
                            usersIncorrectConfig.Add(user.Name);
                        }
                    }
                }            
            }
            foreach (var name in usersIncorrectConfig)
            {
                Console.WriteLine(name);
            }
        }
          
        /// <summary>
        /// Shows information about the user and his settings, the location of the windows on the screen.
        /// </summary>
        public void ShowInformationUserSetting()
        {
            foreach (var user in ListUsers)
            {
                Console.WriteLine($"Login: {user.Name}");
                foreach (var WinSetting in user.ListWinSettings)
                {              
                    Console.WriteLine($"{WinSetting.Title}({WinSetting.Top.ConvertingNullableInString()}, {WinSetting.Left.ConvertingNullableInString()}, {WinSetting.Width.ConvertingNullableInString()}, {WinSetting.Height.ConvertingNullableInString()})");
                }
            }      
        }
            
        /// <summary>
        /// Converts the username and settings that determine the location of windows on the screen to json format.
        /// </summary>
        public void ConvertUserSettingsJson()
            {
                JsonSerializer serializer = new JsonSerializer();
                for ( int i = 0; i < ListUsers.Count(); i++ )
                {
                    User newUser = XmlUserParser.ConvertingNullInZero(ListUsers[i]);
                    DirectoryInfo userDirectory = new DirectoryInfo(@"D:\Config\"+  ListUsers[i].Name);
                    if (!userDirectory.Exists)
                    {
                        userDirectory.Create();
                    }
                    string path = userDirectory + @"\" + ListUsers[i].Name + ".json";
                    using (StreamWriter sw = new StreamWriter(path))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, newUser);
                    }
                }
            }

        /// <summary>
        /// Сonverts null to zero in fields defining the position of the window on the screen.
        /// </summary>
        /// <param name="user"> Object of class user. </param>
        /// <returns> New object of the user class that has no null value for the fields defining the position of the window on the screen.  </returns>
        private static User ConvertingNullInZero(User user)
        {
            User newUser = new User(user.Name);
            var users = user.ListWinSettings.Select((winSetting) => winSetting);
            foreach( var winSetting in users )
            {
                newUser.ListWinSettings.Add(new WindowsSettings(winSetting.Title, winSetting.Top == null ?  0 : winSetting.Top,
                winSetting.Left == null ? 0 :  winSetting.Left, winSetting.Width == null ?  0 : winSetting.Width,
                winSetting.Height == null ?  0 : winSetting.Height));
            }
            return newUser;          
            }            
        }
    }


