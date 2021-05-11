using System;

namespace BusinessLayer
{/// <summary>
/// Class MagneticFieldSensor stores information about a magnetic field sensor.
/// </summary>
    public class MagneticFieldSensor:Sensor
    {
        public Guid UniqueIdentificator { get; }
        public SensorType SensorType { get; }
        public ISensorState SensorState { get; set; }
        public int? MeasurementInterval { get; protected set; }
        public int? MeasuredValue { get; protected set; }
        /// <summary>
        /// Public constructor initializing the fields of the MagneticFieldSensor class object.
        /// </summary>
        /// <param name="sensorType">Value for the field sensorType.</param>
        /// <param name="measurementInterval">Value for the field measurementInterval.</param>
        public MagneticFieldSensor(SensorType sensorType, int? measurementInterval) :
          base(sensorType, measurementInterval)
        {

        }
    }
}
