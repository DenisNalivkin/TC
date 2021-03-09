namespace Task3
{/// <summary>
/// Directory class stores library with books.
/// </summary>
    public class Directory
    {
        public System.Collections.Generic.List<Book> ListBook { get; set; }

        public Directory ()
        {
            ListBook = new System.Collections.Generic.List<Book>();
        }

        public Book this[string key]
        {
            get
            {
               foreach( Book book in ListBook )
                {
                    if( book.Isbn  == key )
                    {
                        return book;
                    }
                }
               throw new System.Collections.Generic.KeyNotFoundException();
            }
            set
            {
                foreach ( Book book in ListBook )
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
            this.ListBook.Sort();
            for ( int i = 0; i < ListBook.Capacity-1; i++ )
            {
                yield return ListBook[i].BookName;
            }
        }
    }
}
