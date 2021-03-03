using System;
namespace Task1
{/// <summary>
/// Reference class stores references for lesson.
/// </summary>
    class Reference : GeneralForSiteEntities
    {
        const int lengthOfDescription = 256;
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
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length <= lengthOfDescription)
                    {
                        textDescription = value;
                    }
                }
                else
                {
                    textDescription = value;
                }
            }
        }
        private string referenceOnContent;
        public string ReferenceOnContent
        {
            get
            {
                return referenceOnContent;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                   referenceOnContent = value;
                }
            }
        }
        private TypeOfReference ReferenceType { get; set; }    
        public Reference(string textDescription, string referenceOnContent, TypeOfReference referenceType)
        {
            this.theUniueIdentifier = theUniueIdentifier.CreateUniqueIdentifier();
            this.textDescription = textDescription;
            if (!string.IsNullOrEmpty(textDescription))
            {
                if (textDescription.Length <= lengthOfDescription)
                {
                    this.textDescription = textDescription;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            this.referenceOnContent = referenceOnContent;
            if(string.IsNullOrEmpty(referenceOnContent))
            {
                throw new ArgumentOutOfRangeException();
            }
            this.ReferenceType = referenceType;
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
            if (resultOfConverting != null)
            {
                return this.theUniueIdentifier == resultOfConverting.TheUniueIdentifier;
            }
            return false;
        }
    }
}
