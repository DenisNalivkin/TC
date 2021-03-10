using System.Collections.Generic;
using System.Linq;
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Authors books.
            Author pushkin = new Author("Alexandr", "Pushkin");
            Author gogol = new Author("Nicolai", "Gogol");
            Author tolstoi = new Author("Lev", "Tolstoi");

            // Books.
            Book pushkinsBook = new Book("1111111111111", "Captain's daughter", "1836");
            Book pushkinsBook2 = new Book("111-1-11-111111-1", "Ruslan and Ludmila", "1820");
            Book tolstoiBook = new Book("2222222222222", "War and peace","1867");
            Book tolstoiBook2 = new Book("222-2-22-222222-2", "Anna Karenina", "1877");
            Book gogolBook = new Book("3333333333333", "Dead souls", "1842");
            Book gogolBook2 = new Book("333-3-33-333333-3", "Taras Bulba", "1835");

            // Assignment of values ​​to the list by the author of books.
            pushkinsBook.ListAuthors.Add(pushkin);
            pushkinsBook2.ListAuthors.Add(pushkin);
            tolstoiBook.ListAuthors.Add(tolstoi);
            tolstoiBook2.ListAuthors.Add(tolstoi);
            gogolBook.ListAuthors.Add(gogol);
            gogolBook2.ListAuthors.Add(gogol);

            // Directory which stores list books.
            Directory library = new Directory();
            library.BooksList.Add(pushkinsBook);
            library.BooksList.Add(pushkinsBook2);
            library.BooksList.Add(tolstoiBook);
            library.BooksList.Add(tolstoiBook2);
            library.BooksList.Add(gogolBook);
            library.BooksList.Add(gogolBook2);

            // Get a set of books for the given author's first and last name.
            var setBooks = from book in library.BooksList
                           from authors in book.ListAuthors
                           where authors.FirstName.ToUpper() == "ALEXANDR"
                           where authors.LastName.ToUpper() == "PUSHKIN"
                           select book;

            // Sort books by descending  by  date publication.
            var sortBooks = library.BooksList.OrderByDescending( book => book.PublicationDate );

            // Get author books count tuple.
            Utils utils1 = new Utils();
            var result = utils1.GetAuthorBooksCountTuple( library.BooksList );
            foreach ( var elem in result )
            {
                System.Console.WriteLine( $"Author {elem.Item1} - amount wrote books {elem.Item2}" );
            }
        }  
    }
}
