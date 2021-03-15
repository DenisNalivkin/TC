using NUnit.Framework;
using Task3;
using System.Collections.Generic;
namespace Task3Tests
{  
    [TestFixture]
    public class TestsForBook
    {
        Book book;
        Author pushkin; 
        string bigString;

        [SetUp]
        public void Setup()
        {
            pushkin = new Author("Alexandr", "Pushkin");
            book = new Book("111-1-11-111111-1", "Captain's daughter", "1836", new List<Author> {pushkin});
            bigString = "Our Earth is so beautiful. There, are a lot of blue rivers and lakes on the Earth.Earth is our home!";
            for (int i  = 0; i <= 3; i++)
            {
                bigString += bigString;
            }
        }
        
        [Test]
        public void Check_Constructor_With_Incorrect_Values_For_BookName_Property()
        {
            Assert.Throws<System.ArgumentException>(() => book = new Book("1111111111111", "", "1877", new List<Author> { pushkin }));
            Assert.Throws<System.ArgumentException>(() => book = new Book("1111111111111", null, "1877", new List<Author> { pushkin }));
            Assert.Throws<System.ArgumentException>(() => book = new Book("1111111111111", bigString, "1877", new List<Author> { pushkin }));
        }

        [Test]
        public void Check_Constructor_With_Empty_Value_For_PublicationDate_Property()
        {
            book = new Book("1111111111111", "Anna Karenina", "", new List<Author> { pushkin });
            Assert.AreEqual(book.PublicationDate,"");
        }

        [Test]
        public void Check_Constructor_With_Null_Value_For_PublicationDate_Property()
        {
            book = new Book("1111111111111", "Anna Karenina", null, new List<Author> { pushkin });
            Assert.AreEqual(book.PublicationDate, null);
        }

        [Test]
        public void Check_Constructor_With_Null_Value_For_ListAuthors_Property()
        {
            book = new Book("1111111111111", "Anna Karenina", "1877", new List<Author> ());
            Assert.AreEqual(book.ListAuthors.Count, 0);
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
            book = new Book("111-1-11-111111-1", "Anna Karenina", "1877", new List<Author> { pushkin });
            Book book2 = new Book("222-2-22-222222-2", "War and peace", "1867", new List<Author> { pushkin });
            Assert.Negative(book.CompareTo(book2));
        }

        [Test]
        public void Check_Mehtod_Equals()
        {
            Book book2 = new Book("1111111111112", "Captain's daughter", "1836", new List<Author> { pushkin });
            Assert.IsFalse(book.Equals(book2));              
        }
    }
}
