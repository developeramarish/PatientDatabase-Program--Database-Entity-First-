namespace PatientDatabase
{
    partial class QueryResults
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mnuCommandStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tpCurrentQuery = new System.Windows.Forms.TabPage();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnInverse = new System.Windows.Forms.Button();
            this.btnAndOr = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnRemoveQuery = new System.Windows.Forms.Button();
            this.btnAddQuery = new System.Windows.Forms.Button();
            this.btnEditQuery = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.dgvCurrentQuery = new System.Windows.Forms.DataGridView();
            this.cGate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFilter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.tpCharts = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.btnDeleteFilter = new System.Windows.Forms.Button();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGraphCount = new System.Windows.Forms.TextBox();
            this.btnFullView = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboGraphType = new System.Windows.Forms.ComboBox();
            this.cboProtocol = new System.Windows.Forms.ComboBox();
            this.cboOutcome = new System.Windows.Forms.ComboBox();
            this.cboStartInterval = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboEndInterval = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mnuCommandStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbControl.SuspendLayout();
            this.tpCurrentQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentQuery)).BeginInit();
            this.tpCharts.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuCommandStrip
            // 
            this.mnuCommandStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mnuCommandStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuCommandStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuCommandStrip.Name = "mnuCommandStrip";
            this.mnuCommandStrip.Size = new System.Drawing.Size(1030, 24);
            this.mnuCommandStrip.TabIndex = 0;
            this.mnuCommandStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Location = new System.Drawing.Point(-8, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1047, 30);
            this.panel2.TabIndex = 26;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHome.Location = new System.Drawing.Point(976, 2);
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(461, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Query Results";
            // 
            // tbControl
            // 
            this.tbControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbControl.Controls.Add(this.tpCurrentQuery);
            this.tbControl.Controls.Add(this.tpCharts);
            this.tbControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbControl.ItemSize = new System.Drawing.Size(120, 25);
            this.tbControl.Location = new System.Drawing.Point(13, 102);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(845, 457);
            this.tbControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbControl.TabIndex = 29;
            // 
            // tpCurrentQuery
            // 
            this.tpCurrentQuery.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpCurrentQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpCurrentQuery.Controls.Add(this.btnPaste);
            this.tpCurrentQuery.Controls.Add(this.btnCopy);
            this.tpCurrentQuery.Controls.Add(this.btnInverse);
            this.tpCurrentQuery.Controls.Add(this.btnAndOr);
            this.tpCurrentQuery.Controls.Add(this.btnMoveDown);
            this.tpCurrentQuery.Controls.Add(this.btnRemoveQuery);
            this.tpCurrentQuery.Controls.Add(this.btnAddQuery);
            this.tpCurrentQuery.Controls.Add(this.btnEditQuery);
            this.tpCurrentQuery.Controls.Add(this.btnMoveUp);
            this.tpCurrentQuery.Controls.Add(this.dgvCurrentQuery);
            this.tpCurrentQuery.Controls.Add(this.txtCount);
            this.tpCurrentQuery.Location = new System.Drawing.Point(4, 29);
            this.tpCurrentQuery.Name = "tpCurrentQuery";
            this.tpCurrentQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tpCurrentQuery.Size = new System.Drawing.Size(837, 424);
            this.tpCurrentQuery.TabIndex = 0;
            this.tpCurrentQuery.Text = "Current Query";
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Enabled = false;
            this.btnPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaste.Location = new System.Drawing.Point(694, 211);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(135, 35);
            this.btnPaste.TabIndex = 37;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Enabled = false;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(694, 170);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(135, 35);
            this.btnCopy.TabIndex = 36;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnInverse
            // 
            this.btnInverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInverse.Enabled = false;
            this.btnInverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInverse.Location = new System.Drawing.Point(694, 88);
            this.btnInverse.Name = "btnInverse";
            this.btnInverse.Size = new System.Drawing.Size(135, 35);
            this.btnInverse.TabIndex = 35;
            this.btnInverse.Text = "Inverse";
            this.btnInverse.UseVisualStyleBackColor = true;
            // 
            // btnAndOr
            // 
            this.btnAndOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAndOr.Enabled = false;
            this.btnAndOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAndOr.Location = new System.Drawing.Point(694, 129);
            this.btnAndOr.Name = "btnAndOr";
            this.btnAndOr.Size = new System.Drawing.Size(135, 35);
            this.btnAndOr.TabIndex = 34;
            this.btnAndOr.Text = "And/Or";
            this.btnAndOr.UseVisualStyleBackColor = true;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(694, 47);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(135, 35);
            this.btnMoveDown.TabIndex = 32;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            // 
            // btnRemoveQuery
            // 
            this.btnRemoveQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveQuery.Enabled = false;
            this.btnRemoveQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveQuery.Location = new System.Drawing.Point(694, 332);
            this.btnRemoveQuery.Name = "btnRemoveQuery";
            this.btnRemoveQuery.Size = new System.Drawing.Size(135, 34);
            this.btnRemoveQuery.TabIndex = 31;
            this.btnRemoveQuery.Text = "Remove Query";
            this.btnRemoveQuery.UseVisualStyleBackColor = true;
            // 
            // btnAddQuery
            // 
            this.btnAddQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddQuery.Enabled = false;
            this.btnAddQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuery.Location = new System.Drawing.Point(694, 252);
            this.btnAddQuery.Name = "btnAddQuery";
            this.btnAddQuery.Size = new System.Drawing.Size(135, 34);
            this.btnAddQuery.TabIndex = 30;
            this.btnAddQuery.Text = "Add Query";
            this.btnAddQuery.UseVisualStyleBackColor = true;
            // 
            // btnEditQuery
            // 
            this.btnEditQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditQuery.Enabled = false;
            this.btnEditQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditQuery.Location = new System.Drawing.Point(694, 292);
            this.btnEditQuery.Name = "btnEditQuery";
            this.btnEditQuery.Size = new System.Drawing.Size(135, 34);
            this.btnEditQuery.TabIndex = 33;
            this.btnEditQuery.Text = "Edit Query";
            this.btnEditQuery.UseVisualStyleBackColor = true;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(694, 6);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(135, 35);
            this.btnMoveUp.TabIndex = 29;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            // 
            // dgvCurrentQuery
            // 
            this.dgvCurrentQuery.AllowUserToAddRows = false;
            this.dgvCurrentQuery.AllowUserToDeleteRows = false;
            this.dgvCurrentQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCurrentQuery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentQuery.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvCurrentQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cGate,
            this.cProperty,
            this.cCriteria,
            this.cFilter});
            this.dgvCurrentQuery.Location = new System.Drawing.Point(6, 6);
            this.dgvCurrentQuery.MultiSelect = false;
            this.dgvCurrentQuery.Name = "dgvCurrentQuery";
            this.dgvCurrentQuery.ReadOnly = true;
            this.dgvCurrentQuery.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCurrentQuery.RowHeadersVisible = false;
            this.dgvCurrentQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentQuery.Size = new System.Drawing.Size(681, 366);
            this.dgvCurrentQuery.TabIndex = 28;
            // 
            // cGate
            // 
            this.cGate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cGate.HeaderText = "Gate";
            this.cGate.Name = "cGate";
            this.cGate.ReadOnly = true;
            this.cGate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cGate.Width = 51;
            // 
            // cProperty
            // 
            this.cProperty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cProperty.HeaderText = "Property";
            this.cProperty.Name = "cProperty";
            this.cProperty.ReadOnly = true;
            this.cProperty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cCriteria
            // 
            this.cCriteria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cCriteria.HeaderText = "Criteria";
            this.cCriteria.Name = "cCriteria";
            this.cCriteria.ReadOnly = true;
            this.cCriteria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cFilter
            // 
            this.cFilter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cFilter.HeaderText = "Filter";
            this.cFilter.Name = "cFilter";
            this.cFilter.ReadOnly = true;
            this.cFilter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCount.BackColor = System.Drawing.Color.White;
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.Location = new System.Drawing.Point(6, 378);
            this.txtCount.Multiline = true;
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtCount.Size = new System.Drawing.Size(465, 42);
            this.txtCount.TabIndex = 2;
            this.txtCount.WordWrap = false;
            // 
            // tpCharts
            // 
            this.tpCharts.AutoScroll = true;
            this.tpCharts.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpCharts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpCharts.Controls.Add(this.cboGraphType);
            this.tpCharts.Controls.Add(this.label7);
            this.tpCharts.Controls.Add(this.label6);
            this.tpCharts.Controls.Add(this.cboEndInterval);
            this.tpCharts.Controls.Add(this.btnFullView);
            this.tpCharts.Controls.Add(this.txtGraphCount);
            this.tpCharts.Controls.Add(this.label4);
            this.tpCharts.Controls.Add(this.label3);
            this.tpCharts.Controls.Add(this.panel1);
            this.tpCharts.Controls.Add(this.label2);
            this.tpCharts.Controls.Add(this.cboStartInterval);
            this.tpCharts.Controls.Add(this.cboOutcome);
            this.tpCharts.Controls.Add(this.cboProtocol);
            this.tpCharts.Location = new System.Drawing.Point(4, 29);
            this.tpCharts.Name = "tpCharts";
            this.tpCharts.Size = new System.Drawing.Size(837, 424);
            this.tpCharts.TabIndex = 1;
            this.tpCharts.Text = "Charts";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(2, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 313);
            this.panel1.TabIndex = 5;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(-1, -1);
            this.chart1.Name = "chart1";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(831, 313);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFilter.Location = new System.Drawing.Point(864, 491);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(154, 31);
            this.btnAddFilter.TabIndex = 30;
            this.btnAddFilter.Text = "Add Filter";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // btnDeleteFilter
            // 
            this.btnDeleteFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFilter.Location = new System.Drawing.Point(864, 528);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(154, 31);
            this.btnDeleteFilter.TabIndex = 31;
            this.btnDeleteFilter.Text = "Delete Filter";
            this.btnDeleteFilter.UseVisualStyleBackColor = true;
            this.btnDeleteFilter.Click += new System.EventHandler(this.btnDeleteFilter_Click);
            // 
            // lstFilters
            // 
            this.lstFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 20;
            this.lstFilters.Location = new System.Drawing.Point(864, 151);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.Size = new System.Drawing.Size(154, 284);
            this.lstFilters.TabIndex = 32;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(864, 454);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(154, 31);
            this.btnSelect.TabIndex = 33;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(915, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "Filters";
            // 
            // txtGraphCount
            // 
            this.txtGraphCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGraphCount.BackColor = System.Drawing.Color.White;
            this.txtGraphCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGraphCount.Location = new System.Drawing.Point(6, 378);
            this.txtGraphCount.Multiline = true;
            this.txtGraphCount.Name = "txtGraphCount";
            this.txtGraphCount.ReadOnly = true;
            this.txtGraphCount.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtGraphCount.Size = new System.Drawing.Size(431, 42);
            this.txtGraphCount.TabIndex = 8;
            this.txtGraphCount.WordWrap = false;
            // 
            // btnFullView
            // 
            this.btnFullView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullView.Location = new System.Drawing.Point(687, 378);
            this.btnFullView.Name = "btnFullView";
            this.btnFullView.Size = new System.Drawing.Size(145, 42);
            this.btnFullView.TabIndex = 9;
            this.btnFullView.Text = "Detailed View";
            this.btnFullView.UseVisualStyleBackColor = true;
            this.btnFullView.Click += new System.EventHandler(this.btnFullView_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(456, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Graph Type:";
            // 
            // cboGraphType
            // 
            this.cboGraphType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGraphType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGraphType.FormattingEnabled = true;
            this.cboGraphType.Location = new System.Drawing.Point(558, 386);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.Size = new System.Drawing.Size(121, 28);
            this.cboGraphType.TabIndex = 13;
            // 
            // cboProtocol
            // 
            this.cboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtocol.FormattingEnabled = true;
            this.cboProtocol.Location = new System.Drawing.Point(22, 29);
            this.cboProtocol.Name = "cboProtocol";
            this.cboProtocol.Size = new System.Drawing.Size(158, 28);
            this.cboProtocol.TabIndex = 1;
            // 
            // cboOutcome
            // 
            this.cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutcome.FormattingEnabled = true;
            this.cboOutcome.Location = new System.Drawing.Point(235, 29);
            this.cboOutcome.Name = "cboOutcome";
            this.cboOutcome.Size = new System.Drawing.Size(158, 28);
            this.cboOutcome.TabIndex = 2;
            // 
            // cboStartInterval
            // 
            this.cboStartInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartInterval.FormattingEnabled = true;
            this.cboStartInterval.Location = new System.Drawing.Point(448, 29);
            this.cboStartInterval.Name = "cboStartInterval";
            this.cboStartInterval.Size = new System.Drawing.Size(154, 28);
            this.cboStartInterval.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Protocol:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Outcome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Start Interval:";
            // 
            // cboEndInterval
            // 
            this.cboEndInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndInterval.FormattingEnabled = true;
            this.cboEndInterval.Location = new System.Drawing.Point(657, 29);
            this.cboEndInterval.Name = "cboEndInterval";
            this.cboEndInterval.Size = new System.Drawing.Size(154, 28);
            this.cboEndInterval.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(683, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "End Interval:";
            // 
            // QueryResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1030, 620);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lstFilters);
            this.Controls.Add(this.btnDeleteFilter);
            this.Controls.Add(this.btnAddFilter);
            this.Controls.Add(this.tbControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mnuCommandStrip);
            this.MainMenuStrip = this.mnuCommandStrip;
            this.Name = "QueryResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueryResults";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueryResults_FormClosing);
            this.Load += new System.EventHandler(this.QueryResults_Load);
            this.mnuCommandStrip.ResumeLayout(false);
            this.mnuCommandStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tbControl.ResumeLayout(false);
            this.tpCurrentQuery.ResumeLayout(false);
            this.tpCurrentQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentQuery)).EndInit();
            this.tpCharts.ResumeLayout(false);
            this.tpCharts.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuCommandStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tpCurrentQuery;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnInverse;
        private System.Windows.Forms.Button btnAndOr;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnRemoveQuery;
        private System.Windows.Forms.Button btnAddQuery;
        private System.Windows.Forms.Button btnEditQuery;
        private System.Windows.Forms.DataGridView dgvCurrentQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFilter;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.TabPage tpCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboGraphType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFullView;
        private System.Windows.Forms.TextBox txtGraphCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboEndInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStartInterval;
        private System.Windows.Forms.ComboBox cboOutcome;
        private System.Windows.Forms.ComboBox cboProtocol;
    }
}