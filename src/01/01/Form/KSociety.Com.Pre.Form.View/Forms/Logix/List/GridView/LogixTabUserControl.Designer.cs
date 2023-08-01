
namespace KSociety.Com.Pre.Form.View.Forms.Logix.List.GridView
{
    partial class LogixTabUserControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlLogix = new System.Windows.Forms.TabControl();
            this.logixConnection = new System.Windows.Forms.TabPage();
            this.logixTag = new System.Windows.Forms.TabPage();
            this.comLogixConnection = new LogixConnection(this.components);
            this.comLogixTag = new LogixTag(this.components);
            this.tabControlLogix.SuspendLayout();
            this.logixConnection.SuspendLayout();
            this.logixTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comLogixConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLogixTag)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlLogix
            // 
            this.tabControlLogix.Controls.Add(this.logixConnection);
            this.tabControlLogix.Controls.Add(this.logixTag);
            this.tabControlLogix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLogix.Location = new System.Drawing.Point(0, 0);
            this.tabControlLogix.Name = "tabControlLogix";
            this.tabControlLogix.SelectedIndex = 0;
            this.tabControlLogix.Size = new System.Drawing.Size(1367, 522);
            this.tabControlLogix.TabIndex = 0;
            this.tabControlLogix.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlLogix_Selected);
            // 
            // logixConnection
            // 
            this.logixConnection.Controls.Add(this.comLogixConnection);
            this.logixConnection.Location = new System.Drawing.Point(4, 29);
            this.logixConnection.Name = "logixConnection";
            this.logixConnection.Padding = new System.Windows.Forms.Padding(3);
            this.logixConnection.Size = new System.Drawing.Size(1359, 489);
            this.logixConnection.TabIndex = 0;
            this.logixConnection.Text = "Logic Connection";
            this.logixConnection.UseVisualStyleBackColor = true;
            // 
            // logixTag
            // 
            this.logixTag.Controls.Add(this.comLogixTag);
            this.logixTag.Location = new System.Drawing.Point(4, 29);
            this.logixTag.Name = "logixTag";
            this.logixTag.Padding = new System.Windows.Forms.Padding(3);
            this.logixTag.Size = new System.Drawing.Size(1359, 489);
            this.logixTag.TabIndex = 1;
            this.logixTag.Text = "Logix Tag";
            this.logixTag.UseVisualStyleBackColor = true;
            // 
            // comLogixConnection
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comLogixConnection.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.comLogixConnection.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comLogixConnection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.comLogixConnection.ColumnHeadersHeight = 34;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.comLogixConnection.DefaultCellStyle = dataGridViewCellStyle3;
            this.comLogixConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comLogixConnection.Location = new System.Drawing.Point(3, 3);
            this.comLogixConnection.Name = "comLogixConnection";
            this.comLogixConnection.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.comLogixConnection.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.comLogixConnection.RowTemplate.Height = 28;
            this.comLogixConnection.Size = new System.Drawing.Size(1353, 483);
            this.comLogixConnection.TabIndex = 0;
            // 
            // comLogixTag
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comLogixTag.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.comLogixTag.AutoGenerateColumns = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comLogixTag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.comLogixTag.ColumnHeadersHeight = 34;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.comLogixTag.DefaultCellStyle = dataGridViewCellStyle7;
            this.comLogixTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comLogixTag.Location = new System.Drawing.Point(3, 3);
            this.comLogixTag.Name = "comLogixTag";
            this.comLogixTag.RowHeadersWidth = 62;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.comLogixTag.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.comLogixTag.RowTemplate.Height = 28;
            this.comLogixTag.Size = new System.Drawing.Size(1353, 483);
            this.comLogixTag.TabIndex = 0;
            // 
            // LogixTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlLogix);
            this.Name = "LogixTabUserControl";
            this.Size = new System.Drawing.Size(1367, 522);
            this.tabControlLogix.ResumeLayout(false);
            this.logixConnection.ResumeLayout(false);
            this.logixTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comLogixConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLogixTag)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlLogix;
        private System.Windows.Forms.TabPage logixConnection;
        private System.Windows.Forms.TabPage logixTag;
        private LogixConnection comLogixConnection;
        private LogixTag comLogixTag;
    }
}
