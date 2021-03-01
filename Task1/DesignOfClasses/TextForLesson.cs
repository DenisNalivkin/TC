using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
    public class TextForLesson: IamTheElementOfTrainingWebsite, IamText
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
        private string textFoRLesson;
        public string TextFoRLesson
        {
            get
            {
                return textFoRLesson;
            }

            set
            {
                if(value != null)
                {
                    if (value.Length < 10000 && value !="")
                    {
                        textFoRLesson = value;
                    }
                }                                  
            }
        }


        public TextForLesson(string textDescriptions, string textFoRLesson)
        {
            this.textDescriptions = textDescriptions;
            if(textDescriptions != null)
            {
                if (textDescriptions.Length > 256)
                {
                    throw new ArgumentException();
                }
            }

            this.textFoRLesson = textFoRLesson;
            if(textFoRLesson != null)
            {
                if (textFoRLesson.Length > 10000 || textFoRLesson == "")
                {
                    throw new ArgumentException();
                }
            }
            if (textFoRLesson == null)
            {
                throw new ArgumentNullException();
            }
           this.theUniueidentifier = TheUniueidentifier.CreateUniqueIdentifier();
        }


        public override string ToString()
        {
            return TextDescriptions;
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
