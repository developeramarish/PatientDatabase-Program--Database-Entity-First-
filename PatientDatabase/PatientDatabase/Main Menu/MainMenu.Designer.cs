namespace PatientDatabase
{
    partial class MainMenu
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
            this.btnPatientProfiles = new System.Windows.Forms.Button();
            this.btnQueryBuilder = new System.Windows.Forms.Button();
            this.btnAddToDatabase = new System.Windows.Forms.Button();
            this.mnuCommandStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCommandStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPatientProfiles
            // 
            this.btnPatientProfiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPatientProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientProfiles.Location = new System.Drawing.Point(49, 49);
            this.btnPatientProfiles.Name = "btnPatientProfiles";
            this.btnPatientProfiles.Size = new System.Drawing.Size(263, 61);
            this.btnPatientProfiles.TabIndex = 0;
            this.btnPatientProfiles.Text = "Patient Profiles";
            this.btnPatientProfiles.UseVisualStyleBackColor = true;
            this.btnPatientProfiles.Click += new System.EventHandler(this.btnPatientProfiles_Click);
            // 
            // btnQueryBuilder
            // 
            this.btnQueryBuilder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryBuilder.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueryBuilder.Location = new System.Drawing.Point(49, 149);
            this.btnQueryBuilder.Name = "btnQueryBuilder";
            this.btnQueryBuilder.Size = new System.Drawing.Size(263, 61);
            this.btnQueryBuilder.TabIndex = 1;
            this.btnQueryBuilder.Text = "Query Builder";
            this.btnQueryBuilder.UseVisualStyleBackColor = true;
            this.btnQueryBuilder.Click += new System.EventHandler(this.btnQueryBuilder_Click);
            // 
            // btnAddToDatabase
            // 
            this.btnAddToDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddToDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToDatabase.Location = new System.Drawing.Point(49, 249);
            this.btnAddToDatabase.Name = "btnAddToDatabase";
            this.btnAddToDatabase.Size = new System.Drawing.Size(263, 61);
            this.btnAddToDatabase.TabIndex = 2;
            this.btnAddToDatabase.Text = "Add To Database";
            this.btnAddToDatabase.UseVisualStyleBackColor = true;
            // 
            // mnuCommandStrip
            // 
            this.mnuCommandStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mnuCommandStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuCommandStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuCommandStrip.Name = "mnuCommandStrip";
            this.mnuCommandStrip.Size = new System.Drawing.Size(360, 24);
            this.mnuCommandStrip.TabIndex = 3;
            this.mnuCommandStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(360, 358);
            this.Controls.Add(this.btnAddToDatabase);
            this.Controls.Add(this.btnQueryBuilder);
            this.Controls.Add(this.btnPatientProfiles);
            this.Controls.Add(this.mnuCommandStrip);
            this.MainMenuStrip = this.mnuCommandStrip;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.mnuCommandStrip.ResumeLayout(false);
            this.mnuCommandStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPatientProfiles;
        private System.Windows.Forms.Button btnQueryBuilder;
        private System.Windows.Forms.Button btnAddToDatabase;
        private System.Windows.Forms.MenuStrip mnuCommandStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}

