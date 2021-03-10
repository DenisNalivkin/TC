using System;
namespace Task1
{
    /// <summary>
    ///   Text class stores text for lesson.
    /// </summary>
    public class Text : GeneralEntity, ICloneable
    {   
        const int lengthText = 10000;
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

        public Text ( string textDescription, string textLesson ) : base (textDescription)
        {                
            this._Text = textLesson;                         
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

