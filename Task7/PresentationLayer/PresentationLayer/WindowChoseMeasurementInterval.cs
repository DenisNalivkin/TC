using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{/// <summary>
/// The WindowChoseMeasurementInterval class stores the code for displaying the window that is responsible for choosing the measurement interval.
/// </summary>
    public partial class WindowChoseMeasurementInterval : Form
    {/// <summary>
     /// Public constructor initializing the fields of the WindowChoseMeasurementInterval class object.
     /// </summary>
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
