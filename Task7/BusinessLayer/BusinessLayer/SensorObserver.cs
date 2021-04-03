using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SensorObserver : IObserver
    {
        public static List<string> SensorStateChangeLog { get; set; }
        private static SensorObserver singleSensorObserver;

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
            SensorStateChangeLog.Add($"{DateTime.Now} {sensor.SensorType} mode was changed on {sensor.SensorState.ToString().Substring(14)}!");
        }
    }
}
