using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TemperatureSensorManufacturer : SensorManufacturer
    {
        public override Sensor CreateSensor(SensorType sensorType, int? measurementInterval)
        {
            return new TemperatureSensor(sensorType, measurementInterval);
        }
    }
}
