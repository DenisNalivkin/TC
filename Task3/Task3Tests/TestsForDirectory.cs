using NUnit.Framework;
using System.Collections.Generic;
using Task3;
namespace Task3Tests
{
    [TestFixture]
    public class TestsForDirectory
    {
        Catalog directory;
        Author pushkin;
        Book book1;
        Book book2;

        [SetUp]
        public void Setup()
        {
            directory = new Catalog();
            pushkin = new Author("Alexandr", "Pushkin");
            book1 = new Book("1111111111111", "Captain's daughter", "1836", new List<Author> { pushkin });
            book2 = new Book("222-2-22-222222-2", "Taras Bulba", "1835", new List<Author> { pushkin });
        }

        [Test]
        public void Check_Indexator_Get_Book_By_The_Correct_Key()
        {
            directory.BooksList.Add(book1);
            directory.BooksList.Add(book2);
            Assert.AreEqual(directory["1111111111111"], "Captain's daughter");
            Assert.AreEqual(directory["222-2-22-222222-2"], "Taras Bulba");
        }

        [Test]
        public void Check_Indexator_Get_Book_Exception_Throwing_After_NonExistent_Key()
        {
            directory.BooksList.Add(book1);
            directory.BooksList.Add(book2);
            Assert.Throws<KeyNotFoundException>(() => System.Console.WriteLine(directory["111111111111d"]));
            Assert.Throws<KeyNotFoundException>(() => System.Console.WriteLine(directory["222-2-22-222222-d"]));
        }
    }
}
