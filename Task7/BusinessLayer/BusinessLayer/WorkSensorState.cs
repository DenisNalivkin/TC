using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class WorkSensorState: ISensorState, IObservable
    {
        CancellationTokenSource cancelTokenSourceWorkSensor;
        CancellationToken tokenWorkSensor;

        public WorkSensorState()
        {
            cancelTokenSourceWorkSensor = new CancellationTokenSource();
            tokenWorkSensor = cancelTokenSourceWorkSensor.Token;
        }

        public void ChangeState(Sensor measuringSensor)
        {
            cancelTokenSourceWorkSensor.Cancel();
            measuringSensor.SensorState = new DowntimeSensorState();
            NotifyObservers(measuringSensor);
            Action<object> method = x => { measuringSensor.SensorState.Work(measuringSensor); };            
            var task3 = new Task(method, measuringSensor);
            task3.Start();
        }

        public void NotifyObservers(Sensor sensor)
        {
            SensorObserver sensorObserver = SensorObserver.GetInstance();
            sensorObserver.Update(sensor);
        }

        public void Work(object obj)
        {
            Sensor measuringSensor = (Sensor)obj;
            Random randonNum = new Random();
            while (measuringSensor.SensorState is WorkSensorState)
            {
                if (tokenWorkSensor.IsCancellationRequested)
                {
                    return;
                }
                measuringSensor.MeasuredValue = randonNum.Next(0,10);
                Thread.Sleep((int)measuringSensor.MeasurementInterval * 1000);
            }
        }
    }
}
