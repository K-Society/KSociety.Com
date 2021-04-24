
namespace KSociety.Com.Pre.Form.View.Forms.Common.List.GridView
{
    partial class CommonTabUserControl
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
            this.tabControlCommon = new System.Windows.Forms.TabControl();
            this.commonTagGroup = new System.Windows.Forms.TabPage();
            this.comCommonTagGroup = new CommonTagGroup(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlCommon.SuspendLayout();
            this.commonTagGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comCommonTagGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlCommon
            // 
            this.tabControlCommon.Controls.Add(this.commonTagGroup);
            this.tabControlCommon.Controls.Add(this.tabPage1);
            this.tabControlCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCommon.Location = new System.Drawing.Point(0, 0);
            this.tabControlCommon.Name = "tabControlCommon";
            this.tabControlCommon.SelectedIndex = 0;
            this.tabControlCommon.Size = new System.Drawing.Size(1056, 467);
            this.tabControlCommon.TabIndex = 0;
            this.tabControlCommon.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlCommon_Selected);
            // 
            // commonTagGroup
            // 
            this.commonTagGroup.Controls.Add(this.comCommonTagGroup);
            this.commonTagGroup.Location = new System.Drawing.Point(4, 29);
            this.commonTagGroup.Name = "commonTagGroup";
            this.commonTagGroup.Padding = new System.Windows.Forms.Padding(3);
            this.commonTagGroup.Size = new System.Drawing.Size(1048, 434);
            this.commonTagGroup.TabIndex = 0;
            this.commonTagGroup.Text = "Common Tag Group";
            this.commonTagGroup.UseVisualStyleBackColor = true;
            // 
            // comCommonTagGroup
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comCommonTagGroup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.comCommonTagGroup.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comCommonTagGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.comCommonTagGroup.ColumnHeadersHeight = 34;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.comCommonTagGroup.DefaultCellStyle = dataGridViewCellStyle3;
            this.comCommonTagGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comCommonTagGroup.Location = new System.Drawing.Point(3, 3);
            this.comCommonTagGroup.Name = "comCommonTagGroup";
            this.comCommonTagGroup.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.comCommonTagGroup.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.comCommonTagGroup.RowTemplate.Height = 28;
            this.comCommonTagGroup.Size = new System.Drawing.Size(1042, 428);
            this.comCommonTagGroup.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1048, 434);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CommonTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlCommon);
            this.Name = "CommonTabUserControl";
            this.Size = new System.Drawing.Size(1056, 467);
            this.tabControlCommon.ResumeLayout(false);
            this.commonTagGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comCommonTagGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCommon;
        private System.Windows.Forms.TabPage commonTagGroup;
        private CommonTagGroup comCommonTagGroup;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
