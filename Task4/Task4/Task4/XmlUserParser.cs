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
            for (int i = 0; i < UserNames.Length; i++)
            {
                this.UserNames[i] = loginFirstAtr.ElementAtOrDefault(i);
                var currentLogin = xDoc.Root.Elements("login").Where((login) => login.Attribute("name").Value == (string)UserNames[i]);
                WindowsSettings mainWindowSettings = new WindowsSettings(ParseWinElem(currentLogin, "main", (string)UserNames[i]), "main");
                WindowsSettings helpWindowSettings = new WindowsSettings(ParseWinElem(currentLogin, "help", (string)UserNames[i]), "help");
                ListUsers.Add(new User((string)UserNames[i], mainWindowSettings, helpWindowSettings));
            }
        }

        private UserSettings ParseWinElem(IEnumerable<XElement> login, string attributeName, string userName)
        {
            var winElem = login.Elements("window").Where((winAtrib) => winAtrib.Attribute("title").Value == attributeName);
            return ParseWinSettings(winElem,attributeName);
        }

        private UserSettings ParseWinSettings(IEnumerable<XElement> winElem, string attributeName)
        {
            UserSettings userSetting = new UserSettings();
            if (winElem.Count() != 0)
            {
                
                Dictionary<string,string> dictSettings = new Dictionary<string, string> { { "top", null }, { "left", null }, { "width", null }, { "height", null } };
                string[] settingsArray = { "top", "left", "width", "height" };
                IEnumerable<string> valueElem;
                foreach (var key in settingsArray)
                {              
                    valueElem = winElem.Elements(key).Select((elem) => elem.Value);
                    if (valueElem.Count() != 0)
                    {
                        dictSettings[key] =(valueElem.First());                       
                    }                   
                }
                userSetting.Top = dictSettings["top"] == null ? null : (int?)(int.Parse(dictSettings["top"]));
                userSetting.Left = dictSettings["left"] == null ? null : (int?)(int.Parse(dictSettings["left"]));
                userSetting.Width = dictSettings["width"] == null ? null : (int?)(int.Parse(dictSettings["width"]));
                userSetting.Height = dictSettings["height"] == null ? null : (int?)(int.Parse(dictSettings["height"]));
            }
            return userSetting;
        }

        /// <summary>
        ///  Shows logins with incorrect settings.
        /// </summary>
        public void ShowLoginsIncorrectConfiguration()
        {
            var incorrectUsers = ListUsers.Where((user) => !user.MainWin.UserSetting.IsSettingsCorrect());
            foreach (var user in incorrectUsers)
            {
                Console.WriteLine(user.Name);
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
                Console.WriteLine($"main ({user.MainWin.UserSetting.Top.ConvertingNullableInString()}, {user.MainWin.UserSetting.Left.ConvertingNullableInString()}," +
                $" {user.MainWin.UserSetting.Width.ConvertingNullableInString()}, {user.MainWin.UserSetting.Height.ConvertingNullableInString()})");
                Console.WriteLine($"help ({user.HelpWin.UserSetting.Top.ConvertingNullableInString()}, {user.HelpWin.UserSetting.Left.ConvertingNullableInString()}," +
               $" {user.HelpWin.UserSetting.Width.ConvertingNullableInString()}, {user.HelpWin.UserSetting.Height.ConvertingNullableInString()})");
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
        private static User ConvertingNullInZero (User user)
        {               
            User newUser = new User(user.Name, user.MainWin, user.HelpWin);
            newUser.MainWin.UserSetting.Top = newUser.MainWin.UserSetting.Top == null ? newUser.MainWin.UserSetting.Top = 0 : newUser.MainWin.UserSetting.Top = newUser.MainWin.UserSetting.Top;
            newUser.MainWin.UserSetting.Left = newUser.MainWin.UserSetting.Left == null ?   newUser.MainWin.UserSetting.Left = 0 :newUser.MainWin.UserSetting.Left = newUser.MainWin.UserSetting.Left;
            newUser.MainWin.UserSetting.Width = newUser.MainWin.UserSetting.Width == null ? newUser.MainWin.UserSetting.Width = 0 : newUser.MainWin.UserSetting.Width = newUser.MainWin.UserSetting.Width;
            newUser.MainWin.UserSetting.Height = newUser.MainWin.UserSetting.Height == null ? newUser.MainWin.UserSetting.Height = 0 : newUser.MainWin.UserSetting.Height = newUser.MainWin.UserSetting.Height;

            newUser.HelpWin.UserSetting.Top = newUser.HelpWin.UserSetting.Top == null ? newUser.HelpWin.UserSetting.Top = 0 : newUser.HelpWin.UserSetting.Top = newUser.HelpWin.UserSetting.Top;
            newUser.HelpWin.UserSetting.Left = newUser.HelpWin.UserSetting.Left == null ? newUser.HelpWin.UserSetting.Left = 0 : newUser.HelpWin.UserSetting.Left = newUser.HelpWin.UserSetting.Left;
            newUser.HelpWin.UserSetting.Width = newUser.HelpWin.UserSetting.Width == null ? newUser.HelpWin.UserSetting.Width = 0 : newUser.HelpWin.UserSetting.Width = newUser.HelpWin.UserSetting.Width;
            newUser.HelpWin.UserSetting.Height = newUser.HelpWin.UserSetting.Height == null ? newUser.HelpWin.UserSetting.Height = 0 : newUser.HelpWin.UserSetting.Height = newUser.HelpWin.UserSetting.Height;
            return newUser;
        }        
    }
}
