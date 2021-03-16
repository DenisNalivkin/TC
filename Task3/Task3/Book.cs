using System;
using System.Collections.Generic;

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
            private set
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
        private Author [] _authorsList;
        public Author[] AuthorsList
        {
            get
            {
                return _authorsList;
            }                 
        }

        /// <summary>
        /// Public constructor initializing the fields of the Book class object.
        /// </summary>
        /// <param name="isbn"> Value for field isbn. </param>
        /// <param name="bookName"> Value for field bookName.  </param>
        /// <param name="publicationDate"> Value for field publicationDate. </param>
        /// <param name="authorsList"> Value for field authorsList. </param>
        public Book( string isbn, string bookName, string publicationDate, Author [] authorsList)
        {
            _isbn = new Isbn(isbn);
            BookName = bookName;
            PublicationDate = publicationDate;
            _authorsList = authorsList;
        }

        /// <summary>
        /// CompareTo is used to compare the current object Book with the object that is passed in the object o parameter. At the output, it returns an integer, which can have one of three values.
        /// </summary>
        /// <param name="otherBook"> Second operand for compare. </param>
        /// <returns> Less than zero. Hence, the current object must be before the object that is passed as an object.Equal to zero.Hence, both objects are equal. Above zero. This means that the current object must be after the object passed as a parameter. </returns>
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

  




