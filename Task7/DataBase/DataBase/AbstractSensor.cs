using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public int Сalibrate()
        {
            Thread threadSensor = null;
            int valueForMeasuredValue = 0;
            while (true)
            {
                threadSensor = new Thread(new ParameterizedThreadStart(IncreaseMeasuredValue));
                threadSensor.Start(valueForMeasuredValue);
                Thread.Sleep(1000);
                if (!threadSensor.IsAlive)
                {
                    threadSensor = null;
                }
                valueForMeasuredValue += 1;
            }
        }
        public int Work()
        {
            Thread threadSensor = null;
            Random randomNumber = new Random();
            while (true)
            {
                randomNumber.Next();
                threadSensor = new Thread(new ParameterizedThreadStart(IncreaseMeasuredValue));
                threadSensor.Start(randomNumber);
                Thread.Sleep((int)MeasurementInterval * 1000);
                if (!threadSensor.IsAlive)
                {
                    threadSensor = null;
                }
            }
        }
        private void IncreaseMeasuredValue(object obj)
        {
            MeasuredValue += (int)obj;
        }
        private void RandomMeasuredValue(object obj)
        {
            MeasuredValue = (int)obj;
        }             
    }
}
