using System;
using System.Text.RegularExpressions;
namespace Task3
{/// <summary>
/// The book class stores information about the book.
/// </summary>
    public class Book : IComparable<Book>
    {
        private const string _firstPatternIsbn = "^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$";
        public string FirstPattern
        {
            get
            {
                return _firstPatternIsbn;
            }
        }
        private const string _secondPatternIsbn = "^[0-9]{13}$";
        public string SecondPatternIsbn
        {
            get
            {
                return _secondPatternIsbn;
            }
        }
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
                if(value == null)
                {
                    throw new System.ArgumentNullException();
                }
                if ( Regex.IsMatch( value, _firstPatternIsbn ) || Regex.IsMatch( value, _secondPatternIsbn ) )
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

        /// <summary>
        /// Public constructor initializing the fields of the Book class object.
        /// </summary>
        /// <param name="isbn"> Value for field isbn. </param>
        /// <param name="bookName"> Value for field bookName.  </param>
        /// <param name="publicationDate"> Value for field publicationDate. </param>
        public Book( string isbn, string bookName, string publicationDate )
        {
            Isbn = isbn;
            BookName = bookName;
            PublicationDate = publicationDate;
            ListAuthors = new System.Collections.Generic.List<Author>();
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

        /// <summary>
        ///  The Override Equals method compares objects of the class book by Isbn value.
        /// </summary>
        /// <param name="obj"> Second operand for comparison. </param>
        /// <returns>  True if both operands are equals, otherwise false. </returns>
        public override bool Equals(object obj)
        {
            Book resultConverting = obj as Book;
            if( resultConverting!=null )
            {
                string leftOperand = this.Isbn.Replace("-", "");
                string rightOperand = resultConverting.Isbn.Replace("-", "");
                return leftOperand == rightOperand;
            }
            return false;
        }   
    }
}

  




