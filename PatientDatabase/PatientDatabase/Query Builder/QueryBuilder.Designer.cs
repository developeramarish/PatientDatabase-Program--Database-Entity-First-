﻿namespace PatientDatabase
{
    partial class QueryBuilder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSubmitQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.btnRemoveCondition = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.dgvCurrentQuery = new System.Windows.Forms.DataGridView();
            this.cGate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFilter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInverse = new System.Windows.Forms.Button();
            this.btnAndOr = new System.Windows.Forms.Button();
            this.btnEditCondition = new System.Windows.Forms.Button();
            this.mnuCommandStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentQuery)).BeginInit();
            this.mnuCommandStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmitQuery
            // 
            this.btnSubmitQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSubmitQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitQuery.Location = new System.Drawing.Point(397, 532);
            this.btnSubmitQuery.Name = "btnSubmitQuery";
            this.btnSubmitQuery.Size = new System.Drawing.Size(273, 35);
            this.btnSubmitQuery.TabIndex = 3;
            this.btnSubmitQuery.Text = "Submit Query";
            this.btnSubmitQuery.UseVisualStyleBackColor = true;
            this.btnSubmitQuery.Click += new System.EventHandler(this.btnSubmitQuery_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(481, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Query Builder";
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCondition.Location = new System.Drawing.Point(858, 253);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(135, 34);
            this.btnAddCondition.TabIndex = 14;
            this.btnAddCondition.Text = "Add Condition";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // btnRemoveCondition
            // 
            this.btnRemoveCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCondition.Location = new System.Drawing.Point(858, 333);
            this.btnRemoveCondition.Name = "btnRemoveCondition";
            this.btnRemoveCondition.Size = new System.Drawing.Size(135, 34);
            this.btnRemoveCondition.TabIndex = 15;
            this.btnRemoveCondition.Text = "Remove Con.";
            this.btnRemoveCondition.UseVisualStyleBackColor = true;
            this.btnRemoveCondition.Click += new System.EventHandler(this.btnRemoveCondition_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(858, 7);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(135, 35);
            this.btnMoveUp.TabIndex = 18;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(858, 48);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(135, 35);
            this.btnMoveDown.TabIndex = 19;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPaste);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.dgvCurrentQuery);
            this.panel1.Controls.Add(this.btnInverse);
            this.panel1.Controls.Add(this.btnAndOr);
            this.panel1.Controls.Add(this.btnMoveDown);
            this.panel1.Controls.Add(this.btnRemoveCondition);
            this.panel1.Controls.Add(this.btnMoveUp);
            this.panel1.Controls.Add(this.btnAddCondition);
            this.panel1.Controls.Add(this.btnEditCondition);
            this.panel1.Location = new System.Drawing.Point(30, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 377);
            this.panel1.TabIndex = 22;
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaste.Location = new System.Drawing.Point(858, 212);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(135, 35);
            this.btnPaste.TabIndex = 29;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(858, 171);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(135, 35);
            this.btnCopy.TabIndex = 28;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCurrentQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCurrentQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cGate,
            this.cProperty,
            this.cCriteria,
            this.cFilter});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrentQuery.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCurrentQuery.Location = new System.Drawing.Point(3, 3);
            this.dgvCurrentQuery.MultiSelect = false;
            this.dgvCurrentQuery.Name = "dgvCurrentQuery";
            this.dgvCurrentQuery.ReadOnly = true;
            this.dgvCurrentQuery.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCurrentQuery.RowHeadersVisible = false;
            this.dgvCurrentQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentQuery.Size = new System.Drawing.Size(846, 369);
            this.dgvCurrentQuery.TabIndex = 27;
            this.dgvCurrentQuery.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrentQuery_CellDoubleClick);
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
            // btnInverse
            // 
            this.btnInverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInverse.Location = new System.Drawing.Point(858, 89);
            this.btnInverse.Name = "btnInverse";
            this.btnInverse.Size = new System.Drawing.Size(135, 35);
            this.btnInverse.TabIndex = 26;
            this.btnInverse.Text = "Inverse";
            this.btnInverse.UseVisualStyleBackColor = true;
            this.btnInverse.Click += new System.EventHandler(this.btnInverse_Click);
            // 
            // btnAndOr
            // 
            this.btnAndOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAndOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAndOr.Location = new System.Drawing.Point(858, 130);
            this.btnAndOr.Name = "btnAndOr";
            this.btnAndOr.Size = new System.Drawing.Size(135, 35);
            this.btnAndOr.TabIndex = 23;
            this.btnAndOr.Text = "And/Or";
            this.btnAndOr.UseVisualStyleBackColor = true;
            this.btnAndOr.Click += new System.EventHandler(this.btnAndOr_Click);
            // 
            // btnEditCondition
            // 
            this.btnEditCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCondition.Location = new System.Drawing.Point(858, 293);
            this.btnEditCondition.Name = "btnEditCondition";
            this.btnEditCondition.Size = new System.Drawing.Size(135, 34);
            this.btnEditCondition.TabIndex = 22;
            this.btnEditCondition.Text = "Edit Condition";
            this.btnEditCondition.UseVisualStyleBackColor = true;
            this.btnEditCondition.Click += new System.EventHandler(this.btnEditCondition_Click);
            // 
            // mnuCommandStrip
            // 
            this.mnuCommandStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mnuCommandStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuCommandStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuCommandStrip.Name = "mnuCommandStrip";
            this.mnuCommandStrip.Size = new System.Drawing.Size(1066, 24);
            this.mnuCommandStrip.TabIndex = 24;
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
            this.panel2.Location = new System.Drawing.Point(-6, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 30);
            this.panel2.TabIndex = 25;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHome.Location = new System.Drawing.Point(1010, 2);
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
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(500, 495);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(170, 26);
            this.txtName.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(393, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Query Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(397, 573);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(273, 35);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // QueryBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1066, 620);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmitQuery);
            this.Controls.Add(this.mnuCommandStrip);
            this.MainMenuStrip = this.mnuCommandStrip;
            this.Name = "QueryBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueryBuilder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueryBuilder_FormClosing);
            this.Load += new System.EventHandler(this.QueryBuilder_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentQuery)).EndInit();
            this.mnuCommandStrip.ResumeLayout(false);
            this.mnuCommandStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSubmitQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Button btnRemoveCondition;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEditCondition;
        private System.Windows.Forms.Button btnAndOr;
        private System.Windows.Forms.MenuStrip mnuCommandStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button btnInverse;
        private System.Windows.Forms.DataGridView dgvCurrentQuery;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFilter;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
    }
}