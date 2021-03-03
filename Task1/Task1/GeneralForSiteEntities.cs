using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{/// <summary>
///  Abstract class which stores generals properties for site entities.
/// </summary>
    public abstract class GeneralForSiteEntities
    {
       public abstract System.Guid TheUniueIdentifier { get; }
       public abstract string TextDescription { get; set; }    
    }
}
