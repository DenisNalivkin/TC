using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public abstract class SensorManufacturer
    {
        abstract public Sensor CreateSensor(SensorType sensorType, int? measurementInterval);
    }
}
