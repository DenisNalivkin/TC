using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
 
namespace PresentationLayer
{
    public partial class WorkWithSensors : Form
    {
        public WorkWithSensors()
        {
            InitializeComponent();
            RequestHandler requestHandler = new RequestHandler();
            Task runButtonsTrackingTask = new Task(() => TrackButtonState());
            runButtonsTrackingTask.Start();                          
        }

        private void Form1_Load(object sender, EventArgs e)
        {                 
        }

        private void ReadSensorsFromJsonButton_Click(object sender, EventArgs e)
        {
            DialogResult result = JsonSourceSelectionWindow.ShowDialog();             
        }

        private void JsonSourceSelectionWindow_FileOk(object sender, CancelEventArgs e)
        {
            new RequestHandler ()._ReadMeasuringSensorsJson(JsonSourceSelectionWindow.FileName);
        }

        private void ReadSensorsFromXmlButton_Click_(object sender, EventArgs e)
        {
            DialogResult result = XmlSourceSelectionWindow.ShowDialog();       
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
            Sensor sensor = null;
            Sensors.Invoke( (MethodInvoker) delegate { sensor = (Sensor)Sensors.SelectedItem; }); 
            Action<object> method = x => { TrackSensorState(sensor); };
            var executeTask = new Task(method, sensor);
            executeTask.Start();       
        }

        private void RefreshListSensors_Click(object sender, EventArgs e)
        {           
            Sensors.DataSource = null;
            Sensors.DataSource = RequestHandler.businessLevelSensors;
            Sensors.DisplayMember = "SensorTypeUniqueIdentificator";          
        }

        private void SwitchSelectedSensorMode_Click(object sender, EventArgs e)
        {
            WindowSwitchSelectedSensorMode windowSwitchSelectedSensorMode = new WindowSwitchSelectedSensorMode();
            windowSwitchSelectedSensorMode.Show();
        }

        private void TrackSensorState(object obj)
        {        
            Sensor sensor = (Sensor)obj;
            object safeSensorsSelectedItem = null;
            Sensors.Invoke((MethodInvoker)delegate { safeSensorsSelectedItem = Sensors.SelectedItem; });
            while (safeSensorsSelectedItem == sensor)
            { 
                if(RequestHandler.businessLevelSensors != null && RequestHandler.businessLevelSensors.Count == 0)
                {
                    SensorMeasuredValue.Text = null;
                }
                                                       
                if( sensor.SensorState is DowntimeSensorState )
                {
                    Sensors.Invoke((MethodInvoker)delegate { SensorMeasuredValue.Text = "0";});
                    Thread.Sleep(1);
                }
                else
                {
                    Sensors.Invoke((MethodInvoker)delegate { SensorMeasuredValue.Text = sensor.MeasuredValue.ToString();});
                    Thread.Sleep(1);
                }
                Sensors.Invoke((MethodInvoker)delegate { safeSensorsSelectedItem = Sensors.SelectedItem; });
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
            if (SensorsStateLog.DataSource != null && SensorObserver.SensorStateChangeLog.Count != 0)
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

        private void TrackButtonState()
        {                    
            while(true)
            {
            if (RequestHandler.businessLevelSensors.Count == 0)
            {
                CreateNewSensorButton_Click.Invoke((MethodInvoker)delegate { CreateNewSensorButton_Click.Enabled = false; });
                DeleteSensor.Invoke((MethodInvoker)delegate { DeleteSensor.Enabled = false; });
                RefreshSensorsStateLog.Invoke((MethodInvoker)delegate { RefreshSensorsStateLog.Enabled = false; });
                SwitchSelectedSensorMode.Invoke((MethodInvoker)delegate { SwitchSelectedSensorMode.Enabled = false; });
            }
            else
            {
                CreateNewSensorButton_Click.Invoke((MethodInvoker)delegate { CreateNewSensorButton_Click.Enabled = true; });
                DeleteSensor.Invoke((MethodInvoker)delegate { DeleteSensor.Enabled = true; });
                RefreshSensorsStateLog.Invoke((MethodInvoker)delegate { RefreshSensorsStateLog.Enabled = true; });
                SwitchSelectedSensorMode.Invoke((MethodInvoker)delegate { SwitchSelectedSensorMode.Enabled = true; });                 
            }
            }                              
        }
    }
}
