using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBase
{
    public class SensorStorage
    {
        public List<AbstractSensor> ListMeasuringSensor { get; set; }

        public SensorStorage()
        {
            ListMeasuringSensor = new List<AbstractSensor>();
        }

        public  List<AbstractSensor> ReadMeasuringSensorsJson(string path)
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

        public  List<AbstractSensor> ReadMeasuringSensorsXml(string path)
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
