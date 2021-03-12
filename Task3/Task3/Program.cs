using System.Linq;
using System;
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
            Book gogolBook2 = new Book("2222222222222", "Taras Bulba", "1835");

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


            // Get a set of books for the given author's first and last name.
            var setBooks2 = library.BooksList.SelectMany((books) => books.ListAuthors, (book, author) => new
            { Book = book.BookName, AuthorFirstName = author.FirstName, AuthorLastName = author.LastName})
            .Where(bookInformation => bookInformation.AuthorFirstName.ToUpper() == "NICOLAI" && bookInformation.AuthorLastName.ToUpper() == "GOGOL")
            .Select((result) => result.Book);


            // Sort books by descending  by  date publication.
            var sortBooks = library.BooksList.OrderByDescending(book => book.PublicationDate);


            // Get set tuples of the form “author - the number of his books in the catalog”.
            var setTuples = library.BooksList.SelectMany((books) => books.ListAuthors, (book, author) => new
            { Book = book.BookName, AuthorFirstName = author.FirstName, AuthorLastName = author.LastName })
            .GroupBy((bookInformation) => bookInformation.AuthorFirstName + " " +  bookInformation.AuthorLastName).Select(group => new { FullName = group.Key, AmountBook = group.Count() });

            foreach (var elem in setTuples)
            {
                Console.WriteLine(elem);
            }
        }  
    }
}
