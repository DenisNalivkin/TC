using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MagneticFieldSensorSensorManufacturer : SensorManufacturer
    {
        public override Sensor CreateSensor(SensorType sensorType, int? measurementInterval)
        {
            return new MagneticFieldSensor(sensorType, measurementInterval);
        }
    }
}
