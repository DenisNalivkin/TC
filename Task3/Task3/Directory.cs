using System;
using System.Collections;
namespace Task3
{/// <summary>
/// Directory class stores library with books.
/// </summary>
    public class Directory
    {
        public System.Collections.Generic.List<Book> BooksList { get; set; }

        public Directory ()
        {
            BooksList = new System.Collections.Generic.List<Book>();
        }

        public string this[string key]
        {
            get
            {
               foreach( Book book in BooksList )
                {
                    if( book.Isbn  == key )
                    {
                        return book.BookName;
                    }
                }
               throw new System.Collections.Generic.KeyNotFoundException();
            }
            set
            {
                foreach ( Book book in BooksList )
                {
                    if ( book.Isbn == key )
                    {
                        book.Isbn = key;
                    }
                }
               throw new System.Collections.Generic.KeyNotFoundException();
            }     
        }

        /// <summary>
        /// GetEnumerator required to iterate over books in a foreach cycle.
        /// </summary>
        /// <returns> Current the book from library with books. </returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            this.BooksList.Sort();
            for ( int i = 0; i < BooksList.Capacity-1; i++ )
            {
                yield return BooksList[i].BookName;
            }
        }
    }
}
