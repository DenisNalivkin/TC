using System;
namespace Task1
{
    /// <summary>
    ///  Video class stores video for lesson.
    /// </summary>
    public class Video : GeneralForSiteEntities, IVersionable, ICloneable
    {
        const int LengthVersion = 8;
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
               if( value == null || value.Length <= lengthDescription )
                {
                    _textDescription = value;
                    return;
                }
                throw new ArgumentOutOfRangeException();
            }
        }
        private string _urlVideo;
        public string UrlVideo
        {
            get
            {
                return _urlVideo;
            }
            set
            {
                if ( !String.IsNullOrEmpty(value) )
                {
                    _urlVideo = value;
                    return;
                }                
                   throw new ArgumentException();             
            }
        }
        private byte[] _version;
        public byte[] Version
        {
            get
            {               
                return _version;
            }
            set
            {
                if( value != null && value.Length == LengthVersion )
                {
                    _version = new byte[LengthVersion];
                    Array.Copy( value, _version, value.Length );                   
                    return;
                }
                throw new ArithmeticException();
            }
        }
        public string UrlPicture { get; set; }
        public VideFormat FormatVideo { get; set; }

        public Video ( string textDescription, string urlVideo, string urlPicture, VideFormat formatVideo, byte[] version )
        {
            this._uniqueIdentifier = _uniqueIdentifier.CreateIdentifier();
            this.TextDescription = textDescription;
            this.UrlVideo = urlVideo;
            this.UrlPicture = urlPicture;
            this.FormatVideo = formatVideo;
            this.Version = version;
        } 
        
        public Video()
        {

        }
        /// <summary>
        ///  Clone method copies object of class Video.
        /// </summary>
        /// <returns> Copy of the Video. </returns>
        public object Clone()
        {
            Video video = new Video( this.TextDescription, this.UrlVideo, this.UrlPicture, this.FormatVideo, this.Version ); 
            return video;            
        }
    }
}
        
          


     


    

