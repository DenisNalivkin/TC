using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{/// <summary>
/// Class CalibrationSensorState has methods ChangeState, Work and NotifyObservers.
/// </summary>
    public class CalibrationSensorState: ISensorState , IObservable
    {
        CancellationTokenSource cancelTokenSourceCalibration;
        CancellationToken tokenCalibration;
        /// <summary>
        /// Public constructor initializing the fields of the CalibrationSensorState class object.
        /// </summary>
        public CalibrationSensorState()
        {
            cancelTokenSourceCalibration = new CancellationTokenSource();
            tokenCalibration = cancelTokenSourceCalibration.Token;
        }
        /// <summary>
        /// The ChangeState method changes the SensorState of the current sensor to WorkSensorState, and a work method is called that changes the measured value of the sensor by random numbers at the specified time interval.
        /// </summary>
        /// <param name="measuringSensor">The sensor in which will change SensorState.</param>
        public void ChangeState(Sensor measuringSensor)
        {              
           cancelTokenSourceCalibration.Cancel();
           measuringSensor.SensorState = new WorkSensorState();
           NotifyObservers(measuringSensor);
           Action<object> method = x => { measuringSensor.SensorState.Work(measuringSensor); };
           var task2 = new Task(method, measuringSensor);
           task2.Start();                 
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
        /// Method Work changes the measured value of the sensor by +1 once per second.
        /// </summary>
        /// <param name="obj"> A Sensor object, placed in an object of the super base class Object, where the measured value will change. </param>
        public void Work(object obj)
        {
            Sensor measuringSensor = (Sensor)obj;
            while (measuringSensor.SensorState is CalibrationSensorState)
            {
                if (tokenCalibration.IsCancellationRequested)
                {
                    return;
                }
                measuringSensor.MeasuredValue += 1;
                Thread.Sleep(1000);
            }
        }
    }
}

