using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{/// <summary>
 /// Static class GuidExtension stores method extension for class Guid.
 /// </summary>
    public static class GuidExtension
    {
        public static Guid CreateUniqueIdentifier(this Guid guid)
        {
            return Guid.NewGuid();
        }
    }
}
