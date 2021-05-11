namespace BusinessLayer
{/// <summary>
///  The PressureSensorManufacturer class has a CreateSensor method that creates pressure sensor.
/// </summary>
    public class PressureSensorManufacturer : SensorManufacturer
    {
        /// <summary>
        ///  CreateSensor method creates pressure sensor.
        /// </summary>
        /// <param name="sensorType">Value for sensorType.</param>
        /// <param name="measurementInterval">Value for measurementInterval.</param>
        /// <returns>Object of class Sensor.</returns>
        public override Sensor CreateSensor(SensorType sensorType, int? measurementInterval)
        {
            return new PressureSensor(sensorType, measurementInterval);
        }
    }
}
