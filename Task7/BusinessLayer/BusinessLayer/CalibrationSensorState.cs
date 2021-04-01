using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CalibrationSensorState: ISensorState
    {
        public void ChangeState(Sensor measuringSensor)
        {
            measuringSensor.SensorState = new WorkSensorState();
            Thread threadSensor = new Thread(new ParameterizedThreadStart(measuringSensor.SensorState.Work));
            threadSensor.Start(measuringSensor);           
        }

        public void Work(object obj)
        {
            Sensor measuringSensor = (Sensor)obj;
            while (measuringSensor.SensorState is CalibrationSensorState)
            {
                measuringSensor.MeasuredValue += 1;
                Thread.Sleep(1000);
            }
        }
    }
}
