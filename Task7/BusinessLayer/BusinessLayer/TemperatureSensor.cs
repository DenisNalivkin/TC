using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TemperatureSensor:Sensor
    {
        public Guid UniqueIdentificator { get; }
        public SensorType SensorType { get; }
        public ISensorState SensorState { get; set; }
        public int? MeasurementInterval { get; protected set; }
        public int? MeasuredValue { get; protected set; }

        public TemperatureSensor(SensorType sensorType, int? measurementInterval) :
          base(sensorType, measurementInterval)
        {
        }

    }
}
