using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
    class Lesson : IamTheElementOfTrainingWebsite, IVersionable, ICloneable
    {

        public Guid theUniueidentifier;
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
        private int amountKindsOfMaterialForLesson = 3;


        public IamTheElementOfTrainingWebsite[] MaterialsForLesson;


        public Lesson(IamTheElementOfTrainingWebsite textForLesson, IamTheElementOfTrainingWebsite videoForLesson, IamTheElementOfTrainingWebsite ReferenceOnWebResource, string textDescriptions)
        {
            
            MaterialsForLesson = new IamTheElementOfTrainingWebsite[amountKindsOfMaterialForLesson];
            MaterialsForLesson[0] = textForLesson;
            MaterialsForLesson[1] = videoForLesson;
            MaterialsForLesson[2] = ReferenceOnWebResource;
            this.textDescriptions = textDescriptions; 
            if(textDescriptions != null)
            {
                if (textDescriptions.Length > 256)
                {
                    throw new ArgumentException();
                }
            }        
            this.theUniueidentifier = TheUniueidentifier.CreateUniqueIdentifier();
            this.version = null;

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
        public KindsOfLessons ShowKindOfLesson()
        {
            KindsOfLessons kindOfLesson;
            if (MaterialsForLesson[1] is IamVideo)
            {
                Console.WriteLine("It is video lesson.");
                kindOfLesson = KindsOfLessons.TextLesson;

            }
            else
            {
                Console.WriteLine("It is text lesson.");
                kindOfLesson = KindsOfLessons.TextLesson;
            }
            return kindOfLesson;
        }
        public override string ToString()
        {
            return this.TextDescriptions;
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
        public object Clone()
        {       
            return new Lesson(this.MaterialsForLesson[0],this.MaterialsForLesson[1],this.MaterialsForLesson[2],this.textDescriptions)
            {
                TheUniueidentifier = this.theUniueidentifier,
                TextDescriptions = this.textDescriptions,
                Version = this.version,
                amountKindsOfMaterialForLesson = MaterialsForLesson.Length,
            };
        }
    }
     
}
