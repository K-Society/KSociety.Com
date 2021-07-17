
namespace KSociety.Com.Pre.Form.App
{
    partial class Configuration
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
            this.generalTabUserControl1 = new KSociety.Com.Pre.Form.View.Forms.GeneralTabUserControl();
            this.SuspendLayout();
            // 
            // generalTabUserControl1
            // 
            this.generalTabUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTabUserControl1.Location = new System.Drawing.Point(0, 0);
            this.generalTabUserControl1.Margin = new System.Windows.Forms.Padding(2);
            this.generalTabUserControl1.Name = "generalTabUserControl1";
            this.generalTabUserControl1.Size = new System.Drawing.Size(1389, 582);
            this.generalTabUserControl1.TabIndex = 0;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 582);
            this.Controls.Add(this.generalTabUserControl1);
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.ResumeLayout(false);
        }

        #endregion

        private View.Forms.GeneralTabUserControl generalTabUserControl1;
    }
}