using System.Collections.Generic;
using DataBase;

namespace BusinessLayer
{/// <summary>
/// The RequestHandler class has methods that allow you to interact with the database layer to access json and xml files.
/// </summary>
    public class RequestHandler
    {
        public static List<Sensor> businessLevelSensors { get; set; }
        /// <summary>
        /// Public constructor initializing the field businessLevelSensors of the RequestHandler class object.
        /// </summary>
        public RequestHandler ()
        {
            businessLevelSensors = new List<Sensor>();
        }
        /// <summary>
        /// The _ReadMeasuringSensorsJson method receives data from json.
        /// </summary>
        /// <param name="path">Specifies the path to the json file.</param>
        public void _ReadMeasuringSensorsJson(string path)
        {
            List<AbstractSensor> databaseLevelSensors =  new SensorStorage().ReadMeasuringSensorsJson(path);
            foreach(var sensor in databaseLevelSensors)
            {
                AddSensorInListSensors(businessLevelSensors,sensor);
            }
        }
        /// <summary>
        /// The ReadMeasuringSensorsXml method receives data from xml.
        /// </summary>
        /// <param name="path">Specifies the path to the xml file.</param>
        public void ReadMeasuringSensorsXml(string path)
         {
            List<DataBase.AbstractSensor> databaseLevelSensors = new SensorStorage().ReadMeasuringSensorsXml(path);
            databaseLevelSensors =  new SensorStorage ().ReadMeasuringSensorsXml(path);
            foreach (var sensor in databaseLevelSensors)
            {
                AddSensorInListSensors(businessLevelSensors,sensor);
            }        
        }
        /// <summary>
        /// ParseStringInEnum method converts a string type sensor to SensorType.
        /// </summary>
        /// <param name="strSensorType"> Sensor type in string format. </param>
        /// <returns> Sensor type in format SensorType. </returns>
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
       
        private void AddSensorInListSensors (List<Sensor> businessLevelSensors,AbstractSensor sensor)
        {
            SensorManufacturer sensorManufacturer = null;
            switch (sensor.SensorType)
            {
                case "PressureSensor":
                    sensorManufacturer = new PressureSensorManufacturer();                   
                    break;
                case "TemperatureSensor":
                    sensorManufacturer = new TemperatureSensorManufacturer();          
                    break;
                case "MagneticFieldSensor":
                    sensorManufacturer = new MagneticFieldSensorSensorManufacturer();;
                    break;
            }
            businessLevelSensors.Add(sensorManufacturer.CreateSensor(ParseStringInEnum(sensor.SensorType), sensor.MeasurementInterval));
        }
    }
}
