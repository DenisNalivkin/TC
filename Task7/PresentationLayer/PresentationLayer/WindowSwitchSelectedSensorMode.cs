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
    public partial class WindowSwitchSelectedSensorMode : Form
    {
        string selectedSensor;
        List<Sensor> listSensors;
        public WindowSwitchSelectedSensorMode()
        {
            InitializeComponent();          
            selectedSensor = null;
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
        }  
    }
}
