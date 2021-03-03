using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    ///   Text class stores text for lesson.
    /// </summary>
    public class Text : GeneralForSiteEntities
    {   
        const int lengthOfDescription = 256;
        const int lengthOfText = 10000;
        private Guid theUniueIdentifier;
        public override Guid TheUniueIdentifier
        {
            get
            {
                return theUniueIdentifier;
            }
        }
        private string textDescription;
        public override string TextDescription
        {
            get
            {
                return textDescription;
            }
            set
            {
                if (value.Length <= lengthOfDescription)
                {
                    textDescription = value;
                }
            }
        }
        private string textForLesson;
        public string TextForLesson
        {
            get
            {
                return textForLesson;
            }
            set
            {
                if ( !String.IsNullOrEmpty(value) && value.Length <= lengthOfText)
                {
                    textDescription = value;
                }
            }
        }

        public Text (string textDescription, string textForLesson)
        {
            this.theUniueIdentifier = theUniueIdentifier.CreateUniqueIdentifier();
            this.textDescription = textDescription;
            if (textDescription.Length <= lengthOfDescription)
            {
                this.textDescription = textDescription;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!String.IsNullOrEmpty(textForLesson) && textForLesson.Length <= lengthOfText)
            {
               this.textForLesson = textForLesson;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }               
        }
        /// <summary>
        /// Overridden ToString method.
        /// </summary>
        /// <returns>Returns property textDescription of text class.  </returns>
        public override string ToString()
        {
            return TextDescription;
        }
        /// <summary>
        ///  Overridden Equals method.
        /// </summary>
        /// <param name="obj"> The second operand for compare.</param>
        /// <returns>  True if both operands are equals, or false if not equals. </returns>
        public override bool Equals(object obj)
        {
            GeneralForSiteEntities resultOfConverting = obj as GeneralForSiteEntities;             
            if(resultOfConverting !=null)
            {
                return this.theUniueIdentifier == resultOfConverting.TheUniueIdentifier;
            }
            return false;        
        }
    }


    }

