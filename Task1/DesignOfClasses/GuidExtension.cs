using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
   public static class GuidExtension
    {
        public static Guid CreateUniqueIdentifier(this Guid guid)
        {
            return Guid.NewGuid();
        }
    }
}
