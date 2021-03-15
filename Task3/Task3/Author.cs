using System;

namespace Task3
{/// <summary>
/// The author class stores information about the author of the book.
/// </summary>
    public class Author
    {
        private const int LengthName = 200;
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            private set
            {
                if(IsNameValid(value))
                {
                    _firstName = (value);                  
                }
                else
                {
                    throw new ArgumentException();
                }                           
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            private  set
            {
                if (IsNameValid(value))
                {
                    _lastName = (value);
                }
                else
                {
                    throw new ArgumentException();
                }             
            }         
        }

        /// <summary>
        ///  Public constructor initializing the fields of the Author class object.
        /// </summary>
        /// <param name="firstName"> Value for field firstName. </param>
        /// <param name="lastName"> Value for field lastName. </param>
        public Author( string firstName, string lastName )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"> String for check. </param>
        private bool IsNameValid (string name)
        {
            bool isValid = false;
            if (!string.IsNullOrEmpty(name) && name.Length <= LengthName)
            {
                isValid = true;                
            }
            return isValid;
        }
    }
}
