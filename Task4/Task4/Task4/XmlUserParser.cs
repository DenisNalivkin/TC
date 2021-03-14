using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
namespace Task4
{
   public class XmlUserParser
    {
        public XAttribute [] Logins { get; private set; }
        public List<User> ListUsers { get; private set; }

        public XmlUserParser (XDocument xDoc)
        {
            ListUsers = new List<User>();
            ReadLogins(xDoc);
            ReadWinElem(xDoc,"main");
            ReadWinElem(xDoc, "help");
            CheckConfiguration(ListUsers);

        }
          
        private void ReadLogins (XDocument xDoc)
        {          
            var nestedElements = xDoc.Root.Elements("login");
            this.Logins = new XAttribute[nestedElements.Count()];
            var logins = nestedElements.Select((curentLogin) => curentLogin.FirstAttribute);
            for ( int i =0; i <Logins.Length;i++ )
            {
                this.Logins[i] = logins.ElementAtOrDefault(i);
                ListUsers.Add(new User( (string)Logins[i], null, null));
            }                             
        }

        private void ReadWinElem(XDocument xDoc,string attributeName)
        {
            var nestedElements = xDoc.Root.Elements("login");     
            for ( int i = 0; i< nestedElements.Count(); i++ )
            {
               var currentLogin = nestedElements.Where((login) => login.Attribute("name").Value == ListUsers[i].Login);
               var winElem = currentLogin.Elements("window").Where((winAtrib) => winAtrib.Attribute("title").Value == attributeName);
               ReadNestedWinElem(winElem, ListUsers[i],attributeName);
            }         
        }

        private void ReadNestedWinElem (IEnumerable <XElement> winElem, User user, string attributeName)
        {
            if (winElem.Count() == 0)
            {
                return;
            }

            else
            {
                string[] nestedWinElements = { "top", "left", "width", "height" };
                IEnumerable<string> valueElem;
                for ( int i = 0; i < nestedWinElements.Count(); i++ )
                {
                    valueElem = winElem.Elements((nestedWinElements[i])).Select((elem) => elem.Value);
                    if( valueElem.Count() == 0 )
                    {
                        user[attributeName] += "?, ";
                        continue;
                    }
                    user[attributeName] += valueElem.First() + ", ";
                }
                user[attributeName] = user[attributeName].TrimEnd(new char[] { ',', ' ' });
            }           
        }

        private void CheckConfiguration(List<User> ListUsers)
        {
            const int valueIndexOf = -1;
            foreach (var user in ListUsers)
            {
                if( user.MainSettings == null || user.MainSettings.IndexOf("?") == valueIndexOf )
                {
                    user.сorrectСonfiguration = true;
                }
            }
        }
 
        public void ShowLoginsIncorrectConfiguration ()
        {
            var incorrectUsers = this.ListUsers.Where((user) => user.сorrectСonfiguration == false).Select((user) => user);
            foreach( var user in incorrectUsers)
            {
                Console.WriteLine(user.Login);
            }

        }

        public void ShowInformationUserSetting()
        {
            foreach (var user in ListUsers)
            {
                Console.WriteLine($"Login: {user.Login}");
                Console.WriteLine($"main:({user.MainSettings})");
                Console.WriteLine($"help:({user.HelpSettings})");
            }
        }
    }
}
