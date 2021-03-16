using System.Collections;
using System.Collections.Generic;

namespace Task3
{/// <summary>
/// Catalog class stores library with books.
/// </summary>
    public class Catalog: IEnumerable
    {
        public List<Book> BooksList { get; set; }

        /// <summary>
        /// Public constructor initializing the field of the Catalog class object.
        /// </summary>
        public Catalog ()
        {
            BooksList = new List<Book>();
        }

        /// <summary>
        /// Indexer retrieves book from directory by an Isbn.
        /// </summary>
        /// <param name="key"> Isbn for search a book.  </param>
        /// <returns> Book name if key has been found, otherwise throwing exception. </returns>
        public string this[string key]
        {
            get
            {
                var searchResult = BooksList.Find((book) => book.Isbn == key.Replace("-",""));
                if(searchResult == null)
                {
                    throw new KeyNotFoundException();
                }
                return searchResult.BookName;
            }             
        }

        /// <summary>
        /// GetEnumerator required to iterate over books in a foreach cycle.
        /// </summary>
        /// <returns> The book name of book from library with books. </returns>
        public IEnumerator GetEnumerator()
        {
            this.BooksList.Sort();
            for (int i = 0; i < BooksList.Count -1; i++)
            {
                yield return BooksList[i].BookName;
            }
        }      
    }
}
