using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CalibrationSensorState: ISensorState , IObservable
    {
        public void ChangeState(Sensor measuringSensor)
        {
            measuringSensor.SensorState = new WorkSensorState();
            NotifyObservers(measuringSensor);
            Action<object> method = x => { measuringSensor.SensorState.Work(measuringSensor); };
            var task2 = new Task(method, measuringSensor);
            task2.Start();
        }

        public void NotifyObservers(Sensor sensor)
        {
            SensorObserver sensorObserver = SensorObserver.GetInstance();
            sensorObserver.Update(sensor);
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
