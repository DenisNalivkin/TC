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
            if(RequestHandler.businessLevelSensors != null)
            {
                DeleteSensor.Enabled = true;
            }          
        }

        private void JsonSourceSelectionWindow_FileOk(object sender, CancelEventArgs e)
        {
            new RequestHandler ()._ReadMeasuringSensorsJson(JsonSourceSelectionWindow.FileName);
        }

        private void ReadSensorsFromXmlButton_Click_(object sender, EventArgs e)
        {
            DialogResult result = XmlSourceSelectionWindow.ShowDialog();
            if (RequestHandler.businessLevelSensors != null)
            {
                DeleteSensor.Enabled = true;
            }
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
            Control.CheckForIllegalCrossThreadCalls = false;
            Action<object> method = x => { TrackSensorState(sensor); };
            var executeTask = new Task(method, sensor);
            executeTask.Start();       
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
            while (Sensors.SelectedItem == sensor)
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

        private void SensorMeasuredValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void SensorsStateLog_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        private void RefreshSensorsStateLog_Click(object sender, EventArgs e)
        {
            SensorsStateLog.DataSource = SensorObserver.SensorStateChangeLog;
            if (SensorObserver.SensorStateChangeLog.Count != null)
            {
                SensorsStateLog.DataSource = null;
                SensorsStateLog.DataSource = SensorObserver.SensorStateChangeLog;
                for (int i = 0; i < SensorObserver.SensorStateChangeLog.Count; i++)
                {
                    SensorsStateLog.DisplayMember = SensorObserver.SensorStateChangeLog[i];
                }
            }
                    
        }

        private void SensorList_Click(object sender, EventArgs e)
        {
        }

        private void MeasuringValueSensor_Click(object sender, EventArgs e)
        {

        }

        private void SensorsStateChangeLog_Click(object sender, EventArgs e)
        {

        }
    }
}
