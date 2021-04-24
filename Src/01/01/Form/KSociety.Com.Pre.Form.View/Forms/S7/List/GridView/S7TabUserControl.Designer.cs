
namespace KSociety.Com.Pre.Form.View.Forms.S7.List.GridView
{
    partial class S7TabUserControl
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
            this.tabControlS7 = new System.Windows.Forms.TabControl();
            this.s7Connection = new System.Windows.Forms.TabPage();
            this.comS7Connection = new S7Connection(this.components);
            this.s7Tag = new System.Windows.Forms.TabPage();
            this.comS7Tag = new S7Tag(this.components);
            this.tabControlS7.SuspendLayout();
            this.s7Connection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comS7Connection)).BeginInit();
            this.s7Tag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comS7Tag)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlS7
            // 
            this.tabControlS7.Controls.Add(this.s7Connection);
            this.tabControlS7.Controls.Add(this.s7Tag);
            this.tabControlS7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlS7.Location = new System.Drawing.Point(0, 0);
            this.tabControlS7.Name = "tabControlS7";
            this.tabControlS7.SelectedIndex = 0;
            this.tabControlS7.Size = new System.Drawing.Size(2116, 500);
            this.tabControlS7.TabIndex = 0;
            this.tabControlS7.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlS7_Selected);
            // 
            // s7Connection
            // 
            this.s7Connection.Controls.Add(this.comS7Connection);
            this.s7Connection.Location = new System.Drawing.Point(4, 29);
            this.s7Connection.Name = "s7Connection";
            this.s7Connection.Padding = new System.Windows.Forms.Padding(3);
            this.s7Connection.Size = new System.Drawing.Size(1572, 467);
            this.s7Connection.TabIndex = 0;
            this.s7Connection.Text = "S7 Connection";
            this.s7Connection.UseVisualStyleBackColor = true;
            // 
            // comS7Connection
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comS7Connection.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.comS7Connection.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comS7Connection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.comS7Connection.ColumnHeadersHeight = 34;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.comS7Connection.DefaultCellStyle = dataGridViewCellStyle3;
            this.comS7Connection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comS7Connection.Location = new System.Drawing.Point(3, 3);
            this.comS7Connection.Name = "comS7Connection";
            this.comS7Connection.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.comS7Connection.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.comS7Connection.RowTemplate.Height = 28;
            this.comS7Connection.Size = new System.Drawing.Size(1566, 461);
            this.comS7Connection.TabIndex = 0;
            // 
            // s7Tag
            // 
            this.s7Tag.Controls.Add(this.comS7Tag);
            this.s7Tag.Location = new System.Drawing.Point(4, 29);
            this.s7Tag.Name = "s7Tag";
            this.s7Tag.Padding = new System.Windows.Forms.Padding(3);
            this.s7Tag.Size = new System.Drawing.Size(2108, 467);
            this.s7Tag.TabIndex = 1;
            this.s7Tag.Text = "S7 Tag";
            this.s7Tag.UseVisualStyleBackColor = true;
            // 
            // comS7Tag
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comS7Tag.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.comS7Tag.AutoGenerateColumns = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comS7Tag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.comS7Tag.ColumnHeadersHeight = 34;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.comS7Tag.DefaultCellStyle = dataGridViewCellStyle7;
            this.comS7Tag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comS7Tag.Location = new System.Drawing.Point(3, 3);
            this.comS7Tag.Name = "comS7Tag";
            this.comS7Tag.RowHeadersWidth = 62;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.comS7Tag.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.comS7Tag.RowTemplate.Height = 28;
            this.comS7Tag.Size = new System.Drawing.Size(2102, 461);
            this.comS7Tag.TabIndex = 0;
            // 
            // S7TabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlS7);
            this.Name = "S7TabUserControl";
            this.Size = new System.Drawing.Size(2116, 500);
            this.tabControlS7.ResumeLayout(false);
            this.s7Connection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comS7Connection)).EndInit();
            this.s7Tag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comS7Tag)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlS7;
        private System.Windows.Forms.TabPage s7Connection;
        private System.Windows.Forms.TabPage s7Tag;
        private S7Connection comS7Connection;
        private S7Tag comS7Tag;
    }
}
