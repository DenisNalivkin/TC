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
                if( !string.IsNullOrEmpty( value ) && value.Length <= LengthName )
                {
                    _firstName = value;
                    return;
                }
                throw new System.ArgumentException();
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
                if ( !string.IsNullOrEmpty( value ) && value.Length <= LengthName )
                {
                    _lastName = value;
                    return;
                }
                throw new System.ArgumentException();
            }         
        }

        public Author( string firstName, string lastName )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Author()
        {

        }
    }
}
