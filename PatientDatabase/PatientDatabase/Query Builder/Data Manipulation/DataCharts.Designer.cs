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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuCommandStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDataAnalysis = new System.Windows.Forms.Button();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQueryInfo = new System.Windows.Forms.TextBox();
            this.chartOutcomeData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoveSeries = new System.Windows.Forms.Button();
            this.btnEditSeries = new System.Windows.Forms.Button();
            this.btnAddNewSeries = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            this.cboEndInterval = new System.Windows.Forms.ComboBox();
            this.cboStartInterval = new System.Windows.Forms.ComboBox();
            this.cboOutcome = new System.Windows.Forms.ComboBox();
            this.cboProtocol = new System.Windows.Forms.ComboBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.mnuCommandStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOutcomeData)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(494, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Charts";
            // 
            // mnuCommandStrip
            // 
            this.mnuCommandStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mnuCommandStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuCommandStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuCommandStrip.Name = "mnuCommandStrip";
            this.mnuCommandStrip.Size = new System.Drawing.Size(1243, 24);
            this.mnuCommandStrip.TabIndex = 2;
            this.mnuCommandStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnDataAnalysis
            // 
            this.btnDataAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataAnalysis.Location = new System.Drawing.Point(978, 516);
            this.btnDataAnalysis.Name = "btnDataAnalysis";
            this.btnDataAnalysis.Size = new System.Drawing.Size(196, 31);
            this.btnDataAnalysis.TabIndex = 13;
            this.btnDataAnalysis.Text = "Data Analysis";
            this.btnDataAnalysis.UseVisualStyleBackColor = true;
            // 
            // lstFilters
            // 
            this.lstFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 20;
            this.lstFilters.Location = new System.Drawing.Point(978, 42);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.Size = new System.Drawing.Size(196, 124);
            this.lstFilters.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1014, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Queries/Filters";
            // 
            // txtQueryInfo
            // 
            this.txtQueryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueryInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueryInfo.Location = new System.Drawing.Point(978, 320);
            this.txtQueryInfo.Multiline = true;
            this.txtQueryInfo.Name = "txtQueryInfo";
            this.txtQueryInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQueryInfo.Size = new System.Drawing.Size(196, 190);
            this.txtQueryInfo.TabIndex = 9;
            this.txtQueryInfo.WordWrap = false;
            // 
            // chartOutcomeData
            // 
            chartArea2.Name = "ChartArea1";
            this.chartOutcomeData.ChartAreas.Add(chartArea2);
            this.chartOutcomeData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartOutcomeData.Legends.Add(legend2);
            this.chartOutcomeData.Location = new System.Drawing.Point(0, 0);
            this.chartOutcomeData.Name = "chartOutcomeData";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartOutcomeData.Series.Add(series2);
            this.chartOutcomeData.Size = new System.Drawing.Size(948, 459);
            this.chartOutcomeData.TabIndex = 8;
            this.chartOutcomeData.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chartOutcomeData);
            this.panel1.Location = new System.Drawing.Point(3, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 461);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnRemoveSeries);
            this.panel2.Controls.Add(this.btnEditSeries);
            this.panel2.Controls.Add(this.btnAddNewSeries);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnToggle);
            this.panel2.Controls.Add(this.cboEndInterval);
            this.panel2.Controls.Add(this.cboStartInterval);
            this.panel2.Controls.Add(this.cboOutcome);
            this.panel2.Controls.Add(this.cboProtocol);
            this.panel2.Controls.Add(this.btnMoveDown);
            this.panel2.Controls.Add(this.btnMoveUp);
            this.panel2.Controls.Add(this.lstFilters);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.txtQueryInfo);
            this.panel2.Controls.Add(this.btnDataAnalysis);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(12, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 553);
            this.panel2.TabIndex = 15;
            // 
            // btnRemoveSeries
            // 
            this.btnRemoveSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSeries.Location = new System.Drawing.Point(978, 283);
            this.btnRemoveSeries.Name = "btnRemoveSeries";
            this.btnRemoveSeries.Size = new System.Drawing.Size(196, 31);
            this.btnRemoveSeries.TabIndex = 31;
            this.btnRemoveSeries.Text = "Remove Series";
            this.btnRemoveSeries.UseVisualStyleBackColor = true;
            // 
            // btnEditSeries
            // 
            this.btnEditSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSeries.Location = new System.Drawing.Point(978, 246);
            this.btnEditSeries.Name = "btnEditSeries";
            this.btnEditSeries.Size = new System.Drawing.Size(196, 31);
            this.btnEditSeries.TabIndex = 30;
            this.btnEditSeries.Text = "Edit Series";
            this.btnEditSeries.UseVisualStyleBackColor = true;
            // 
            // btnAddNewSeries
            // 
            this.btnAddNewSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewSeries.Location = new System.Drawing.Point(978, 209);
            this.btnAddNewSeries.Name = "btnAddNewSeries";
            this.btnAddNewSeries.Size = new System.Drawing.Size(196, 31);
            this.btnAddNewSeries.TabIndex = 29;
            this.btnAddNewSeries.Text = "Add New Series";
            this.btnAddNewSeries.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(752, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "End Interval";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(535, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Start Interval";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Outcome";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Protocol";
            // 
            // btnToggle
            // 
            this.btnToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggle.Location = new System.Drawing.Point(978, 172);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(196, 31);
            this.btnToggle.TabIndex = 23;
            this.btnToggle.Text = "Toggle On/Off";
            this.btnToggle.UseVisualStyleBackColor = true;
            // 
            // cboEndInterval
            // 
            this.cboEndInterval.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboEndInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEndInterval.FormattingEnabled = true;
            this.cboEndInterval.Location = new System.Drawing.Point(727, 42);
            this.cboEndInterval.Name = "cboEndInterval";
            this.cboEndInterval.Size = new System.Drawing.Size(140, 28);
            this.cboEndInterval.TabIndex = 21;
            this.cboEndInterval.SelectedIndexChanged += new System.EventHandler(this.cboEndInterval_SelectedIndexChanged);
            // 
            // cboStartInterval
            // 
            this.cboStartInterval.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboStartInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStartInterval.FormattingEnabled = true;
            this.cboStartInterval.Location = new System.Drawing.Point(514, 42);
            this.cboStartInterval.Name = "cboStartInterval";
            this.cboStartInterval.Size = new System.Drawing.Size(140, 28);
            this.cboStartInterval.TabIndex = 20;
            this.cboStartInterval.SelectedIndexChanged += new System.EventHandler(this.cboStartInterval_SelectedIndexChanged);
            // 
            // cboOutcome
            // 
            this.cboOutcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOutcome.FormattingEnabled = true;
            this.cboOutcome.Location = new System.Drawing.Point(301, 42);
            this.cboOutcome.Name = "cboOutcome";
            this.cboOutcome.Size = new System.Drawing.Size(140, 28);
            this.cboOutcome.TabIndex = 19;
            this.cboOutcome.SelectedIndexChanged += new System.EventHandler(this.cboOutcome_SelectedIndexChanged);
            // 
            // cboProtocol
            // 
            this.cboProtocol.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProtocol.FormattingEnabled = true;
            this.cboProtocol.Location = new System.Drawing.Point(88, 42);
            this.cboProtocol.Name = "cboProtocol";
            this.cboProtocol.Size = new System.Drawing.Size(140, 28);
            this.cboProtocol.TabIndex = 18;
            this.cboProtocol.SelectedIndexChanged += new System.EventHandler(this.cboProtocol_SelectedIndexChanged);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(1180, 108);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(34, 35);
            this.btnMoveDown.TabIndex = 17;
            this.btnMoveDown.Text = "V";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(1180, 68);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(34, 34);
            this.btnMoveUp.TabIndex = 16;
            this.btnMoveUp.Text = "Ʌ";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnHome);
            this.panel3.Controls.Add(this.btnBack);
            this.panel3.Location = new System.Drawing.Point(-8, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1259, 30);
            this.panel3.TabIndex = 27;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHome.Location = new System.Drawing.Point(1188, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(49, 23);
            this.btnHome.TabIndex = 7;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
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
            // 
            // DataCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1243, 668);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnuCommandStrip);
            this.MainMenuStrip = this.mnuCommandStrip;
            this.Name = "DataCharts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataCharts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataCharts_FormClosing);
            this.Load += new System.EventHandler(this.DataCharts_Load);
            this.mnuCommandStrip.ResumeLayout(false);
            this.mnuCommandStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOutcomeData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnuCommandStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button btnDataAnalysis;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQueryInfo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOutcomeData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.ComboBox cboEndInterval;
        private System.Windows.Forms.ComboBox cboStartInterval;
        private System.Windows.Forms.ComboBox cboOutcome;
        private System.Windows.Forms.ComboBox cboProtocol;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemoveSeries;
        private System.Windows.Forms.Button btnEditSeries;
        private System.Windows.Forms.Button btnAddNewSeries;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBack;
    }
}