using System;
namespace Task1
{/// <summary>
/// ReferenceTraining class stores references for lesson.
/// </summary>
    class ReferenceTraining : GeneralEntity, ICloneable
    {
        private string _referenceContent;
        public string ReferenceContent
        {
            get
            {
                return _referenceContent;
            }
            set
            {
                if( !string.IsNullOrEmpty( value ) )
                {
                   _referenceContent = value;
                    return;
                }
                throw new ArgumentException();
            }
        }
        public TypeReference ReferenceType { get; set; }

        /// <summary>
        ///  Public constructor initializing the fields of the ReferenceTraining  class object.
        /// </summary>
        /// <param name="textDescription"> Value for the field textDescription. </param>
        /// <param name="referenceContent"> Value for the field referenceContent. </param>
        /// <param name="referenceType"> Value for the field referenceType. </param>
        public ReferenceTraining( string textDescription, string referenceContent, TypeReference referenceType ) :base (textDescription)
        {
            this.ReferenceContent = referenceContent;           
            this.ReferenceType = referenceType;
        }

        /// <summary>
        ///  Clone method copies object of class Reference.
        /// </summary>
        /// <returns>  Copy of the Reference. </returns>
        public object Clone()
        {
            ReferenceTraining reference = new ReferenceTraining( this.TextDescription, this.ReferenceContent, this.ReferenceType );
            return reference;
        }
    }
}
