using System;

namespace BusinessLayer
{
    public static class IntermediateSensor
    {
        public static Guid UniqueIdentificator { get;  set; }
        public static SensorType SensorType { get;  set; }
        public static ISensorState SensorState { get; set; }
        public static int? MeasurementInterval { get; set; }
        public static int? MeasuredValue { get;  set; }
    }
}
