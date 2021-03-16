using NUnit.Framework;
using Task3;

namespace Task3Tests
{
    [TestFixture]
    public class TestsForAuthor
    {
        Author author;
        string bigString;

        [SetUp]
        public void Setup()
        {
            author = new Author("Alexandr","Pushkin");
            bigString = "Our Earth is so beautiful.";
            for (int i = 0; i <= 2; i++)
            {
                bigString += bigString;
            }
        }

        [Test]
        public void Check_Constructor_With_Incorrect_Values_FirstName()
        {
            Assert.Throws<System.ArgumentException>(() => author = new Author("", "Pushkin"));
            Assert.Throws<System.ArgumentException>(() => author = new Author(null, "Pushkin"));
            Assert.Throws<System.ArgumentException>(() => author = new Author(bigString, "Pushkin"));
        }

        [Test]
        public void Check_Constructor_With_Incorrect_Values_LastName()
        {
            Assert.Throws<System.ArgumentException>(() => author = new Author("Alexandr", ""));
            Assert.Throws<System.ArgumentException>(() => author = new Author("Alexandr", null));
            Assert.Throws<System.ArgumentException>(() => author = new Author("Alexandr", bigString));
        }
    }
}
