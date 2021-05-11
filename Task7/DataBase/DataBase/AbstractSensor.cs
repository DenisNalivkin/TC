using System;

namespace DataBase
{/// <summary>
/// Сlass AbstractSensor stores inforantion about a sensor. 
/// </summary>
    public class AbstractSensor
    {
        public Guid UniqueIdentificator { get; }
        public string SensorType { get; }
        public string SensorState { get; set; }
        public int? MeasurementInterval { get; protected set; }
        public int? MeasuredValue { get; protected set; }
        /// <summary>
        /// Public constructor initializing the fields of the AbstractSensor class object.
        /// </summary>
        /// <param name="sensorType">Value for the field sensorType.</param>
        /// <param name="sensorState">Value for the field sensorState.</param>
        /// <param name="measurementInterval">Value for the field measurementInterval.</param>
        /// <param name="measuredValue">Value for the field measuredValue.</param>
        public AbstractSensor( string sensorType, string sensorState, int? measurementInterval, int? measuredValue)
        {
            UniqueIdentificator = UniqueSensorIdentifier.getInstance().CreateUniqueSensorIdentifier();
            SensorType = sensorType;
            SensorState = null;
            MeasurementInterval = measurementInterval;
            MeasuredValue = 0;
        }      
    }
}
