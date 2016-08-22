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
            this.btnQueryManager = new System.Windows.Forms.Button();
            this.mnuCommandStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPatientSnapShot = new System.Windows.Forms.Button();
            this.txtHexCode = new System.Windows.Forms.TextBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
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
            // btnQueryManager
            // 
            this.btnQueryManager.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueryManager.Location = new System.Drawing.Point(49, 131);
            this.btnQueryManager.Name = "btnQueryManager";
            this.btnQueryManager.Size = new System.Drawing.Size(263, 61);
            this.btnQueryManager.TabIndex = 2;
            this.btnQueryManager.Text = "Query Manager";
            this.btnQueryManager.UseVisualStyleBackColor = true;
            this.btnQueryManager.Click += new System.EventHandler(this.btnQueryManager_Click);
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
            // btnPatientSnapShot
            // 
            this.btnPatientSnapShot.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPatientSnapShot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientSnapShot.Location = new System.Drawing.Point(49, 212);
            this.btnPatientSnapShot.Name = "btnPatientSnapShot";
            this.btnPatientSnapShot.Size = new System.Drawing.Size(263, 61);
            this.btnPatientSnapShot.TabIndex = 4;
            this.btnPatientSnapShot.Text = "Patient Snapshot";
            this.btnPatientSnapShot.UseVisualStyleBackColor = true;
            this.btnPatientSnapShot.Click += new System.EventHandler(this.btnPatientSnapShot_Click);
            // 
            // txtHexCode
            // 
            this.txtHexCode.Location = new System.Drawing.Point(221, 279);
            this.txtHexCode.Name = "txtHexCode";
            this.txtHexCode.Size = new System.Drawing.Size(100, 20);
            this.txtHexCode.TabIndex = 5;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Location = new System.Drawing.Point(118, 277);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(97, 23);
            this.btnChooseImage.TabIndex = 6;
            this.btnChooseImage.Text = "Choose Image";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(360, 329);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.txtHexCode);
            this.Controls.Add(this.btnPatientSnapShot);
            this.Controls.Add(this.btnQueryManager);
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
        private System.Windows.Forms.Button btnQueryManager;
        private System.Windows.Forms.MenuStrip mnuCommandStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button btnPatientSnapShot;
        private System.Windows.Forms.TextBox txtHexCode;
        private System.Windows.Forms.Button btnChooseImage;
    }
}

