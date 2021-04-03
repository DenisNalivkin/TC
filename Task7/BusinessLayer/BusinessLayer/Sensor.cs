using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace BusinessLayer
{
    public enum SensorType
    {
        PressureSensor,
        TemperatureSensor,
        MagneticFieldSensor,
        UnknownSensor
    }
    public abstract class Sensor
    {         
            public Guid UniqueIdentificator { get; }
            public SensorType SensorType { get; }
            public ISensorState SensorState { get; set; }
            public int? MeasurementInterval { get; set; }
            public int? MeasuredValue { get;  set; }
            public string SensorTypeUniqueIdentificator { get; set;}

            public Sensor(SensorType sensorType, int? measurementInterval)
            {
                UniqueIdentificator = UniqueSensorIdentifier.getInstance().CreateUniqueSensorIdentifier();
                SensorType = sensorType;
                SensorState = new DowntimeSensorState();
                MeasurementInterval = measurementInterval;
                MeasuredValue = 0;
                SensorTypeUniqueIdentificator = $"{SensorType} - {UniqueIdentificator}";
            }
         
        public void ChangeState()
        {
            SensorState.ChangeState(this);
        }
        }
    }

