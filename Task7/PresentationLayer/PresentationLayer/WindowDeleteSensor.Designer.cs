
namespace PresentationLayer
{
    partial class WindowDeleteSensor
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
            this.ChoseSensorForDelete = new System.Windows.Forms.ComboBox();
            this.ChoseSensorDelete = new System.Windows.Forms.Label();
            this.ChoseSensorDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChoseSensorForDelete
            // 
            this.ChoseSensorForDelete.FormattingEnabled = true;
            this.ChoseSensorForDelete.Location = new System.Drawing.Point(93, 62);
            this.ChoseSensorForDelete.Name = "ChoseSensorForDelete";
            this.ChoseSensorForDelete.Size = new System.Drawing.Size(121, 21);
            this.ChoseSensorForDelete.TabIndex = 0;
            this.ChoseSensorForDelete.SelectedIndexChanged += new System.EventHandler(this.ChoseSensorForDelete_SelectedIndexChanged);
            // 
            // ChoseSensorDelete
            // 
            this.ChoseSensorDelete.AutoSize = true;
            this.ChoseSensorDelete.Location = new System.Drawing.Point(96, 46);
            this.ChoseSensorDelete.Name = "ChoseSensorDelete";
            this.ChoseSensorDelete.Size = new System.Drawing.Size(118, 13);
            this.ChoseSensorDelete.TabIndex = 1;
            this.ChoseSensorDelete.Text = "Chose sensor for delete";
            this.ChoseSensorDelete.Click += new System.EventHandler(this.ChoseSensorDelete_Click);
            // 
            // ChoseSensorDel
            // 
            this.ChoseSensorDel.Location = new System.Drawing.Point(93, 89);
            this.ChoseSensorDel.Name = "ChoseSensorDel";
            this.ChoseSensorDel.Size = new System.Drawing.Size(121, 37);
            this.ChoseSensorDel.TabIndex = 2;
            this.ChoseSensorDel.Text = "Chose sensor for delete";
            this.ChoseSensorDel.UseVisualStyleBackColor = true;
            this.ChoseSensorDel.Click += new System.EventHandler(this.ChoseSensorDel_Click);
            // 
            // WindowDeleteSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 138);
            this.Controls.Add(this.ChoseSensorDel);
            this.Controls.Add(this.ChoseSensorDelete);
            this.Controls.Add(this.ChoseSensorForDelete);
            this.Name = "WindowDeleteSensor";
            this.Text = "WindowDeleteSensor";
            this.Load += new System.EventHandler(this.WindowDeleteSensor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ChoseSensorForDelete;
        private System.Windows.Forms.Label ChoseSensorDelete;
        private System.Windows.Forms.Button ChoseSensorDel;
    }
}