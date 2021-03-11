namespace Task1
{/// <summary>
/// Abstract class which stores generals properties for training site entities.
/// </summary>
    public abstract class GeneralEntity
    {
        public const int LengthDescription = 256;
        private System.Guid _uniqueIdentifier;
        public System.Guid UniqueIdentifier
        {
            get
            {
                return _uniqueIdentifier;
            }
            set
            {
                if( _uniqueIdentifier == null )
                {
                    _uniqueIdentifier = value;
                }
            }          
        }       
        private string _textDescription;
        public string TextDescription
        {
            get
            {
                return _textDescription;
            }
            set
            {
                if (value == null || value.Length <= LengthDescription)
                {
                    _textDescription = value;
                    return;
                }
                throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///  The public constructor GeneralEntity is called by the inheriting classes and initializes the fields common to them.
        /// </summary>
        /// <param name="textDescription"> Value for the field textDescription. </param>
        public GeneralEntity (string textDescription)
        {
             _uniqueIdentifier = UniqueIdentifier.CreateIdentifier();
             TextDescription = textDescription;
        }

        /// <summary>
        /// Overridden ToString method.
        /// </summary>
        /// <returns> String type. </returns>
        public override string ToString()
        {
            return this.TextDescription;
        }
        
        /// <summary>
        ///  Overridden Equals method.
        /// </summary>
        /// <param name="obj"> The second operand for compare.</param>
        /// <returns> True if both operands are equals, or false if not equals. </returns>
        public override bool Equals( object obj )
        {
            GeneralEntity resultConverting = obj as GeneralEntity;
            if ( resultConverting != null )
            {
                return UniqueIdentifier == resultConverting.UniqueIdentifier;
            }
            return false;
        }
    }
}
