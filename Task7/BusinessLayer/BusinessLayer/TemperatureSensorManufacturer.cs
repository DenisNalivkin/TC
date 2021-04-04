namespace BusinessLayer
{
    public class TemperatureSensorManufacturer : SensorManufacturer
    {
        public override Sensor CreateSensor(SensorType sensorType, int? measurementInterval)
        {
            return new TemperatureSensor(sensorType, measurementInterval);
        }
    }
}
