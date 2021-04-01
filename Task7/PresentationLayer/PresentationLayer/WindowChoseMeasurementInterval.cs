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
    public partial class WindowChoseMeasurementInterval : Form
    {
        public WindowChoseMeasurementInterval()
        {
            InitializeComponent();
        }
        private void ChoseMeasurementInterval_TextChanged(object sender, EventArgs e)
        {
            
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
