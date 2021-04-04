using System;

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
