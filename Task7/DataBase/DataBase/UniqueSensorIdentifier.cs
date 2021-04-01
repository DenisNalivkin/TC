using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class UniqueSensorIdentifier
    {
        private static UniqueSensorIdentifier instance;

        private UniqueSensorIdentifier()
        { }

        public static UniqueSensorIdentifier getInstance()
        {
            if (instance == null)
                instance = new UniqueSensorIdentifier();
            return instance;
        }
        public Guid CreateUniqueSensorIdentifier()
        {
            return Guid.NewGuid();
        }
    }
}
