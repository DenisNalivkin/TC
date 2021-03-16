using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
namespace Task4
{
    public class XmlUserParser
    {
        public XAttribute[] Logins { get; private set; }
        public List<User> ListUsers { get; private set; }

        public XmlUserParser(XDocument xDoc)
        {
            ListUsers = new List<User>();
            ParseLogins(xDoc);
        }

        private void ParseLogins(XDocument xDoc)
        {
            var nestedElements = xDoc.Root.Elements("login");
            this.Logins = new XAttribute[nestedElements.Count()];
            var logins = nestedElements.Select((curentLogin) => curentLogin.FirstAttribute);
            for (int i = 0; i < Logins.Length; i++)
            {
                this.Logins[i] = logins.ElementAtOrDefault(i);
                var currentLogin = xDoc.Root.Elements("login").Where((login) => login.Attribute("name").Value == (string)Logins[i]);
                WindowsSettings mainWindowSettings = new WindowsSettings(ParseWinElem(currentLogin, "main", (string)Logins[i]), "main");
                WindowsSettings helpWindowSettings = new WindowsSettings(ParseWinElem(currentLogin, "help", (string)Logins[i]), "help");
                ListUsers.Add(new User((string)Logins[i], mainWindowSettings, helpWindowSettings));
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
     
        public void ShowLoginsIncorrectConfiguration()
        {
            var incorrectUsers = ListUsers.Where((user) => !user.MainWin.UserSetting.IsSettingsCorrect());
            foreach (var user in incorrectUsers)
            {
                Console.WriteLine(user.Name);
            }
        }

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
      
        public void ConvertUserSettingsJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            for ( int i = 0; i < ListUsers.Count(); i++ )
            {
                DirectoryInfo userDirectory = new DirectoryInfo(@"D:\Config\"+  ListUsers[i].Name);
                if (!userDirectory.Exists)
                {
                    userDirectory.Create();
                }
                string path = userDirectory + @"\" + ListUsers[i].Name + ".json";
                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, ListUsers[i]);
                }
            }
        }       
    }
}
