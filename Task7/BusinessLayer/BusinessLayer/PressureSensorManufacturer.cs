namespace BusinessLayer
{
    public class PressureSensorManufacturer : SensorManufacturer
    {
        public override Sensor CreateSensor(SensorType sensorType, int? measurementInterval)
        {
            return new PressureSensor(sensorType, measurementInterval);
        }
    }
}
