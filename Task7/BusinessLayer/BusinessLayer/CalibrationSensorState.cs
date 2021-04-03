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

        CancellationTokenSource cancelTokenSource;
        CancellationToken token;

        public CalibrationSensorState()
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        }


        public void ChangeState(Sensor measuringSensor)
        {
            cancelTokenSource.Cancel();
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
                if (token.IsCancellationRequested)
                {
                    return;
                }
                measuringSensor.MeasuredValue += 1;
                Thread.Sleep(1000);
            }
        }

    }
}
