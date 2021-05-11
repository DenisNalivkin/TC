using Newtonsoft.Json;
using System;

namespace DataBase
{/// <summary>
/// The ReflectionJsonMeasuringSensor class stores a sensor read from a json file.
/// </summary>
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
        /// <summary>
        /// Public constructor initializing the fields of the ReflectionJsonMeasuringSensor class object.
        /// </summary>
        /// <param name="uniqueIdentificator">Value for the field uniqueIdentificator.</param>
        /// <param name="sensorType">Value for the field sensorType.</param>
        /// <param name="measurementInterval">Value for the field measurementInterval.</param>
        /// <param name="measuredValue">Value for the field measuredValue.</param>
        public ReflectionJsonMeasuringSensor(Guid uniqueIdentificator, string sensorType, int? measurementInterval, int? measuredValue)
        {
            this.UniqueIdentificator = uniqueIdentificator;
            this._SensorType = sensorType;
            this.MeasurementInterval = measurementInterval;
            this.MeasuredValue = measuredValue;
        }
    }
}
