using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ReflectionJsonMeasuringSensor
    {
        [JsonProperty("UniqueIdentificator")]
        public Guid UniqueIdentificator { get; private set; }

        [JsonProperty("_SensorType")]
        public string _SensorType { get; private set; }

        [JsonProperty("MeasurementInterval")]
        public int? MeasurementInterval { get; private set; }

        [JsonProperty("MeasuredValue")]
        public int? MeasuredValue { get; private set; }

        public ReflectionJsonMeasuringSensor(Guid uniqueIdentificator, string sensorType, int? measurementInterval, int? measuredValue)
        {
            this.UniqueIdentificator = uniqueIdentificator;
            this._SensorType = sensorType;
            this.MeasurementInterval = measurementInterval;
            this.MeasuredValue = measuredValue;
        }
    }
}
