using Newtonsoft.Json;

namespace DataBase
{/// <summary>
/// The ReflectionJsonArrayMeasuringSensor class stores an array of ReflectionJsonMeasuringSensor objects.
/// </summary>
    public class ReflectionJsonArrayMeasuringSensor
    {
        [JsonProperty("MeasuringSensors")]
        public ReflectionJsonMeasuringSensor[] arrayMeasuringSensor { get; private set; }
    }
}
