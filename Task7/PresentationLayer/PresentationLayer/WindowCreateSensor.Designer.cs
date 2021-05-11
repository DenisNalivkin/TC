
namespace PresentationLayer
{
    partial class WindowCreateSensor
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
            this.ListKindSensors = new System.Windows.Forms.ComboBox();
            this.ChoseSensor = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ListKindSensors
            // 
            this.ListKindSensors.FormattingEnabled = true;
            this.ListKindSensors.Location = new System.Drawing.Point(117, 66);
            this.ListKindSensors.Name = "ListKindSensors";
            this.ListKindSensors.Size = new System.Drawing.Size(157, 21);
            this.ListKindSensors.TabIndex = 0;
            this.ListKindSensors.SelectedIndexChanged += new System.EventHandler(this.ListKindSensor_SelectedIndexChanged);
            // 
            // ChoseSensor
            // 
            this.ChoseSensor.AutoSize = true;
            this.ChoseSensor.Location = new System.Drawing.Point(135, 50);
            this.ChoseSensor.Name = "ChoseSensor";
            this.ChoseSensor.Size = new System.Drawing.Size(106, 13);
            this.ChoseSensor.TabIndex = 1;
            this.ChoseSensor.Text = "Chose kind of sensor";
            this.ChoseSensor.Click += new System.EventHandler(this.ChoseSensor_Click);
            // 
            // WindowCreateSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 132);
            this.Controls.Add(this.ChoseSensor);
            this.Controls.Add(this.ListKindSensors);
            this.Name = "WindowCreateSensor";
            this.Text = "WindowCreateSensor";
            this.Load += new System.EventHandler(this.WindowCreateSensor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ListKindSensors;
        private System.Windows.Forms.Label ChoseSensor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}