using Newtonsoft.Json;

namespace DataBase
{
    public class ReflectionJsonArrayMeasuringSensor
    {
        [JsonProperty("MeasuringSensors")]
        public ReflectionJsonMeasuringSensor[] arrayMeasuringSensor { get; private set; }
    }
}
