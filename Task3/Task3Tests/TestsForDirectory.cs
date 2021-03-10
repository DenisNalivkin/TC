using NUnit.Framework;
using Task3;
namespace Task3Tests
{
    [TestFixture]
    public class TestsForDirectory
    {
        Directory directory;

        [SetUp]
        public void Setup()
        {
            directory = new Directory();
        }

        [Test]
        public void Check_Indexator_For_Directory ()
        {
            Book book1 = new Book( "1111111111111", "Captain's daughter", "1836" );
            Book book2 = new Book( "222-2-22-222222-2", "Taras Bulba", "1835" );
            directory.BooksList.Add( book1 );
            directory.BooksList.Add( book2 );
            Assert.AreEqual( directory["1111111111111"], "Captain's daughter" );
            Assert.AreEqual(directory["222-2-22-222222-2"], "Taras Bulba");
        }
    }
}
