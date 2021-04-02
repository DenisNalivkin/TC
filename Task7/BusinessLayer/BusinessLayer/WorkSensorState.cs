﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class WorkSensorState: ISensorState, IObservable
    {
        public void ChangeState(Sensor measuringSensor)
        {
            measuringSensor.SensorState = new DowntimeSensorState();
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
            Random randonNum = new Random();
            while (measuringSensor.SensorState is WorkSensorState)
            {
                measuringSensor.MeasuredValue = randonNum.Next(0,10);
                Thread.Sleep((int)measuringSensor.MeasurementInterval * 1000);
            }
        }
    }
}