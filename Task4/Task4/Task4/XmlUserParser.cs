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
            ReadLogins(xDoc);
            ReadWinElem(xDoc, "main");
            ReadWinElem(xDoc, "help");
        }

        private void ReadLogins(XDocument xDoc)
        {
            var nestedElements = xDoc.Root.Elements("login");
            this.Logins = new XAttribute[nestedElements.Count()];
            var logins = nestedElements.Select((curentLogin) => curentLogin.FirstAttribute);
            for (int i = 0; i < Logins.Length; i++)
            {
                this.Logins[i] = logins.ElementAtOrDefault(i);
                ListUsers.Add(new User((string)Logins[i]));
            }
        }

        private void ReadWinElem(XDocument xDoc, string attributeName)
        {
            var nestedElements = xDoc.Root.Elements("login");
            for (int i = 0; i < nestedElements.Count(); i++)
            {
                var currentLogin = nestedElements.Where((login) => login.Attribute("name").Value == ListUsers[i].Login);
                var winElem = currentLogin.Elements("window").Where((winAtrib) => winAtrib.Attribute("title").Value == attributeName);
                ReadNestedWinElem(winElem, ListUsers[i], attributeName);
            }
        }

        private void ReadNestedWinElem(IEnumerable<XElement> winElem, User user, string attributeName)
        {
            if (winElem.Count() == 0)
            {
                return;
            }

            else
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
                if(dictSettings["top"] is null) { user[attributeName].Top = null; } else { user[attributeName].Top = int.Parse(dictSettings["top"]); }
                if (dictSettings["left"] is null) { user[attributeName].Left = null; } else { user[attributeName].Left = int.Parse(dictSettings["left"]); }
                if (dictSettings["width"] is null) { user[attributeName].Width = null; } else { user[attributeName].Width = int.Parse(dictSettings["width"]); }
                if (dictSettings["height"] is null) { user[attributeName].Height = null; } else { user[attributeName].Height = int.Parse(dictSettings["height"]); }
            }
        }
     
        public void ShowLoginsIncorrectConfiguration()
        {
            var incorrectUsers = ListUsers.Where((user) => !user.MainSettings.IsSettingsCorrect());
            foreach (var user in incorrectUsers)
            {
                Console.WriteLine(user.Login);
            }
        }

        public void ShowInformationUserSetting()
        {             
            foreach (var user in ListUsers)
            {
                Console.WriteLine($"Login: {user.Login}");
                Console.WriteLine($"main ({user.MainSettings.Top.ConvertingNullableInString()}, {user.MainSettings.Left.ConvertingNullableInString()}," +
                $" {user.MainSettings.Width.ConvertingNullableInString()}, {user.MainSettings.Height.ConvertingNullableInString()})");
                Console.WriteLine($"help ({user.HelpSettings.Top.ConvertingNullableInString()}, {user.HelpSettings.Left.ConvertingNullableInString()}," +
               $" {user.HelpSettings.Width.ConvertingNullableInString()}, {user.HelpSettings.Height.ConvertingNullableInString()})");
            }
        }
      
        public void ConvertUserSettingsJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            for ( int i = 0; i < ListUsers.Count(); i++ )
            {
                DirectoryInfo userDirectory = new DirectoryInfo(@"D:\Config\"+  ListUsers[i].Login);
                if (!userDirectory.Exists)
                {
                    userDirectory.Create();
                }

                using (StreamWriter sw = new StreamWriter(@"D:\Config\" + userDirectory +  " " + ListUsers[i].Login +".json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, ListUsers[i]);
                }
            }
        }       
    }
}
