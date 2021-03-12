using NUnit.Framework;
using System.Text;
using Task3;
namespace Task3Tests
{  
    [TestFixture]
    public class TestsForBook
    {
        Book book;
        string bigString;

        [SetUp]
        public void Setup()
        {
            book = new Book("111-1-11-111111-1", "Captain's daughter", "1836");
            bigString = "Our Earth is so beautiful. There, are a lot of blue rivers and lakes on the Earth.Earth is our home!";
            for (int i  = 0; i <= 3; i++)
            {
                bigString += bigString;
            }
        }
        
        [Test]
        public void Check_Constructor_With_Incorrect_Values_For_BookName_Property()
        {
            Assert.Throws<System.ArgumentException>(() => book = new Book("1111111111111", "", "1877"));
            Assert.Throws<System.ArgumentException>(() => book = new Book("1111111111111", null, "1877"));
            Assert.Throws<System.ArgumentException>(() => book = new Book("1111111111111", bigString, "1877"));
        }

        [Test]
        public void Check_Constructor_With_Empty_Value_For_PublicationDate_Property()
        {
            book = new Book("1111111111111", "Anna Karenina", "");
            Assert.AreEqual(book.PublicationDate,"");
        }

        [Test]
        public void Check_Constructor_With_Null_Value_For_PublicationDate_Property()
        {
            book = new Book("1111111111111", "Anna Karenina", null);
            Assert.AreEqual(book.PublicationDate, null);
        }

        [Test]
        public void Check_Constructor_With_Null_Value_For_ListAuthors_Property()
        {
            book = new Book("1111111111111", "Anna Karenina", "1877");
            Assert.AreEqual(book.ListAuthors.Count, 0);
        }

        [Test]
        public void Сheck_Set_Isbn_With_Correct_value()
        {
            book.Isbn = "111-1-11-111111-1";
            Assert.AreEqual( book.Isbn, "111-1-11-111111-1" );
            book.Isbn = "1111111111111";
            Assert.AreEqual(book.Isbn, "1111111111111");
        }

        [Test]
        public void Check_Set_Isbn_Exception_Throwing_After_Incorrect_Value()
        {
            Assert.Throws<System.ArgumentException>( () => book.Isbn = "111-1-11" );
            Assert.Throws<System.ArgumentException>(() => book.Isbn = "111111111111d");

        }

        [Test]
        public void Check_Set_Isbn_Exception_Throwing_After_Null_Value()
        {
            Assert.Throws<System.ArgumentNullException>(() => book.Isbn = null);
        }

        [Test]
        public void Check_Set_BookName_Сorrect_Value()
        {
            book.BookName = "Captain's daughter";
            Assert.AreEqual( book.BookName, "Captain's daughter" );
        }

        [Test]
        public void Check_Set_BookName_Exception_Throwing_After_Empty_Value()
        {
            Assert.Throws<System.ArgumentException>(() => book.BookName ="");
        }

        [Test]
        public void Check_Set_BookName_Exception_Throwing_After_Null_Value()
        {
            Assert.Throws<System.ArgumentException>(() => book.BookName = null);
        }

        [Test]
        public void Check_Set_BookName_Exception_Throwing_After_TooBigString()
        {
            Assert.Throws<System.ArgumentException>(() => book.BookName = bigString);
        }

        [Test]
        public void Check_Method_CompareTo ()
        {
            book = new Book("111-1-11-111111-1", "Anna Karenina", "1877");
            Book book2 = new Book("222-2-22-222222-2", "War and peace", "1867");
            Assert.Negative(book.CompareTo(book2));
        }

        [Test]
        public void Check_Mehtod_Equals()
        {
            Book book2 = new Book("1111111111112", "Captain's daughter", "1836");
            Assert.IsFalse(book.Equals(book2));              
        }
    }
}
