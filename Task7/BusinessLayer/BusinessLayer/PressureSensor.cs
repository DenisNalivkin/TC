using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{/// <summary>
/// Class PressureSensor stores information about a pressure sensor.
/// </summary>
    public class PressureSensor: Sensor
    {
        public Guid UniqueIdentificator { get; }
        public SensorType SensorType { get; }
        public ISensorState SensorState { get; set; }
        public int? MeasurementInterval { get; protected set; }
        public int? MeasuredValue { get; protected set; }
        /// <summary>
        /// Public constructor initializing the fields of the PressureSensor class object.
        /// </summary>
        /// <param name="sensorType">Value for the field sensorType.</param>
        /// <param name="measurementInterval">Value for the field measurementInterval.</param>
        public PressureSensor(SensorType sensorType, int? measurementInterval) :
          base(sensorType, measurementInterval)
        {

        }
    }
}
