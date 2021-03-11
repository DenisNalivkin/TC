using System;
namespace Task1
{
    /// <summary>
    ///  Video class stores video for lesson.
    /// </summary>
    public class Video : GeneralEntity, IVersionable, ICloneable
    {
        private const int _lengthVersion = 8;
        int IVersionable.LengthVersion { get { return _lengthVersion; } }
        private string _urlVideo;
        public string UrlVideo
        {
            get
            {
                return _urlVideo;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
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
                if( value != null && value.Length == _lengthVersion)
                {
                    _version = new byte[_lengthVersion];
                    Array.Copy(value, _version, value.Length);                   
                    return;
                }
                throw new ArgumentException();
            }
        }
        public string UrlPicture { get; set; }
        public VideFormat FormatVideo { get; set; }

        /// <summary>
        /// Public constructor initializing the fields of the Video class object.
        /// </summary>
        /// <param name="textDescription"> Value for the field textDescription. </param>
        /// <param name="urlVideo"> Value for the field urlVideo. </param>
        /// <param name="urlPicture"> Value for the field urlPicture. </param>
        /// <param name="formatVideo"> Value for the field formatVideo. </param>
        /// <param name="version"> Value for the field version. </param>
        public Video ( string textDescription, string urlVideo, string urlPicture, VideFormat formatVideo, byte[] version ) : base (textDescription)
        {        
            this.UrlVideo = urlVideo;
            this.UrlPicture = urlPicture;
            this.FormatVideo = formatVideo;
            this.Version = version;
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
        
          


     


    

