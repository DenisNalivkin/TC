using System;

namespace DataBase
{
    public class AbstractSensor
    {
        public Guid UniqueIdentificator { get; }
        public string SensorType { get; }
        public string SensorState { get; set; }
        public int? MeasurementInterval { get; protected set; }
        public int? MeasuredValue { get; protected set; }

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
