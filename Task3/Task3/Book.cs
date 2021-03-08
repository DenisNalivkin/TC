using System.Text.RegularExpressions;
namespace Task3
{/// <summary>
/// The book class stores information about the book.
/// </summary>
    public class Book
    {
        private const string firstPattern = "[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}";
        private const string secondPattern = "[0-9]{13}";
        private const int _lengthFirstPattern = 17;
        private const int _lengthSecondPattern = 13;
        private string _isbn;
        public string Isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                if ( Regex.IsMatch( value, firstPattern ) && value.Length == _lengthFirstPattern || Regex.IsMatch( value, secondPattern ) && value.Length == _lengthSecondPattern )
                {
                    _isbn = value;
                    return;
                }
                throw new System.ArgumentException();
            }
        }
        private string _bookName;
        public string BookName
        {
            get
            {
                return _bookName;
            }
            set
            {
                if ( !string.IsNullOrEmpty( value ) && value.Length <= 1000 )
                {
                    _bookName = value;
                    return;
                }
                throw new System.ArgumentException();
            }

        }
        public string PublicationDate { get; set; }
        public System.Collections.Generic.List<Author> ListAuthors { get; set; }

        public Book( string isbn, string bookName, string publicationDate )
        {
            Isbn = isbn;
            BookName = bookName;
            PublicationDate = publicationDate;
            ListAuthors = new System.Collections.Generic.List<Author>();
        }

        public Book()
        {

        }      
     }
}

  




