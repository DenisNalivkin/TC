using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class WindowCreateSensor : Form
    {
        string selectedSensor;
        List<string> namesSensors;

        public WindowCreateSensor()
        {
            InitializeComponent();
            namesSensors = GetNamesSensors(RequestHandler.businessLevelSensors);
            FillListKindSensors(namesSensors);
            selectedSensor = null;
        }

        private void WindowCreateSensor_Load(object sender, EventArgs e)
        {

        }

        private void ListKindSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSensor = ListKindSensors.SelectedItem.ToString();
            IntermediateSensor.SensorType =  RequestHandler.ParseStringInEnum(selectedSensor);
            MessageBox.Show($"{selectedSensor} will create after you will chose value for measurement interval.");                      
            Sensor sensorforSave = null;
            FinishInstallSensor(selectedSensor, sensorforSave);
            Close();          
        }
        private void ChoseSensor_Click(object sender, EventArgs e)
        {       
        }

        private void FinishInstallSensor (string selectedSensor, Sensor sensorforSave)
        {
            WindowChoseMeasurementInterval windowChoseMeasurementInterval = new WindowChoseMeasurementInterval();
            windowChoseMeasurementInterval.Show();
            switch (selectedSensor)
            {
                case "PressureSensor":
                    sensorforSave = new PressureSensor(IntermediateSensor.SensorType, IntermediateSensor.MeasurementInterval);
                    break;
                case "TemperatureSensor":
                    sensorforSave = new TemperatureSensor(IntermediateSensor.SensorType, IntermediateSensor.MeasurementInterval);
                    break;
                case "MagneticFieldSensor":
                    sensorforSave = new MagneticFieldSensor(IntermediateSensor.SensorType, IntermediateSensor.MeasurementInterval);
                    break;
            }
            RequestHandler.businessLevelSensors.Add(sensorforSave);
        }

        private List<string> GetNamesSensors(List<Sensor> businessLevelSensors)
        {
            List<string> namesSensors = new List<string>();
            foreach (var sensor in businessLevelSensors)
            {
                namesSensors.Add(sensor.SensorType.ToString());
            }
            return namesSensors;
        }

        private void FillListKindSensors(List<string> namesSensors)
        {
            foreach (var sensorName in namesSensors)
            {
                ListKindSensors.Items.Add(sensorName);
            }
        }


    }
}
