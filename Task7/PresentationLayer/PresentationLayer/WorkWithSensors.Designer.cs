namespace PresentationLayer
{
    partial class WorkWithSensors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReadSensorsFromJsonButton = new System.Windows.Forms.Button();
            this.JsonSourceSelectionWindow = new System.Windows.Forms.OpenFileDialog();
            this.ReadSensorsFromXmlButton = new System.Windows.Forms.Button();
            this.XmlSourceSelectionWindow = new System.Windows.Forms.OpenFileDialog();
            this.CreateNewSensorButton_Click = new System.Windows.Forms.Button();
            this.DeleteSensor = new System.Windows.Forms.Button();
            this.Sensors = new System.Windows.Forms.ListBox();
            this.RefreshListSensors = new System.Windows.Forms.Button();
            this.SwitchSelectedSensorMode = new System.Windows.Forms.Button();
            this.SensorMeasuredValue = new System.Windows.Forms.TextBox();
            this.SensorsStateLog = new System.Windows.Forms.ListBox();
            this.RefreshSensorsStateLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReadSensorsFromJsonButton
            // 
            this.ReadSensorsFromJsonButton.Location = new System.Drawing.Point(23, 209);
            this.ReadSensorsFromJsonButton.Name = "ReadSensorsFromJsonButton";
            this.ReadSensorsFromJsonButton.Size = new System.Drawing.Size(311, 32);
            this.ReadSensorsFromJsonButton.TabIndex = 0;
            this.ReadSensorsFromJsonButton.Text = "Read sensors from Json\r\n ";
            this.ReadSensorsFromJsonButton.UseVisualStyleBackColor = true;
            this.ReadSensorsFromJsonButton.Click += new System.EventHandler(this.ReadSensorsFromJsonButton_Click);
            // 
            // JsonSourceSelectionWindow
            // 
            this.JsonSourceSelectionWindow.FileName = "openFileDialog1";
            this.JsonSourceSelectionWindow.FileOk += new System.ComponentModel.CancelEventHandler(this.JsonSourceSelectionWindow_FileOk);
            // 
            // ReadSensorsFromXmlButton
            // 
            this.ReadSensorsFromXmlButton.Location = new System.Drawing.Point(23, 257);
            this.ReadSensorsFromXmlButton.Name = "ReadSensorsFromXmlButton";
            this.ReadSensorsFromXmlButton.Size = new System.Drawing.Size(311, 31);
            this.ReadSensorsFromXmlButton.TabIndex = 1;
            this.ReadSensorsFromXmlButton.Text = "Read sensors from Xml\r\n";
            this.ReadSensorsFromXmlButton.UseVisualStyleBackColor = true;
            this.ReadSensorsFromXmlButton.Click += new System.EventHandler(this.ReadSensorsFromXmlButton_Click_);
            // 
            // XmlSourceSelectionWindow
            // 
            this.XmlSourceSelectionWindow.FileName = "openFileDialog1";
            this.XmlSourceSelectionWindow.FileOk += new System.ComponentModel.CancelEventHandler(this.XmlSourceSelectionWindow_FileOk);
            // 
            // CreateNewSensorButton_Click
            // 
            this.CreateNewSensorButton_Click.Location = new System.Drawing.Point(23, 305);
            this.CreateNewSensorButton_Click.Name = "CreateNewSensorButton_Click";
            this.CreateNewSensorButton_Click.Size = new System.Drawing.Size(311, 31);
            this.CreateNewSensorButton_Click.TabIndex = 2;
            this.CreateNewSensorButton_Click.Text = "Create a  new sensor\r\n";
            this.CreateNewSensorButton_Click.UseVisualStyleBackColor = true;
            this.CreateNewSensorButton_Click.Click += new System.EventHandler(this.CreateNewSensorButton_Click_Click);
            // 
            // DeleteSensor
            // 
            this.DeleteSensor.Location = new System.Drawing.Point(23, 355);
            this.DeleteSensor.Name = "DeleteSensor";
            this.DeleteSensor.Size = new System.Drawing.Size(311, 30);
            this.DeleteSensor.TabIndex = 3;
            this.DeleteSensor.Text = "Delete sensor\r\n";
            this.DeleteSensor.UseVisualStyleBackColor = true;
            this.DeleteSensor.Click += new System.EventHandler(this.DeleteSensor_Click);
            // 
            // Sensors
            // 
            this.Sensors.FormattingEnabled = true;
            this.Sensors.Location = new System.Drawing.Point(23, 114);
            this.Sensors.Name = "Sensors";
            this.Sensors.Size = new System.Drawing.Size(311, 69);
            this.Sensors.TabIndex = 4;
            this.Sensors.SelectedIndexChanged += new System.EventHandler(this.Sensors_SelectedIndexChanged);
            // 
            // RefreshListSensors
            // 
            this.RefreshListSensors.Location = new System.Drawing.Point(23, 403);
            this.RefreshListSensors.Name = "RefreshListSensors";
            this.RefreshListSensors.Size = new System.Drawing.Size(311, 30);
            this.RefreshListSensors.TabIndex = 5;
            this.RefreshListSensors.Text = "Refresh list sensors";
            this.RefreshListSensors.UseVisualStyleBackColor = true;
            this.RefreshListSensors.Click += new System.EventHandler(this.RefreshListSensors_Click);
            // 
            // SwitchSelectedSensorMode
            // 
            this.SwitchSelectedSensorMode.Location = new System.Drawing.Point(23, 492);
            this.SwitchSelectedSensorMode.Name = "SwitchSelectedSensorMode";
            this.SwitchSelectedSensorMode.Size = new System.Drawing.Size(311, 30);
            this.SwitchSelectedSensorMode.TabIndex = 6;
            this.SwitchSelectedSensorMode.Text = "Switch selected sensor mode";
            this.SwitchSelectedSensorMode.UseVisualStyleBackColor = true;
            this.SwitchSelectedSensorMode.Click += new System.EventHandler(this.SwitchSelectedSensorMode_Click);
            // 
            // SensorMeasuredValue
            // 
            this.SensorMeasuredValue.Location = new System.Drawing.Point(340, 138);
            this.SensorMeasuredValue.Name = "SensorMeasuredValue";
            this.SensorMeasuredValue.Size = new System.Drawing.Size(188, 20);
            this.SensorMeasuredValue.TabIndex = 7;
            this.SensorMeasuredValue.TextChanged += new System.EventHandler(this.SensorMeasuredValue_TextChanged);
            // 
            // SensorsStateLog
            // 
            this.SensorsStateLog.FormattingEnabled = true;
            this.SensorsStateLog.Location = new System.Drawing.Point(23, 25);
            this.SensorsStateLog.Name = "SensorsStateLog";
            this.SensorsStateLog.Size = new System.Drawing.Size(505, 69);
            this.SensorsStateLog.TabIndex = 8;
            this.SensorsStateLog.SelectedIndexChanged += new System.EventHandler(this.SensorsStateLog_SelectedIndexChanged);
            // 
            // RefreshSensorsStateLog
            // 
            this.RefreshSensorsStateLog.Location = new System.Drawing.Point(23, 451);
            this.RefreshSensorsStateLog.Name = "RefreshSensorsStateLog";
            this.RefreshSensorsStateLog.Size = new System.Drawing.Size(311, 25);
            this.RefreshSensorsStateLog.TabIndex = 9;
            this.RefreshSensorsStateLog.Text = "Refresh sensors state log";
            this.RefreshSensorsStateLog.UseVisualStyleBackColor = true;
            this.RefreshSensorsStateLog.Click += new System.EventHandler(this.RefreshSensorsStateLog_Click);
            // 
            // WorkWithSensors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 546);
            this.Controls.Add(this.RefreshSensorsStateLog);
            this.Controls.Add(this.SensorsStateLog);
            this.Controls.Add(this.SensorMeasuredValue);
            this.Controls.Add(this.SwitchSelectedSensorMode);
            this.Controls.Add(this.RefreshListSensors);
            this.Controls.Add(this.Sensors);
            this.Controls.Add(this.DeleteSensor);
            this.Controls.Add(this.CreateNewSensorButton_Click);
            this.Controls.Add(this.ReadSensorsFromXmlButton);
            this.Controls.Add(this.ReadSensorsFromJsonButton);
            this.Name = "WorkWithSensors";
            this.Text = "Work with sensors";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadSensorsFromJsonButton;
        private System.Windows.Forms.OpenFileDialog JsonSourceSelectionWindow;
        private System.Windows.Forms.Button ReadSensorsFromXmlButton;
        private System.Windows.Forms.OpenFileDialog XmlSourceSelectionWindow;
        private System.Windows.Forms.Button CreateNewSensorButton_Click;
        private System.Windows.Forms.Button DeleteSensor;
        private System.Windows.Forms.ListBox Sensors;
        private System.Windows.Forms.Button RefreshListSensors;
        private System.Windows.Forms.Button SwitchSelectedSensorMode;
        private System.Windows.Forms.TextBox SensorMeasuredValue;
        private System.Windows.Forms.ListBox SensorsStateLog;
        private System.Windows.Forms.Button RefreshSensorsStateLog;
    }
}

