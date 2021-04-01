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

        }

        private void ChoseSensorForDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            listSensorsDelete = ChoseSensorForDelete.SelectedItem.ToString();
        }

        private void ChoseSensorDelete_Click(object sender, EventArgs e)
        {

        }

        private void GetSensors()
        {
            foreach(var sensor in RequestHandler.businessLevelSensors)
            {
                ChoseSensorForDelete.Items.Add(sensor.SensorType);
            }           
        }

        private void ChoseSensorDel_Click(object sender, EventArgs e)
        {
            string nameSensor  = ChoseSensorForDelete.Text;
            foreach (var sensor in RequestHandler.businessLevelSensors)
            {
                if(sensor.SensorType.ToString() == nameSensor)
                {
                    RequestHandler.businessLevelSensors.Remove(sensor);
                    break;
                }
            }

            Close();
        }
    }
}
