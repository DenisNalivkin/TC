namespace BusinessLayer
{
    public abstract class SensorManufacturer
    {
        abstract public Sensor CreateSensor(SensorType sensorType, int? measurementInterval);
    }
}
