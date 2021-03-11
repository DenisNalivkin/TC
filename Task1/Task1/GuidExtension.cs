using System;
namespace Task1
{/// <summary>
 /// Static class GuidExtension stores method extension for class Guid.
 /// </summary>
    public static class GuidExtension
    {/// <summary>
     ///  CreateIdentifier method creates unique identifier for objects.
     /// </summary>
     /// <param name="guid"> The unique identifier. </param>
     /// <returns></returns>
        public static Guid CreateIdentifier( this Guid guid )
        {
            return Guid.NewGuid();
        }        
    }
}
