using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class WindowDeleteSensor : Form
    {
        string listSensorsDelete;

        public WindowDeleteSensor()
        {
            InitializeComponent();
            listSensorsDelete = null;
            GetSensors();
        }

        private void WindowDeleteSensor_Load(object sender, EventArgs e)
        {
            ChoseSensorDel.Enabled = false;
        }

        private void ChoseSensorForDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            listSensorsDelete = ChoseSensorForDelete.SelectedItem.ToString();
            if (listSensorsDelete!= null)
            {
                ChoseSensorDel.Enabled = true;
            }
        }

        private void ChoseSensorDelete_Click(object sender, EventArgs e)
        {
        }

        private void GetSensors()
        {
            foreach(var sensor in RequestHandler.businessLevelSensors)
            {
                ChoseSensorForDelete.Items.Add(sensor.SensorTypeUniqueIdentificator);
            }           
        }

        private void ChoseSensorDel_Click(object sender, EventArgs e)
        {
            string nameSensor  = ChoseSensorForDelete.Text;
            if(nameSensor!= null)
            {              
                foreach (var sensor in RequestHandler.businessLevelSensors)
                {
                    if (sensor.SensorTypeUniqueIdentificator == nameSensor)
                    {
                        RequestHandler.businessLevelSensors.Remove(sensor);
                        break;
                    }
                }
            }         
            Close();
        }
    }
}
