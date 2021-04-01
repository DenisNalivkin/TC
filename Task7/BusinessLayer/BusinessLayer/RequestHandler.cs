using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataBase;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class RequestHandler
    {
        public static List<Sensor> businessLevelSensors { get; set; }

        public RequestHandler ()
        {
            businessLevelSensors = new List<Sensor>();
        }

        public void _ReadMeasuringSensorsJson(string path)
        {
            List<AbstractSensor> databaseLevelSensors =  new SensorStorage().ReadMeasuringSensorsJson(path);
            foreach(var sensor in databaseLevelSensors)
            {
                SensorManufacturer sensorManufacturer = null;
                Sensor newSensor = null;
                AddSensorInListSensors(businessLevelSensors,sensor, sensorManufacturer, newSensor);
            }          
        }
        
        public  void ReadMeasuringSensorsXml(string path)
         {
            List<DataBase.AbstractSensor> databaseLevelSensors = new SensorStorage().ReadMeasuringSensorsXml(path);
            databaseLevelSensors =  new SensorStorage ().ReadMeasuringSensorsXml(path);
            foreach (var sensor in databaseLevelSensors)
            {
                SensorManufacturer sensorManufacturer = null;
                Sensor newSensor = null;
                AddSensorInListSensors(businessLevelSensors,sensor, sensorManufacturer, newSensor);
            }        
        }
     
        public static SensorType ParseStringInEnum (string strSensorType)
        {
            switch(strSensorType)
            {
                case "PressureSensor":
                    return SensorType.PressureSensor;
                case "TemperatureSensor":
                    return SensorType.TemperatureSensor;
                case "MagneticFieldSensor":
                    return SensorType.MagneticFieldSensor;
            }
            return SensorType.UnknownSensor;
        }

        private void AddSensorInListSensors (List<Sensor> businessLevelSensors,AbstractSensor sensor, SensorManufacturer sensorManufacturer, Sensor newSensor)
        {       
            switch (sensor.SensorType)
            {
                case "PressureSensor":
                    sensorManufacturer = new PressureSensorManufacturer();
                    newSensor = sensorManufacturer.CreateSensor(ParseStringInEnum(sensor.SensorType), sensor.MeasurementInterval);
                    businessLevelSensors.Add(newSensor);
                    break;
                case "TemperatureSensor":
                    sensorManufacturer = new TemperatureSensorManufacturer();
                    newSensor = sensorManufacturer.CreateSensor(ParseStringInEnum(sensor.SensorType), sensor.MeasurementInterval);
                    businessLevelSensors.Add(newSensor);
                    break;
                case "MagneticFieldSensor":
                    sensorManufacturer = new MagneticFieldSensorSensorManufacturer();
                    newSensor = sensorManufacturer.CreateSensor(ParseStringInEnum(sensor.SensorType), sensor.MeasurementInterval);
                    businessLevelSensors.Add(newSensor);
                    break;
            }
        }
    }
}
