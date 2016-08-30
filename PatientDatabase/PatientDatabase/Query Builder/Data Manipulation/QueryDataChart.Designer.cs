namespace PatientDatabase
{
    partial class QueryDataChart
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
            this.label1 = new System.Windows.Forms.Label();
            this.mnuCommandStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyShowStartAndEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yAxisScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YAxisInterval20toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YAxisInterval10toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YAxisInterval5toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSelectedSeriesAveragesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valueOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeOnlyEligibleValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstSeries = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chartOutcomeData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtxtQueryData = new System.Windows.Forms.RichTextBox();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            this.cboEndInterval = new System.Windows.Forms.ComboBox();
            this.cboStartInterval = new System.Windows.Forms.ComboBox();
            this.cboOutcome = new System.Windows.Forms.ComboBox();
            this.cboProtocol = new System.Windows.Forms.ComboBox();
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
            this.label1.Location = new System.Drawing.Point(574, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Charts";
            // 
            // mnuCommandStrip
            // 
            this.mnuCommandStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mnuCommandStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.chartToolStripMenuItem});
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
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intervalOptionsToolStripMenuItem,
            this.yAxisScaleToolStripMenuItem,
            this.showGridToolStripMenuItem,
            this.labelOptionsToolStripMenuItem,
            this.valueOptionsToolStripMenuItem});
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // intervalOptionsToolStripMenuItem
            // 
            this.intervalOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlyShowStartAndEndToolStripMenuItem});
            this.intervalOptionsToolStripMenuItem.Name = "intervalOptionsToolStripMenuItem";
            this.intervalOptionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.intervalOptionsToolStripMenuItem.Text = "Interval Options";
            // 
            // onlyShowStartAndEndToolStripMenuItem
            // 
            this.onlyShowStartAndEndToolStripMenuItem.Name = "onlyShowStartAndEndToolStripMenuItem";
            this.onlyShowStartAndEndToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.onlyShowStartAndEndToolStripMenuItem.Text = "Only Show Start and End";
            this.onlyShowStartAndEndToolStripMenuItem.Click += new System.EventHandler(this.onlyShowStartAndEndToolStripMenuItem_Click);
            // 
            // yAxisScaleToolStripMenuItem
            // 
            this.yAxisScaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YAxisInterval20toolStripMenuItem,
            this.YAxisInterval10toolStripMenuItem,
            this.YAxisInterval5toolStripMenuItem});
            this.yAxisScaleToolStripMenuItem.Name = "yAxisScaleToolStripMenuItem";
            this.yAxisScaleToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.yAxisScaleToolStripMenuItem.Text = "Y Axis Scale";
            // 
            // YAxisInterval20toolStripMenuItem
            // 
            this.YAxisInterval20toolStripMenuItem.Checked = true;
            this.YAxisInterval20toolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.YAxisInterval20toolStripMenuItem.Name = "YAxisInterval20toolStripMenuItem";
            this.YAxisInterval20toolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.YAxisInterval20toolStripMenuItem.Text = "20";
            this.YAxisInterval20toolStripMenuItem.Click += new System.EventHandler(this.YAxisInterval20toolStripMenuItem_Click);
            // 
            // YAxisInterval10toolStripMenuItem
            // 
            this.YAxisInterval10toolStripMenuItem.Name = "YAxisInterval10toolStripMenuItem";
            this.YAxisInterval10toolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.YAxisInterval10toolStripMenuItem.Text = "10";
            this.YAxisInterval10toolStripMenuItem.Click += new System.EventHandler(this.YAxisInterval10toolStripMenuItem_Click);
            // 
            // YAxisInterval5toolStripMenuItem
            // 
            this.YAxisInterval5toolStripMenuItem.Name = "YAxisInterval5toolStripMenuItem";
            this.YAxisInterval5toolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.YAxisInterval5toolStripMenuItem.Text = "5";
            this.YAxisInterval5toolStripMenuItem.Click += new System.EventHandler(this.YAxisInterval5toolStripMenuItem_Click);
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.Checked = true;
            this.showGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showGridToolStripMenuItem.Text = "Show Grid";
            this.showGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
            // 
            // labelOptionsToolStripMenuItem
            // 
            this.labelOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSelectedSeriesAveragesToolStripMenuItem});
            this.labelOptionsToolStripMenuItem.Name = "labelOptionsToolStripMenuItem";
            this.labelOptionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.labelOptionsToolStripMenuItem.Text = "Label Options";
            // 
            // showSelectedSeriesAveragesToolStripMenuItem
            // 
            this.showSelectedSeriesAveragesToolStripMenuItem.Name = "showSelectedSeriesAveragesToolStripMenuItem";
            this.showSelectedSeriesAveragesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.showSelectedSeriesAveragesToolStripMenuItem.Text = "Show Selected Series Averages";
            this.showSelectedSeriesAveragesToolStripMenuItem.Click += new System.EventHandler(this.showSelectedSeriesAveragesToolStripMenuItem_Click);
            // 
            // valueOptionsToolStripMenuItem
            // 
            this.valueOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeOnlyEligibleValuesToolStripMenuItem});
            this.valueOptionsToolStripMenuItem.Name = "valueOptionsToolStripMenuItem";
            this.valueOptionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.valueOptionsToolStripMenuItem.Text = "Value Options";
            // 
            // includeOnlyEligibleValuesToolStripMenuItem
            // 
            this.includeOnlyEligibleValuesToolStripMenuItem.Checked = true;
            this.includeOnlyEligibleValuesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeOnlyEligibleValuesToolStripMenuItem.Name = "includeOnlyEligibleValuesToolStripMenuItem";
            this.includeOnlyEligibleValuesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.includeOnlyEligibleValuesToolStripMenuItem.Text = "Include Only Eligible Values";
            this.includeOnlyEligibleValuesToolStripMenuItem.Click += new System.EventHandler(this.includeOnlyEligibleValuesToolStripMenuItem_Click);
            // 
            // lstSeries
            // 
            this.lstSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSeries.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSeries.FormattingEnabled = true;
            this.lstSeries.HorizontalScrollbar = true;
            this.lstSeries.ItemHeight = 20;
            this.lstSeries.Location = new System.Drawing.Point(1018, 42);
            this.lstSeries.Name = "lstSeries";
            this.lstSeries.Size = new System.Drawing.Size(168, 124);
            this.lstSeries.TabIndex = 11;
            this.lstSeries.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstSeries_DrawItem);
            this.lstSeries.SelectedIndexChanged += new System.EventHandler(this.lstSeries_SelectedIndexChanged);
            this.lstSeries.DoubleClick += new System.EventHandler(this.lstSeries_DoubleClick);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1055, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Series Data";
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
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartOutcomeData.Series.Add(series1);
            this.chartOutcomeData.Size = new System.Drawing.Size(1007, 503);
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
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 505);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rtxtQueryData);
            this.panel2.Controls.Add(this.btnMoveUp);
            this.panel2.Controls.Add(this.btnMoveDown);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnToggle);
            this.panel2.Controls.Add(this.cboEndInterval);
            this.panel2.Controls.Add(this.cboStartInterval);
            this.panel2.Controls.Add(this.cboOutcome);
            this.panel2.Controls.Add(this.cboProtocol);
            this.panel2.Controls.Add(this.lstSeries);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(12, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 553);
            this.panel2.TabIndex = 15;
            // 
            // rtxtQueryData
            // 
            this.rtxtQueryData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtQueryData.BackColor = System.Drawing.Color.White;
            this.rtxtQueryData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtQueryData.Location = new System.Drawing.Point(1018, 209);
            this.rtxtQueryData.Name = "rtxtQueryData";
            this.rtxtQueryData.ReadOnly = true;
            this.rtxtQueryData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtxtQueryData.Size = new System.Drawing.Size(196, 337);
            this.rtxtQueryData.TabIndex = 34;
            this.rtxtQueryData.Text = "";
            this.rtxtQueryData.WordWrap = false;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(1188, 67);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(26, 33);
            this.btnMoveUp.TabIndex = 33;
            this.btnMoveUp.Text = "Λ";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(1188, 106);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(26, 33);
            this.btnMoveDown.TabIndex = 32;
            this.btnMoveDown.Text = "V";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(768, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "End Interval:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(496, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Start Interval:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Outcome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Protocol:";
            // 
            // btnToggle
            // 
            this.btnToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggle.Location = new System.Drawing.Point(1018, 172);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(196, 31);
            this.btnToggle.TabIndex = 23;
            this.btnToggle.Text = "Toggle On/Off";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // cboEndInterval
            // 
            this.cboEndInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEndInterval.FormattingEnabled = true;
            this.cboEndInterval.Location = new System.Drawing.Point(872, 7);
            this.cboEndInterval.Name = "cboEndInterval";
            this.cboEndInterval.Size = new System.Drawing.Size(140, 28);
            this.cboEndInterval.TabIndex = 21;
            this.cboEndInterval.SelectedIndexChanged += new System.EventHandler(this.cboEndInterval_SelectedIndexChanged);
            // 
            // cboStartInterval
            // 
            this.cboStartInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStartInterval.FormattingEnabled = true;
            this.cboStartInterval.Location = new System.Drawing.Point(606, 7);
            this.cboStartInterval.Name = "cboStartInterval";
            this.cboStartInterval.Size = new System.Drawing.Size(140, 28);
            this.cboStartInterval.TabIndex = 20;
            this.cboStartInterval.SelectedIndexChanged += new System.EventHandler(this.cboStartInterval_SelectedIndexChanged);
            // 
            // cboOutcome
            // 
            this.cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOutcome.FormattingEnabled = true;
            this.cboOutcome.Location = new System.Drawing.Point(328, 7);
            this.cboOutcome.Name = "cboOutcome";
            this.cboOutcome.Size = new System.Drawing.Size(140, 28);
            this.cboOutcome.TabIndex = 19;
            this.cboOutcome.SelectedIndexChanged += new System.EventHandler(this.cboOutcome_SelectedIndexChanged);
            // 
            // cboProtocol
            // 
            this.cboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProtocol.FormattingEnabled = true;
            this.cboProtocol.Location = new System.Drawing.Point(79, 7);
            this.cboProtocol.Name = "cboProtocol";
            this.cboProtocol.Size = new System.Drawing.Size(140, 28);
            this.cboProtocol.TabIndex = 18;
            this.cboProtocol.SelectedIndexChanged += new System.EventHandler(this.cboProtocol_SelectedIndexChanged);
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
            // QueryDataChart
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
            this.MinimumSize = new System.Drawing.Size(1259, 707);
            this.Name = "QueryDataChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueryDataChart";
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
        private System.Windows.Forms.ListBox lstSeries;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOutcomeData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboEndInterval;
        private System.Windows.Forms.ComboBox cboStartInterval;
        private System.Windows.Forms.ComboBox cboOutcome;
        private System.Windows.Forms.ComboBox cboProtocol;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.RichTextBox rtxtQueryData;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervalOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyShowStartAndEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yAxisScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YAxisInterval20toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YAxisInterval10toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YAxisInterval5toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSelectedSeriesAveragesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valueOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeOnlyEligibleValuesToolStripMenuItem;
    }
}