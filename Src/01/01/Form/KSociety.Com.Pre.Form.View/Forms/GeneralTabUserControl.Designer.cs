
using KSociety.Com.Pre.Form.View.Forms.Common.List.GridView;
using KSociety.Com.Pre.Form.View.Forms.Logix.List.GridView;
using KSociety.Com.Pre.Form.View.Forms.S7.List.GridView;

namespace KSociety.Com.Pre.Form.View.Forms
{
    partial class GeneralTabUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.common = new System.Windows.Forms.TabPage();
            this.commonTabUserControl1 = new CommonTabUserControl();
            this.s7 = new System.Windows.Forms.TabPage();
            this.s7TabUserControl1 = new S7TabUserControl();
            this.logix = new System.Windows.Forms.TabPage();
            this.logixTabUserControl1 = new LogixTabUserControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.common.SuspendLayout();
            this.s7.SuspendLayout();
            this.logix.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.common);
            this.tabControl1.Controls.Add(this.s7);
            this.tabControl1.Controls.Add(this.logix);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1512, 467);
            this.tabControl1.TabIndex = 0;
            // 
            // common
            // 
            this.common.Controls.Add(this.commonTabUserControl1);
            this.common.Location = new System.Drawing.Point(4, 22);
            this.common.Margin = new System.Windows.Forms.Padding(2);
            this.common.Name = "common";
            this.common.Padding = new System.Windows.Forms.Padding(2);
            this.common.Size = new System.Drawing.Size(1504, 441);
            this.common.TabIndex = 0;
            this.common.Text = "Common";
            this.common.UseVisualStyleBackColor = true;
            // 
            // commonTabUserControl1
            // 
            this.commonTabUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonTabUserControl1.Location = new System.Drawing.Point(2, 2);
            this.commonTabUserControl1.Margin = new System.Windows.Forms.Padding(1);
            this.commonTabUserControl1.Name = "commonTabUserControl1";
            this.commonTabUserControl1.Size = new System.Drawing.Size(1500, 437);
            this.commonTabUserControl1.TabIndex = 0;
            // 
            // s7
            // 
            this.s7.Controls.Add(this.s7TabUserControl1);
            this.s7.Location = new System.Drawing.Point(4, 22);
            this.s7.Margin = new System.Windows.Forms.Padding(2);
            this.s7.Name = "s7";
            this.s7.Padding = new System.Windows.Forms.Padding(2);
            this.s7.Size = new System.Drawing.Size(1504, 441);
            this.s7.TabIndex = 1;
            this.s7.Text = "S7";
            this.s7.UseVisualStyleBackColor = true;
            // 
            // s7TabUserControl1
            // 
            this.s7TabUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s7TabUserControl1.Location = new System.Drawing.Point(2, 2);
            this.s7TabUserControl1.Margin = new System.Windows.Forms.Padding(1);
            this.s7TabUserControl1.Name = "s7TabUserControl1";
            this.s7TabUserControl1.Size = new System.Drawing.Size(1500, 437);
            this.s7TabUserControl1.TabIndex = 0;
            // 
            // logix
            // 
            this.logix.Controls.Add(this.logixTabUserControl1);
            this.logix.Location = new System.Drawing.Point(4, 22);
            this.logix.Margin = new System.Windows.Forms.Padding(2);
            this.logix.Name = "logix";
            this.logix.Padding = new System.Windows.Forms.Padding(2);
            this.logix.Size = new System.Drawing.Size(1504, 441);
            this.logix.TabIndex = 2;
            this.logix.Text = "Logix";
            this.logix.UseVisualStyleBackColor = true;
            // 
            // logixTabUserControl1
            // 
            this.logixTabUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logixTabUserControl1.Location = new System.Drawing.Point(2, 2);
            this.logixTabUserControl1.Margin = new System.Windows.Forms.Padding(1);
            this.logixTabUserControl1.Name = "logixTabUserControl1";
            this.logixTabUserControl1.Size = new System.Drawing.Size(1500, 437);
            this.logixTabUserControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1512, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // GeneralTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GeneralTabUserControl";
            this.Size = new System.Drawing.Size(1512, 491);
            this.tabControl1.ResumeLayout(false);
            this.common.ResumeLayout(false);
            this.s7.ResumeLayout(false);
            this.logix.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage common;
        private System.Windows.Forms.TabPage s7;
        private CommonTabUserControl commonTabUserControl1;
        private S7TabUserControl s7TabUserControl1;
        private System.Windows.Forms.TabPage logix;
        private LogixTabUserControl logixTabUserControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}
