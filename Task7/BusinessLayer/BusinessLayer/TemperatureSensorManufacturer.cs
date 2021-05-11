namespace BusinessLayer
{/// <summary>
/// The TemperatureSensorManufacturer class has a CreateSensor method that creates temperature sensor.
/// </summary>
    public class TemperatureSensorManufacturer : SensorManufacturer
    {/// <summary>
     /// CreateSensor method creates temperature sensor.
     /// </summary>
     /// <param name="sensorType"> Value for sensorType.</param>
     /// <param name="measurementInterval">Value for measurementInterval.</param>
     /// <returns></returns>
        public override Sensor CreateSensor(SensorType sensorType, int? measurementInterval)
        {
            return new TemperatureSensor(sensorType, measurementInterval);
        }
    }
}
