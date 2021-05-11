namespace BusinessLayer
{/// <summary>
/// The abstract SensorManufacturer class is an implementation of the template factory method. 
/// </summary>
    public abstract class SensorManufacturer
    {
        abstract public Sensor CreateSensor(SensorType sensorType, int? measurementInterval);
    }
}

