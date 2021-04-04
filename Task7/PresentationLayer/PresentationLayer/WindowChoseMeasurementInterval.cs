using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class WindowChoseMeasurementInterval : Form
    {
        public WindowChoseMeasurementInterval()
        {
            InitializeComponent();
            SaveValueMeasurementInterval.Enabled = false;
        }

        private void ChoseMeasurementInterval_TextChanged(object sender, EventArgs e)
        {
             if (ChoseMeasurementInterval != null)
            {
                SaveValueMeasurementInterval.Enabled = true;
            }          
        }

        private void WindowChoseMeasurementInterval_Load(object sender, EventArgs e)
        {

        }

        private void SaveValueMeasurementInterval_Click(object sender, EventArgs e)
        {
            IntermediateSensor.MeasurementInterval = int.Parse(ChoseMeasurementInterval.Text);
            RequestHandler.businessLevelSensors[RequestHandler.businessLevelSensors.Count-1].MeasurementInterval = IntermediateSensor.MeasurementInterval;
            Close();
        }        
    }
}
