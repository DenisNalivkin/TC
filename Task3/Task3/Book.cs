using System;
using System.Text.RegularExpressions;
namespace Task3
{/// <summary>
/// The book class stores information about the book.
/// </summary>
    public class Book : System.IComparable<Book>
    {
        private const string firstPattern = "[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}";
        private const string secondPattern = "[0-9]{13}";
        private const int _lengthFirstPattern = 17;
        private const int _lengthSecondPattern = 13;
        private const int LengthBookName = 1000;
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
                if ( !string.IsNullOrEmpty( value ) && value.Length <= LengthBookName )
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
        /// <summary>
        /// Implementation of the method of interface IComparable. CompareTo method compares objects of class Book by property Name.
        /// </summary>
        /// <param name="otherBook"> Second operand for compare. </param>
        /// <returns></returns>
        public int CompareTo( Book otherBook )
        {
            return this.BookName.CompareTo( otherBook.BookName );
        }       
    }
}

  




