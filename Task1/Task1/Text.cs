using System;
namespace Task1
{
    /// <summary>
    ///   Text class stores text for lesson.
    /// </summary>
    public class Text : GeneralForSiteEntities, ICloneable
    {   
        const int lengthText = 10000;
        private Guid _uniqueIdentifier;
        public override Guid UniqueIdentifier
        {
            get
            {
                return _uniqueIdentifier;
            }
        }
        private string _textDescription;
        public override string TextDescription
        {
            get
            {
                return _textDescription;
            }
            set
            {
                if ( value == null || value.Length <= lengthDescription )
                {
                    _textDescription = value;
                    return;
                }
                throw new ArgumentOutOfRangeException();
            }
        }
        private string _textLesson;
        public string TextLesson
        {
            get
            {
                return _textLesson;
            }
            set
            {
                if ( !String.IsNullOrEmpty(value) && value.Length <= lengthText )
                {
                    _textLesson = value;
                    return;
                }
                throw new ArgumentException();
            }
        }

        public Text ( string textDescription, string textLesson )
        {
            this._uniqueIdentifier = _uniqueIdentifier.CreateIdentifier();
            this.TextDescription = textDescription;           
            this.TextLesson = textLesson;                         
        }

        public Text()
        {

        }
        /// <summary>
        ///  Clone method copies object of class Text.
        /// </summary>
        /// <returns>  Copy of the Text. </returns>
        public object Clone()
        {
            Text text = new Text( this.TextDescription, this.TextLesson );
            return text;
        }
    }
    }

