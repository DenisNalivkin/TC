using System;
using DataBase;

namespace BusinessLayer
{/// <summary>
/// Enum SensorType contains a list of sensor types.
/// </summary>
    public enum SensorType
    {
        PressureSensor,
        TemperatureSensor,
        MagneticFieldSensor,
        UnknownSensor
    }
    /// <summary>
    /// Сlass Sensor stores inforantion about a sensor.
    /// </summary>
    public abstract class Sensor
    {         
        public Guid UniqueIdentificator { get; }
        public SensorType SensorType { get; }
        public ISensorState SensorState { get; set; }
        public int? MeasurementInterval { get; set; }
        public int? MeasuredValue { get;  set; }
        public string SensorTypeUniqueIdentificator { get; set;}
        /// <summary>
        /// Public constructor initializing the fields of the Sensor class object.
        /// </summary>
        /// <param name="sensorType">Value for the field sensorType.</param>
        /// <param name="measurementInterval">Value for the field measurementInterval.</param>
        public Sensor(SensorType sensorType, int? measurementInterval)
        {
           UniqueIdentificator = UniqueSensorIdentifier.getInstance().CreateUniqueSensorIdentifier();
           SensorType = sensorType;
           SensorState = new DowntimeSensorState();
           MeasurementInterval = measurementInterval;
           MeasuredValue = 0;
           SensorTypeUniqueIdentificator = $"{SensorType} - {UniqueIdentificator}";
        }
        /// <summary>
        /// Method ChangeState changes value of the field SensorState of the current sensor.
        /// </summary>
        public void ChangeState()
        {
            SensorState.ChangeState(this);
        }
    }
}

