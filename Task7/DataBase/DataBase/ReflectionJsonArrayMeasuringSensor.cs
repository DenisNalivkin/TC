using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ReflectionJsonArrayMeasuringSensor
    {
        [JsonProperty("MeasuringSensors")]
        public ReflectionJsonMeasuringSensor[] arrayMeasuringSensor { get; private set; }
    }
}
