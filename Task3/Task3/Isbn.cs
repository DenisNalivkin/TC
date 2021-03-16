using System;
using System.Text.RegularExpressions;

namespace Task3
{/// <summary>
/// Isbn class stores data about two required templates for isbn and a book-specific isbn value.
/// </summary>
    public class Isbn
    {
        private const string _firstPatternIsbn = "^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$";
        private const string _secondPatternIsbn = "^[0-9]{13}$";
        private string _isbnValue;
        public string IsbnValue
        {   
            get
            {
                return _isbnValue;
            }
            private  set
            {
                if ( value == null )
                {
                    throw new ArgumentNullException();
                }
                if ( Regex.IsMatch(value, _firstPatternIsbn) || Regex.IsMatch(value, _secondPatternIsbn) )
                {
                    _isbnValue = value.Replace("-", "");
                    return;
                }
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Public constructor initializing the fields of the Isbn class object.
        /// </summary>
        /// <param name="isbnValue"> Value for field isbn. </param>
        public Isbn(string isbnValue)
        {
            IsbnValue = isbnValue;
        }
    }
}
