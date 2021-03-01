using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
    public class ReferenceForLesson: IamTheElementOfTrainingWebsite, IamReferenceOnSource
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

        private string urlOfContent;
        public string UrlOfContent
        {
            get
            {
                if (urlOfContent != null)
                {
                    return urlOfContent;
                }
                else
                {
                    return null;
                }
            }

            set
            {           
                if(value != null)
                {
                    if(value != "")
                    {
                        urlOfContent = value;
                    }              
                }             
            }
        }
        public TypeOfReference TypeOFReference { get; set; }


        public ReferenceForLesson(string textDescriptions, string urlOfContent, TypeOfReference typeOFReference)
        {
            this.textDescriptions = textDescriptions;
            if(textDescriptions != null)
            {
                if (textDescriptions.Length > 256)
                {
                    throw new ArgumentException();
                }
            }        
            this.urlOfContent = urlOfContent;
            if (urlOfContent == null)
            {
                throw new ArgumentNullException();
            }
            if(urlOfContent == "")
            {
                throw new ArgumentException();
            }
            this.TypeOFReference = typeOFReference;
            this.theUniueidentifier = TheUniueidentifier.CreateUniqueIdentifier();
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

    }
}
