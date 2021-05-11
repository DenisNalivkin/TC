using System;

namespace DataBase
{/// <summary>
/// Class UniqueSensorIdentifier stores a method CreateUniqueSensorIdentifier that generates unique indicators for sensors.
/// </summary>
    public class UniqueSensorIdentifier
    {
        private static UniqueSensorIdentifier instance;

        private UniqueSensorIdentifier()
        { }
        /// <summary>
        ///  GetInstance method returns an object of the UniqueSensorIdentifier class.
        /// </summary>
        /// <returns>A new object of the UniqueSensorIdentifier class if the UniqueSensorIdentifier object is created for the first time, otherwise the previously created UniqueSensorIdentifier object is returned. </returns>
        public static UniqueSensorIdentifier getInstance()
        {
            if (instance == null)
                instance = new UniqueSensorIdentifier();
            return instance;
        }
        /// <summary>
        /// CreateUniqueSensorIdentifier method returns unique identifiers for sensors.
        /// </summary>
        /// <returns> The unique identifiers for sensors. </returns>
        public Guid CreateUniqueSensorIdentifier()
        {
            return Guid.NewGuid();
        }
    }
}



