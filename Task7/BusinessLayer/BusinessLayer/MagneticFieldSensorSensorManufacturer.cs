using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{/// <summary>
/// The MagneticFieldSensorSensorManufacturer class has a CreateSensor method that creates magnetic field sensors.
/// </summary>
    public class MagneticFieldSensorSensorManufacturer : SensorManufacturer
    {/// <summary>
     /// CreateSensor method creates magnetic field sensors.
     /// </summary>
     /// <param name="sensorType"> Value for sensorType.</param>
     /// <param name="measurementInterval">Value for measurementInterval.</param>
     /// <returns> Object of class Sensor.</returns>
        public override Sensor CreateSensor(SensorType sensorType, int? measurementInterval)
        {
            return new MagneticFieldSensor(sensorType, measurementInterval);
        }
    }
}
