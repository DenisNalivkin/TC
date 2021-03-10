using NUnit.Framework;
using Task3;
namespace Task3Tests
{
    [TestFixture]
    public class TestsForAuthor
    {
        Author author;

        [SetUp]
        public void Setup()
        {
            author = new Author();
        }

        [Test]
        public void Check_Property_FirstName_For_Author ()
        {
            author.FirstName = "Alexandr";
            Assert.AreEqual( author.FirstName, "Alexandr" );        
        }

        [Test]
        public void Check_Exception_Throwing_After_Null_Value_For_Property_FirstName_Author ()
        {          
            Assert.Throws<System.ArgumentException>( () => author.FirstName = null );              
        }

        [Test]
        public void Check_Exception_Throwing_After_Empty_Value_For_Property_FirstName_Author()
        {
            Assert.Throws<System.ArgumentException>( () => author.FirstName = "" );
        }

        [Test]
        public void Check_Exception_Throwing_After_TooBigString_For_Property_FirstName_Author()
        {
            string bigString = " I liked Physics and Chemistry when I was at the university, but I wasn’t very good at Economics.There was another student, whose name was Jim Green, who was even worse.He was one of the star players on the football team, but he couldn’t continue to play if he didn’t pass all his examinations.";
            Assert.Throws<System.ArgumentException>( () => author.FirstName = bigString );
        }
    }
}
