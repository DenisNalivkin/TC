using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{/// <summary>
/// Class WorkSensorState has methods ChangeState, Work and NotifyObservers.
/// </summary>
    public class WorkSensorState: ISensorState, IObservable
    {
        CancellationTokenSource cancelTokenSourceWorkSensor;
        CancellationToken tokenWorkSensor;
        /// <summary>
        /// Public constructor initializing the fields of the WorkSensorState class object.
        /// </summary>
        public WorkSensorState()
        {
            cancelTokenSourceWorkSensor = new CancellationTokenSource();
            tokenWorkSensor = cancelTokenSourceWorkSensor.Token;
        }
        /// <summary>
        /// The ChangeState method changes the SensorState of the current sensor to DowntimeSensorState, and a working method is called which does not change measured value.
        /// </summary>
        /// <param name="measuringSensor"> The sensor in which will change SensorState </param>
        public void ChangeState(Sensor measuringSensor)
        {
            cancelTokenSourceWorkSensor.Cancel();
            measuringSensor.SensorState = new DowntimeSensorState();
            NotifyObservers(measuringSensor);
            Action<object> method = x => { measuringSensor.SensorState.Work(measuringSensor); };            
            var task3 = new Task(method, measuringSensor);
            task3.Start();
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
        /// <summary>
        /// Method work  changes the measured value of the sensor by random numbers at the specified time interval.
        /// </summary>
        /// <param name="obj"> A Sensor object, placed in an object of the super base class Object, where the measured value will change. </param>
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


