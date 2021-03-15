using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Task3
{/// <summary>
/// The book class stores information about the book.
/// </summary>
    public class Book : IComparable<Book>
    {      
        private const int LengthBookName = 1000;
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
                }
                else
                {
                    throw new System.ArgumentException();
                }               
            }

        }
        private Isbn _isbn;
        public string Isbn
        {
            get { return _isbn.IsbnValue; }
            
        }

        public string PublicationDate { get; private set; }
        public System.Collections.Generic.List<Author> ListAuthors { get; set; }
       

        /// <summary>
        /// Public constructor initializing the fields of the Book class object.
        /// </summary>
        /// <param name="isbn"> Value for field isbn. </param>
        /// <param name="bookName"> Value for field bookName.  </param>
        /// <param name="publicationDate"> Value for field publicationDate. </param>
        public Book( string isbn, string bookName, string publicationDate, List<Author> AuthorsList)
        {
            _isbn = new Isbn(isbn);
            BookName = bookName;
            PublicationDate = publicationDate;
            ListAuthors = AuthorsList;
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
            Book valueToCompare = obj as Book;
            return Isbn == valueToCompare?.Isbn;
        }   
    }
}

  




