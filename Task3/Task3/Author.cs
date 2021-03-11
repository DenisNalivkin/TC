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
            set
            {
                _firstName = CheckName(value);
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
              _lastName = CheckName(value);
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
        /// CheckName method checks the input string for correctness and, if it meets the requirements, the field is initialized, otherwise throwing exception.
        /// </summary>
        /// <param name="name"> String for check. </param>
        private string CheckName (string name)
        {
            if (!string.IsNullOrEmpty(name) && name.Length <= LengthName)
            {
                return name;                        
            }
            throw new System.ArgumentException();
        }
    }
}
