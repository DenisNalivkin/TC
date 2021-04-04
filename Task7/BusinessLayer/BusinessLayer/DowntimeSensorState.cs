using System;
using System.Threading.Tasks;

namespace BusinessLayer
{ 
    public class DowntimeSensorState: ISensorState, IObservable
    {
        public void ChangeState(Sensor measuringSensor)
        {
            measuringSensor.SensorState = new CalibrationSensorState();
            NotifyObservers(measuringSensor);
            Action<object> method = x => { measuringSensor.SensorState.Work(measuringSensor); };          
            var task1 = new Task(method, measuringSensor);
            task1.Start();
        }
           
        public void Work(object obj)
        {                   
        }

        public void NotifyObservers(Sensor sensor)
        {
            SensorObserver sensorObserver = SensorObserver.GetInstance();
            sensorObserver.Update(sensor);
        }
    }
}
