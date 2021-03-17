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
            Book pushkinsBook = new Book("1111111111111", "Captain's daughter", "1836", new Author [] { pushkin });
            Book pushkinsBook2 = new Book("111-1-11-111111-1", "Ruslan and Ludmila", "1820", new Author[] { pushkin });
            Book tolstoiBook = new Book("2222222222222", "War and peace", "1867", new Author[] { tolstoi });
            Book tolstoiBook2 = new Book("222-2-22-222222-2", "Anna Karenina", "1877", new Author[] { tolstoi });
            Book gogolBook = new Book("3333333333333", "Dead souls", "1842", new Author[] { gogol });
            Book gogolBook2 = new Book("2222222222222", "Taras Bulba", "1835", new Author[] { gogol });

            // Directory which stores list books.
            Catalog library = new Catalog();
            library.BooksList.Add(pushkinsBook);
            library.BooksList.Add(pushkinsBook2);
            library.BooksList.Add(tolstoiBook);
            library.BooksList.Add(tolstoiBook2);
            library.BooksList.Add(gogolBook);
            library.BooksList.Add(gogolBook2);

            // Get a set of books for the given author's first and last name.
            var setBooks = from book in library.BooksList
                           from authors in book.AuthorsList
                           where authors.FirstName.ToUpper() == "NICOLAI"
                           where authors.LastName.ToUpper() == "GOGOL"
                           select book;

            // Get a set of books for the given author's first and last name.
            var setBooks2 = library.BooksList.SelectMany((books) => books.AuthorsList, (book, author) => new
            { Book = book.BookName, AuthorFirstName = author.FirstName, AuthorLastName = author.LastName })
            .Where(bookInformation => bookInformation.AuthorFirstName.ToUpper() == "NICOLAI" && bookInformation.AuthorLastName.ToUpper() == "GOGOL")
            .Select((result) => result.Book);

            // Sort books by descending  by  date publication.
            var sortBooks = library.BooksList.OrderByDescending(book => book.PublicationDate);

            // Get set tuples of the form “author - the number of his books in the catalog”.
            var result2 = library.BooksList.SelectMany((books) => books.AuthorsList, (book, author) => author)
                .GroupBy((author) => author)
                .Select(group => new { FullName = group.Key, AmountBook = group.Count() });
        }
    }
}
