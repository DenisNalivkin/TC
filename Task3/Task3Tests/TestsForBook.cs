using NUnit.Framework;
using Task3;
namespace Task3Tests
{  
    [TestFixture]
    public class TestsForBook
    {
        Book book;

        [SetUp]
        public void Setup()
        {
            book = new Book();
        }

        [Test]
        public void Check_Property_Isbn_For_Book()
        {
            book.Isbn = "111-1-11-111111-1";
            Assert.AreEqual( book.Isbn, "111-1-11-111111-1" );
        }

        [Test]
        public void Check_Exception_Throwing_After_Incorrect_Isbn_for_Book()
        {
            Assert.Throws<System.ArgumentException>( () => book.Isbn = "111-1-11" );     
        }

        [Test]
        public void Check_Property_BookName_For_Book()
        {
            book.BookName = "Captain's daughter";
            Assert.AreEqual( book.BookName, "Captain's daughter" );
        }

        [Test]
        public void Check_Exception_Throwing_After_Empty_Value_For_Property_BookName_Book()
        {
            Assert.Throws<System.ArgumentException>(() => book.BookName ="");
        }

        [Test]
        public void Check_Method_CompareTo ()
        {
            book = new Book("111-1-11-111111-1", "Anna Karenina", "1877");
            Book book2 = new Book("222-2-22-222222-2", "War and peace", "1867");
            Assert.Negative(book.CompareTo(book2));
        }
    }
}
