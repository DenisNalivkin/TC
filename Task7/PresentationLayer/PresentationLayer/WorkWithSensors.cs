using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
 
namespace PresentationLayer
{
    public partial class WorkWithSensors : Form
    {
        public SensorType sensorType;

        public WorkWithSensors()
        {
            InitializeComponent();
            RequestHandler requestHandler = new RequestHandler();
            sensorType = SensorType.UnknownSensor;      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void ReadSensorsFromJsonButton_Click(object sender, EventArgs e)
        {
            DialogResult result = JsonSourceSelectionWindow.ShowDialog();           
            Sensors.DataSource = RequestHandler.businessLevelSensors;           
        }

        private void JsonSourceSelectionWindow_FileOk(object sender, CancelEventArgs e)
        {
            new RequestHandler ()._ReadMeasuringSensorsJson(JsonSourceSelectionWindow.FileName);
        }

        private void ReadSensorsFromXmlButton_Click_(object sender, EventArgs e)
        {
            DialogResult result = XmlSourceSelectionWindow.ShowDialog();
            Sensors.DataSource = RequestHandler.businessLevelSensors;
        }

        private void XmlSourceSelectionWindow_FileOk(object sender, CancelEventArgs e)
        {
           new RequestHandler().ReadMeasuringSensorsXml(XmlSourceSelectionWindow.FileName);
        }

        private void CreateNewSensorButton_Click_Click(object sender, EventArgs e)
        {
            WindowCreateSensor windowCreateSensor = new WindowCreateSensor();
            windowCreateSensor.Show();
        }

        private void DeleteSensor_Click(object sender, EventArgs e)
        {
            WindowDeleteSensor windowDeleteSensor = new WindowDeleteSensor();
            windowDeleteSensor.Show();           
        }

        private void Sensors_SelectedIndexChanged(object sender, EventArgs e)
        {           
            Sensor sensor = (Sensor)Sensors.SelectedItem;
            if(sensor != null)
            {
                MessageBox.Show($"{sensor.SensorType} - {sensor.MeasuredValue}");
            }
            Thread trackThread = new Thread(new ParameterizedThreadStart(TrackSensorState));
            trackThread.Start(sensor);


        }

        private void RefreshListSensors_Click(object sender, EventArgs e)
        {
            Sensors.DataSource = null;
            Sensors.DataSource = RequestHandler.businessLevelSensors;
            Sensors.DisplayMember = "SensorType";          
        }

        private void SwitchSelectedSensorMode_Click(object sender, EventArgs e)
        {
            WindowSwitchSelectedSensorMode windowSwitchSelectedSensorMode = new WindowSwitchSelectedSensorMode();
            windowSwitchSelectedSensorMode.Show();

        }

        private void TrackSensorState(object obj)
        {
            Sensor sensor = (Sensor)obj;
            while(Sensors.SelectedItem == sensor)
            {
                if( sensor.SensorState is DowntimeSensorState )
                {
                    SensorMeasuredValue.Text = "0";
                }
                else
                {
                    SensorMeasuredValue.Text = sensor.MeasuredValue.ToString();
                }                            
            }
        }
       
    }
}
