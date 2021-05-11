using System;
using System.Collections.Generic;

namespace BusinessLayer
{/// <summary>
/// The SensorObserver class maintains and updates a log of sensors state changes.
/// </summary>
    public class SensorObserver : IObserver
    {
        private static SensorObserver singleSensorObserver;
        public static List<string> SensorStateChangeLog { get; set; }
        
        private SensorObserver()
        {           
        }
        /// <summary>
        /// GetInstance method returns an object of the SensorObserver class.
        /// </summary>
        /// <returns>A new object of the SensorObserver class if the SensorObserver object is created for the first time, otherwise the previously created SensorObserver object is returned.</returns>
        public static SensorObserver GetInstance()
        {
            if (singleSensorObserver == null)
            {
                singleSensorObserver = new SensorObserver();
                SensorObserver.SensorStateChangeLog = new List<string>();              
            }
            return singleSensorObserver;
        }
        /// <summary>
        /// Update method adds a new entry to the SensorStateChangeLog. 
        /// </summary>
        /// <param name="obj">The Sensor object placed in the super base class Object where the state change occurred.</param>
        public void Update(object obj)
        {
            Sensor sensor = (Sensor)obj;
            SensorStateChangeLog.Add($"{DateTime.Now} {sensor.SensorTypeUniqueIdentificator} mode was changed on {sensor.SensorState.ToString().Substring(14)}!");
        }
    }
}
