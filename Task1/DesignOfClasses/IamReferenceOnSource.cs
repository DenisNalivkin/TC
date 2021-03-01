using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
   public interface IamReferenceOnSource
    {
        string UrlOfContent { get; set; }
        TypeOfReference TypeOFReference { get; set; }
    }
}
