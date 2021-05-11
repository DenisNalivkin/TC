using System;

namespace BusinessLayer
{   /// <summary>
    /// Class TemperatureSensor stores information about a temperature sensor.
    /// </summary>
    public class TemperatureSensor:Sensor
    {
        public Guid UniqueIdentificator { get; }
        public SensorType SensorType { get; }
        public ISensorState SensorState { get; set; }
        public int? MeasurementInterval { get; protected set; }
        public int? MeasuredValue { get; protected set; }
        /// <summary>
        /// Public constructor initializing the fields of the TemperatureSensor class object.
        /// </summary>
        /// <param name="sensorType">Value for the field sensorType.</param>
        /// <param name="measurementInterval">Value for the field measurementInterval.</param>
        public TemperatureSensor(SensorType sensorType, int? measurementInterval) :
          base(sensorType, measurementInterval)
        {
        }

    }
}
