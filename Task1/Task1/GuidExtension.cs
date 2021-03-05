using System;
namespace Task1
{/// <summary>
 /// Static class GuidExtension stores method extension for class Guid.
 /// </summary>
    public static class GuidExtension
    {
        public static Guid CreateIdentifier( this Guid guid )
        {
            return Guid.NewGuid();
        }
    }
}
