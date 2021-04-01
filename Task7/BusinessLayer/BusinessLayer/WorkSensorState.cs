using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class WorkSensorState: ISensorState
    {
        public void ChangeState(Sensor measuringSensor)
        {
            measuringSensor.SensorState = new DowntimeSensorState();
            Thread threadSensor = new Thread(new ParameterizedThreadStart(measuringSensor.SensorState.Work));
            threadSensor.Start(measuringSensor);
        }

        public void Work(object obj)
        {
            Sensor measuringSensor = (Sensor)obj;
            Random randonNum = new Random();
            while (measuringSensor.SensorState is WorkSensorState)
            {
                measuringSensor.MeasuredValue = randonNum.Next(0,10);
                Thread.Sleep((int)measuringSensor.MeasurementInterval * 1000);
            }
        }
    }
}
