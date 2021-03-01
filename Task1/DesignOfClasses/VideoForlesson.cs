using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
   public class VideoForlesson: IamTheElementOfTrainingWebsite, IamVideo, IVersionable
    {
        private Guid theUniueidentifier;
        public Guid TheUniueidentifier
        {
            get
            {
                return theUniueidentifier;
            }
            set
            {
                if(theUniueidentifier == null)
                {
                    theUniueidentifier = value;
                }
            }

        }    
        private string textDescriptions;
        public string TextDescriptions
        {
            get
            {
                if (textDescriptions != null)
                {
                    return textDescriptions;
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (value.Length <= 256)
                {
                    textDescriptions = value;
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
                if (value != null && value != "")
                {
                    urlVideo = value;
                }
            }
        }
        public string UrlPictureForVideo { get; set; }
        private VideoFormat formatVideo;
        public VideoFormat FormatVideo
        {
            get
            {
                return formatVideo;
            }

            set
            {
                formatVideo = value;
            }
        }

        private byte[] version;
        public byte[] Version
        {
            get
            {
                return version;
            }

            set
            {
                if (version == null)
                {
                    version = value;
                }
            }
        }


        public VideoForlesson(string textDescriptions, string urlVideo, string UrlPictureForVideo, VideoFormat formatVideo)
        {
            this.textDescriptions = textDescriptions;
            if(textDescriptions != null)
            {
                if (textDescriptions.Length > 256)
                {
                    throw new ArgumentException();
                }
            }
            this.urlVideo = urlVideo;
            if (UrlVideo == null || UrlVideo =="")
            {
                throw new ArgumentNullException();
            }

            this.UrlPictureForVideo = UrlPictureForVideo;
            this.formatVideo = formatVideo;
            this.theUniueidentifier = TheUniueidentifier.CreateUniqueIdentifier();
            this.version = null;
        }


        public override string ToString()
        {
            return this.TextDescriptions;
        }
        public override bool Equals(object obj)
        {
            bool resultCompare = false;
            IamTheElementOfTrainingWebsite resultTransformation = obj as IamTheElementOfTrainingWebsite;
            if (resultTransformation == null)
            {

                throw new InvalidCastException();
            }
            else
            {
                resultCompare = this.theUniueidentifier == resultTransformation.TheUniueidentifier;
            }
            return resultCompare;
        }
        public void InstallVersion(string vers)
        {
            if (this.version == null)
            {
                if (vers.Length > 8)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.version = System.Text.Encoding.Default.GetBytes(vers);
                }
            }
        }
        public void ReadVersion()
        {
            if (this.version == null)
            {
                throw new NullReferenceException();
            }

            string version = null;
            try
            {
                version = System.Text.Encoding.Default.GetString(this.version);
            }
            catch
            {
                throw new InvalidCastException();
            }
            Console.WriteLine(version);
        }

    }
}
