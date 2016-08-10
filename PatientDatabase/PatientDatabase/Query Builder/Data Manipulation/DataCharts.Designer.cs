namespace PatientDatabase
{
    partial class DataCharts
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
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuCommandStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mnuCommandStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCount
            // 
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.Location = new System.Drawing.Point(70, 150);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtCount.Size = new System.Drawing.Size(386, 26);
            this.txtCount.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Charts";
            // 
            // mnuCommandStrip
            // 
            this.mnuCommandStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mnuCommandStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuCommandStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuCommandStrip.Name = "mnuCommandStrip";
            this.mnuCommandStrip.Size = new System.Drawing.Size(646, 24);
            this.mnuCommandStrip.TabIndex = 2;
            this.mnuCommandStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(70, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 72);
            this.panel1.TabIndex = 3;
            // 
            // DataCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 396);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnuCommandStrip);
            this.MainMenuStrip = this.mnuCommandStrip;
            this.Name = "DataCharts";
            this.Text = "DataCharts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataCharts_FormClosing);
            this.Load += new System.EventHandler(this.DataCharts_Load);
            this.mnuCommandStrip.ResumeLayout(false);
            this.mnuCommandStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnuCommandStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}