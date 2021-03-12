using NUnit.Framework;
using System.Collections.Generic;
using Task3;
namespace Task3Tests
{
    [TestFixture]
    public class TestsForDirectory
    {
        Directory directory;
        Book book1;
        Book book2;

        [SetUp]
        public void Setup()
        {
            directory = new Directory();
            book1 = new Book("1111111111111", "Captain's daughter", "1836");
            book2 = new Book("222-2-22-222222-2", "Taras Bulba", "1835");
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

        [Test]
        public void Check_Indexator_Set_BookName_By_The_Correct_Key()
        {
            directory.BooksList.Add(book2);
            directory["222-2-22-222222-2"] = "Name changed";
            Assert.AreEqual(directory["222-2-22-222222-2"], "Name changed");
        }

        [Test]
        public void Check_Indexator_Set_BookName_By_The_Incorrect_Key()
        {
            Assert.Throws<KeyNotFoundException>(() => directory["222-2-22-222222-2"] = "Name changed");
        }
    }
}
