using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DowntimeSensorState: ISensorState
    {
        public void ChangeState(Sensor measuringSensor)
        {
            measuringSensor.SensorState = new CalibrationSensorState();
            Thread threadSensor = new Thread(new ParameterizedThreadStart(measuringSensor.SensorState.Work));
            threadSensor.Start(measuringSensor);
        }

        private void IncreaseMeasuredValue(object obj)
        {
            Sensor measuringSensor = (Sensor)obj;
            measuringSensor.MeasuredValue += 1;            
        }

        public void Work(object obj)
        {
            Sensor measuringSensor = (Sensor)obj;
            while (measuringSensor.SensorState is CalibrationSensorState)
            {
                continue;
            }
        }
     


    }
}
