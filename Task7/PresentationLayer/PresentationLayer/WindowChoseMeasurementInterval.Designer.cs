
namespace PresentationLayer
{
    partial class WindowChoseMeasurementInterval
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
            this.components = new System.ComponentModel.Container();
            this.ChoseMeasurementInterval = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SaveValueMeasurementInterval = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChoseMeasurementInterval
            // 
            this.ChoseMeasurementInterval.Location = new System.Drawing.Point(132, 85);
            this.ChoseMeasurementInterval.Name = "ChoseMeasurementInterval";
            this.ChoseMeasurementInterval.Size = new System.Drawing.Size(137, 20);
            this.ChoseMeasurementInterval.TabIndex = 0;
            this.ChoseMeasurementInterval.TextChanged += new System.EventHandler(this.ChoseMeasurementInterval_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chose measurement interval";
            // 
            // SaveValueMeasurementInterval
            // 
            this.SaveValueMeasurementInterval.Location = new System.Drawing.Point(132, 111);
            this.SaveValueMeasurementInterval.Name = "SaveValueMeasurementInterval";
            this.SaveValueMeasurementInterval.Size = new System.Drawing.Size(137, 23);
            this.SaveValueMeasurementInterval.TabIndex = 3;
            this.SaveValueMeasurementInterval.Text = "Chose value";
            this.SaveValueMeasurementInterval.UseVisualStyleBackColor = true;
            this.SaveValueMeasurementInterval.Click += new System.EventHandler(this.SaveValueMeasurementInterval_Click);
            // 
            // WindowChoseMeasurementInterval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 179);
            this.Controls.Add(this.SaveValueMeasurementInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChoseMeasurementInterval);
            this.Name = "WindowChoseMeasurementInterval";
            this.Text = "WindowChoseMeasurementInterval";
            this.Load += new System.EventHandler(this.WindowChoseMeasurementInterval_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChoseMeasurementInterval;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveValueMeasurementInterval;
    }
}