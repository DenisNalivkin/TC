
namespace PresentationLayer
{
    partial class WindowSwitchSelectedSensorMode
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
            this.SwitchSelectedSensorMode = new System.Windows.Forms.ComboBox();
            this.ChoseSensor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SwitchSelectedSensorMode
            // 
            this.SwitchSelectedSensorMode.FormattingEnabled = true;
            this.SwitchSelectedSensorMode.Location = new System.Drawing.Point(120, 109);
            this.SwitchSelectedSensorMode.Name = "SwitchSelectedSensorMode";
            this.SwitchSelectedSensorMode.Size = new System.Drawing.Size(166, 21);
            this.SwitchSelectedSensorMode.TabIndex = 0;
            //this.SwitchSelectedSensorMode.SelectedIndexChanged += new System.EventHandler(this.SwitchSelectedSensorMode_SelectedIndexChanged);
            // 
            // ChoseSensor
            // 
            this.ChoseSensor.Location = new System.Drawing.Point(120, 136);
            this.ChoseSensor.Name = "ChoseSensor";
            this.ChoseSensor.Size = new System.Drawing.Size(166, 23);
            this.ChoseSensor.TabIndex = 1;
            this.ChoseSensor.Text = "Chose sensor";
            this.ChoseSensor.UseVisualStyleBackColor = true;
            this.ChoseSensor.Click += new System.EventHandler(this.ChoseSensor_Click);
            // 
            // WindowSwitchSelectedSensorMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 227);
            this.Controls.Add(this.ChoseSensor);
            this.Controls.Add(this.SwitchSelectedSensorMode);
            this.Name = "WindowSwitchSelectedSensorMode";
            this.Text = "WindowSwitchSelectedSensorMode";
            this.Load += new System.EventHandler(this.WindowSwitchSelectedSensorMode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox SwitchSelectedSensorMode;
        private System.Windows.Forms.Button ChoseSensor;
    }
}