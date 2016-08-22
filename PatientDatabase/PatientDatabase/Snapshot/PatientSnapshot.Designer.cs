namespace PatientDatabase
{
    partial class PatientSnapshot
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.picPatientPicture = new System.Windows.Forms.PictureBox();
            this.rtxtGeneralInformation = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMedicalData = new System.Windows.Forms.Panel();
            this.cboMedicalDataInterval = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtxtMedicalData = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEndInterval = new System.Windows.Forms.ComboBox();
            this.cboStartInterval = new System.Windows.Forms.ComboBox();
            this.cboOutcome = new System.Windows.Forms.ComboBox();
            this.cboProtocol = new System.Windows.Forms.ComboBox();
            this.panelMEDTimeline = new System.Windows.Forms.Panel();
            this.panelChart = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chartOutcomeData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatientPicture)).BeginInit();
            this.panelMedicalData.SuspendLayout();
            this.panelChart.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOutcomeData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1337, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnHome);
            this.panel3.Controls.Add(this.btnBack);
            this.panel3.Location = new System.Drawing.Point(-7, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1352, 30);
            this.panel3.TabIndex = 28;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHome.Location = new System.Drawing.Point(1281, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(49, 23);
            this.btnHome.TabIndex = 7;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBack.Location = new System.Drawing.Point(20, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(49, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panelGeneral
            // 
            this.panelGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelGeneral.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGeneral.Controls.Add(this.picPatientPicture);
            this.panelGeneral.Controls.Add(this.rtxtGeneralInformation);
            this.panelGeneral.Location = new System.Drawing.Point(12, 85);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(273, 571);
            this.panelGeneral.TabIndex = 29;
            // 
            // picPatientPicture
            // 
            this.picPatientPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPatientPicture.Location = new System.Drawing.Point(7, 3);
            this.picPatientPicture.Name = "picPatientPicture";
            this.picPatientPicture.Size = new System.Drawing.Size(256, 256);
            this.picPatientPicture.TabIndex = 1;
            this.picPatientPicture.TabStop = false;
            // 
            // rtxtGeneralInformation
            // 
            this.rtxtGeneralInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtxtGeneralInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtGeneralInformation.Location = new System.Drawing.Point(3, 265);
            this.rtxtGeneralInformation.Name = "rtxtGeneralInformation";
            this.rtxtGeneralInformation.Size = new System.Drawing.Size(265, 301);
            this.rtxtGeneralInformation.TabIndex = 0;
            this.rtxtGeneralInformation.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(602, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Patient Snapshot";
            // 
            // panelMedicalData
            // 
            this.panelMedicalData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMedicalData.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelMedicalData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMedicalData.Controls.Add(this.cboMedicalDataInterval);
            this.panelMedicalData.Controls.Add(this.label6);
            this.panelMedicalData.Controls.Add(this.rtxtMedicalData);
            this.panelMedicalData.Location = new System.Drawing.Point(1052, 85);
            this.panelMedicalData.Name = "panelMedicalData";
            this.panelMedicalData.Size = new System.Drawing.Size(273, 571);
            this.panelMedicalData.TabIndex = 31;
            // 
            // cboMedicalDataInterval
            // 
            this.cboMedicalDataInterval.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboMedicalDataInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMedicalDataInterval.FormattingEnabled = true;
            this.cboMedicalDataInterval.Location = new System.Drawing.Point(74, 5);
            this.cboMedicalDataInterval.Name = "cboMedicalDataInterval";
            this.cboMedicalDataInterval.Size = new System.Drawing.Size(194, 28);
            this.cboMedicalDataInterval.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Interval:";
            // 
            // rtxtMedicalData
            // 
            this.rtxtMedicalData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtMedicalData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtMedicalData.Location = new System.Drawing.Point(3, 39);
            this.rtxtMedicalData.Name = "rtxtMedicalData";
            this.rtxtMedicalData.Size = new System.Drawing.Size(265, 527);
            this.rtxtMedicalData.TabIndex = 0;
            this.rtxtMedicalData.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(380, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "End Interval:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(374, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Start Interval:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Outcome:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Protocol:";
            // 
            // cboEndInterval
            // 
            this.cboEndInterval.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboEndInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEndInterval.FormattingEnabled = true;
            this.cboEndInterval.Location = new System.Drawing.Point(484, 45);
            this.cboEndInterval.Name = "cboEndInterval";
            this.cboEndInterval.Size = new System.Drawing.Size(140, 28);
            this.cboEndInterval.TabIndex = 35;
            // 
            // cboStartInterval
            // 
            this.cboStartInterval.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboStartInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStartInterval.FormattingEnabled = true;
            this.cboStartInterval.Location = new System.Drawing.Point(484, 8);
            this.cboStartInterval.Name = "cboStartInterval";
            this.cboStartInterval.Size = new System.Drawing.Size(140, 28);
            this.cboStartInterval.TabIndex = 34;
            // 
            // cboOutcome
            // 
            this.cboOutcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOutcome.FormattingEnabled = true;
            this.cboOutcome.Location = new System.Drawing.Point(212, 42);
            this.cboOutcome.Name = "cboOutcome";
            this.cboOutcome.Size = new System.Drawing.Size(140, 28);
            this.cboOutcome.TabIndex = 33;
            // 
            // cboProtocol
            // 
            this.cboProtocol.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProtocol.FormattingEnabled = true;
            this.cboProtocol.Location = new System.Drawing.Point(212, 8);
            this.cboProtocol.Name = "cboProtocol";
            this.cboProtocol.Size = new System.Drawing.Size(140, 28);
            this.cboProtocol.TabIndex = 32;
            // 
            // panelMEDTimeline
            // 
            this.panelMEDTimeline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMEDTimeline.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelMEDTimeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMEDTimeline.Location = new System.Drawing.Point(291, 586);
            this.panelMEDTimeline.Name = "panelMEDTimeline";
            this.panelMEDTimeline.Size = new System.Drawing.Size(755, 70);
            this.panelMEDTimeline.TabIndex = 41;
            // 
            // panelChart
            // 
            this.panelChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChart.Controls.Add(this.panel6);
            this.panelChart.Controls.Add(this.label2);
            this.panelChart.Controls.Add(this.cboEndInterval);
            this.panelChart.Controls.Add(this.cboStartInterval);
            this.panelChart.Controls.Add(this.label5);
            this.panelChart.Controls.Add(this.label3);
            this.panelChart.Controls.Add(this.cboOutcome);
            this.panelChart.Controls.Add(this.cboProtocol);
            this.panelChart.Controls.Add(this.label4);
            this.panelChart.Location = new System.Drawing.Point(291, 85);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(755, 495);
            this.panelChart.TabIndex = 42;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.chartOutcomeData);
            this.panel6.Location = new System.Drawing.Point(3, 81);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(747, 409);
            this.panel6.TabIndex = 40;
            // 
            // chartOutcomeData
            // 
            chartArea1.Name = "ChartArea1";
            this.chartOutcomeData.ChartAreas.Add(chartArea1);
            this.chartOutcomeData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartOutcomeData.Legends.Add(legend1);
            this.chartOutcomeData.Location = new System.Drawing.Point(0, 0);
            this.chartOutcomeData.Name = "chartOutcomeData";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartOutcomeData.Series.Add(series1);
            this.chartOutcomeData.Size = new System.Drawing.Size(745, 407);
            this.chartOutcomeData.TabIndex = 0;
            this.chartOutcomeData.Text = "chart1";
            // 
            // PatientSnapshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1337, 668);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelMEDTimeline);
            this.Controls.Add(this.panelMedicalData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelGeneral);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PatientSnapshot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientSnapshot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatientSnapshot_FormClosing);
            this.Load += new System.EventHandler(this.PatientSnapshot_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPatientPicture)).EndInit();
            this.panelMedicalData.ResumeLayout(false);
            this.panelMedicalData.PerformLayout();
            this.panelChart.ResumeLayout(false);
            this.panelChart.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartOutcomeData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMedicalData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEndInterval;
        private System.Windows.Forms.ComboBox cboStartInterval;
        private System.Windows.Forms.ComboBox cboOutcome;
        private System.Windows.Forms.ComboBox cboProtocol;
        private System.Windows.Forms.Panel panelMEDTimeline;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOutcomeData;
        private System.Windows.Forms.RichTextBox rtxtGeneralInformation;
        private System.Windows.Forms.RichTextBox rtxtMedicalData;
        private System.Windows.Forms.ComboBox cboMedicalDataInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picPatientPicture;
    }
}