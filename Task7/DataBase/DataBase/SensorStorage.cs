using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DataBase
{/// <summary>
///  Class SensorStorage stores a list of the sensors. 
/// </summary>
    public class SensorStorage
    {
        public List<AbstractSensor> ListMeasuringSensor { get; set; }
        /// <summary>
        /// Public constructor initializing the field ListMeasuringSensor of the SensorStorage class object.
        /// </summary>
        public SensorStorage()
        {
            ListMeasuringSensor = new List<AbstractSensor>();
        }
        /// <summary>
        /// ReadMeasuringSensorsJson method reads measuring sensors from Json.
        /// </summary>
        /// <param name="path"> Specifies the path to the json file. </param>
        /// <returns> A list of objects of the AbstractSensor class. </returns>
        public List<AbstractSensor> ReadMeasuringSensorsJson(string path)
        {
            List<AbstractSensor> ListMeasuringSensor = new List<AbstractSensor>();
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonString = File.ReadAllText(path);
                ReflectionJsonArrayMeasuringSensor reflectionJsonArrayMeasuringSensor = JsonConvert.DeserializeObject<ReflectionJsonArrayMeasuringSensor>(jsonString);
                UniqueSensorIdentifier uniqueSensorIdentifier = UniqueSensorIdentifier.getInstance();

                for (int i = 0; i < reflectionJsonArrayMeasuringSensor.arrayMeasuringSensor.Length; i++)
                {
                    ListMeasuringSensor.Add(new AbstractSensor(reflectionJsonArrayMeasuringSensor.arrayMeasuringSensor[i]._SensorType, null, 
                        reflectionJsonArrayMeasuringSensor.arrayMeasuringSensor[i].MeasurementInterval, null));
                }
            }
            return ListMeasuringSensor;
        }
        /// <summary>
        /// ReadMeasuringSensorsXml method reads measuring sensors from Xml.
        /// </summary>
        /// <param name="path"> Specifies the path to the xml file.</param>
        /// <returns>A list of objects of the AbstractSensor class.</returns>
        public List<AbstractSensor> ReadMeasuringSensorsXml(string path)
        {
            XDocument xDoc = XDocument.Load(path);
            var nestedElementsConfig = xDoc.Root.Elements("Sensor");
            XAttribute[] SensorNames = new XAttribute[nestedElementsConfig.Count()];
            var sensorFirstAtr = nestedElementsConfig.Select((curentSensor) => curentSensor.FirstAttribute);
            return ParseSensorsSettings(xDoc, sensorFirstAtr, SensorNames);
        }

        private List<AbstractSensor> ParseSensorsSettings(XDocument xDoc, IEnumerable<XAttribute> loginFirstAtr, XAttribute[] SensorNames)
        {
            List<AbstractSensor> ListMeasuringSensor = new List<AbstractSensor>();
            var sensors = xDoc.Root.Elements("Sensor");
            foreach (var settingSensor in sensors)
            {
                ListMeasuringSensor.Add(new AbstractSensor((string)settingSensor.Element("SensorType"), null, (int)settingSensor.Element("MeasurementInterval"), null)); 
            }
            return ListMeasuringSensor;
        }

        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
