using System;
namespace Task1
{
    /// <summary>
    ///  Video class stores video for lesson.
    /// </summary>
    public class Video : GeneralForSiteEntities, IVersionable
    {
        const int lengthOfDescription = 256;
        const int LengthVersion = 8;
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

        private string urlVideo;
        public string UrlVideo
        {
            get
            {
                return urlVideo;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    textDescription = value;
                }
            }
        }
        private string UrlPicture { get; set; }
        public VideOFormat FormatOfVideo { get; set; }
        private byte[] version;
        public byte[] Version
        {
            get
            {               
                return version;
            }
            set
            {
                if(version!=null && value.Length <= LengthVersion)
                {
                    version = value;
                }
            }
        }
        public Video (string textDescription, string urlVideo, string urlPicture, VideOFormat formatOfVideo)
        {
            this.theUniueIdentifier = theUniueIdentifier.CreateUniqueIdentifier();
            this.textDescription = textDescription;
            if(!string.IsNullOrEmpty(textDescription))
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
            this.urlVideo = urlVideo;
            if(String.IsNullOrEmpty(urlVideo))
            {
                throw new ArgumentOutOfRangeException();
            }
            this.UrlPicture = urlPicture;
            this.FormatOfVideo = formatOfVideo;
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
        
          


     


    

