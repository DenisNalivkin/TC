using System.Collections.Generic;
namespace Task3
{/// <summary>
/// Utils class stores method GetAuthorBooksCountTuple.
/// </summary>
    public class Utils
    {/// <summary>
     /// GetAuthorBooksCountTuple method creates set of tuple as pairs name author with amount wrote books.
     /// </summary>
     /// <param name="BooksList"> The list stores books. </param>
     /// <returns>  The list of tuple. </returns>
        public List<( string, int )> GetAuthorBooksCountTuple( List<Book> BooksList )
        {
            List<( string, int )> result = new List<( string, int )>();
            Dictionary<string, int> dictionary1 = new Dictionary<string, int>();

            foreach ( Book book in BooksList )
            {
                foreach ( Author author in book.ListAuthors )
                {
                    string fullName = author.LastName + " " + author.FirstName;
                    if ( !dictionary1.ContainsKey(fullName) )
                    {
                        dictionary1[fullName] = 0;
                    }
                    dictionary1[fullName] += 1;
                }
            }
            foreach ( var keyValuePair in dictionary1 )
            {
                result.Add( ( keyValuePair.Key, keyValuePair.Value ) );
            }
            return result;
        }
    }
}
