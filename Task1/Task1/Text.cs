using System;
namespace Task1
{
    /// <summary>
    ///   Text class stores text for lesson.
    /// </summary>
    public class Text : GeneralEntity, ICloneable
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
                if ( value == null || value.Length <= LengthDescription )
                {
                    _textDescription = value;
                    return;
                }
                throw new ArgumentOutOfRangeException();
            }
        }
        private string _text;
        public string _Text
        {
            get
            {
                return _text;
            }
            set
            {
                if ( !String.IsNullOrEmpty(value) && value.Length <= lengthText )
                {
                    _text = value;
                    return;
                }
                throw new ArgumentException();
            }
        }

        public Text ( string textDescription, string textLesson )
        {
            this._uniqueIdentifier = _uniqueIdentifier.CreateIdentifier();
            this.TextDescription = textDescription;           
            this._Text = textLesson;                         
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
            Text text = new Text( this.TextDescription, this._Text );
            return text;
        }
    }
    }

