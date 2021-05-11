using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer
{/// <summary>
/// The WindowSwitchSelectedSensorMode class stores the code for displaying the window, the selected sensor mode.
/// </summary>
    public partial class WindowSwitchSelectedSensorMode : Form
    {
        string selectedSensor;
        List<Sensor> listSensors;
        /// <summary>
        /// Public constructor initializing the fields of the WindowSwitchSelectedSensorMode class object.
        /// </summary>
        public WindowSwitchSelectedSensorMode()
        {
            InitializeComponent();          
            selectedSensor = null;
            ChoseSensor.Enabled = false;
            listSensors = RequestHandler.businessLevelSensors;
            foreach(var sensor in RequestHandler.businessLevelSensors)
            {
                SwitchSelectedSensorMode.Items.Add(sensor.SensorTypeUniqueIdentificator);
            }           
        }

        private void WindowSwitchSelectedSensorMode_Load(object sender, EventArgs e)
        {
        }
       
        private void SwitchSelectedSensorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
         
           selectedSensor = SwitchSelectedSensorMode.SelectedItem.ToString();
            foreach(var sensor in listSensors)
            {
                if(sensor.SensorType.ToString() == selectedSensor)
                {
                    sensor.SensorState.ChangeState(sensor);
                }
            }
        }
        
        private void ChoseSensor_Click(object sender, EventArgs e)
        {
            selectedSensor = SwitchSelectedSensorMode.SelectedItem.ToString();
            foreach (var sensor in listSensors)
            {
                if(sensor.SensorTypeUniqueIdentificator == selectedSensor)
                {
                    sensor.ChangeState();
                    break;
                }
            }
            Close();
        }

        private void SwitchSelectedSensorMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(SwitchSelectedSensorMode != null)
            {
                ChoseSensor.Enabled = true;
            }          
        }  
    }
}
