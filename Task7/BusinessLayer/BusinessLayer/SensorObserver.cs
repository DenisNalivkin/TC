using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class SensorObserver : IObserver
    {
        private static SensorObserver singleSensorObserver;
        public static List<string> SensorStateChangeLog { get; set; }
        
        private SensorObserver()
        {           
        } 

        public static SensorObserver GetInstance()
        {
            if (singleSensorObserver == null)
            {
                singleSensorObserver = new SensorObserver();
                SensorObserver.SensorStateChangeLog = new List<string>();              
            }
            return singleSensorObserver;
        }

        public void Update(object obj)
        {
            Sensor sensor = (Sensor)obj;
            SensorStateChangeLog.Add($"{DateTime.Now} {sensor.SensorTypeUniqueIdentificator} mode was changed on {sensor.SensorState.ToString().Substring(14)}!");
        }
    }
}
