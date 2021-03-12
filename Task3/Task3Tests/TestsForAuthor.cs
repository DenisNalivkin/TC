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

        [Test]
        public void Сheck_Set_FirstName_With_Correct_value()
        {
            author.FirstName = "Lev";
            Assert.AreEqual( author.FirstName, "Lev" );        
        }

        [Test]
        public void Check_Set_FirstName_Exception_Throwing_After_Null_Value()
        {          
            Assert.Throws<System.ArgumentException>( () => author.FirstName = null );              
        }

        [Test]
        public void Check_Set_FirstName_Exception_Throwing_After_Empty_Value()
        {
            Assert.Throws<System.ArgumentException>( () => author.FirstName = "" );
        }

        [Test]
        public void Check_Set_FirstName_Exception_Throwing_After_TooBigString()
        {
            Assert.Throws<System.ArgumentException>( () => author.FirstName = bigString );
        }

        [Test]
        public void Сheck_Set_LastName_With_Correct_Value()
        {
            author.LastName = "Gogol";
            Assert.AreEqual(author.LastName, "Gogol");
        }

        [Test]
        public void Check_Set_LastName_Exception_Throwing_After_Null_Value()
        {
            Assert.Throws<System.ArgumentException>(() => author.LastName = null);
        }

        [Test]
        public void Check_Set_LastName_Exception_Throwing_After_Empty_Value()
        {
            Assert.Throws<System.ArgumentException>(() => author.LastName = "");
        }

        [Test]
        public void Check_Set_LastName_Exception_Throwing_After_TooBigString()
        {
            Assert.Throws<System.ArgumentException>(() => author.LastName = bigString);
        }
    }
}
