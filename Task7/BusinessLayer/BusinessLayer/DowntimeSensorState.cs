using System;
using System.Threading.Tasks;

namespace BusinessLayer
{ /// <summary>
/// Class DowntimeSensorState has methods ChangeState, Work and NotifyObservers.
/// </summary>
    public class DowntimeSensorState: ISensorState, IObservable
    {/// <summary>
     /// The ChangeState method changes the SensorState of the current sensor to CalibrationSensorState, the work method is also called, which changes the measured value of the sensor by +1 once per second.
     /// </summary>
     /// <param name="measuringSensor"> The sensor in which will change SensorState.</param>
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
        /// <summary>
        /// Method NotifyObservers adds a new entry to the SensorStateChangeLog.
        /// </summary>
        /// <param name="sensor">The sensor in which the state has changed.</param>
        public void NotifyObservers(Sensor sensor)
        {
            SensorObserver sensorObserver = SensorObserver.GetInstance();
            sensorObserver.Update(sensor);
        }
    }
}


