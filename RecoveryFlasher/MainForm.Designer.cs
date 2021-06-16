
namespace RecoveryFlasher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.драйвераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DriverInstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutDriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TWRPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OfficialTWRPStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Xda4PdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecoveryFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenRecovery = new System.Windows.Forms.Button();
            this.lblOpenRecovery = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDoing = new System.Windows.Forms.Label();
            this.pbDoing = new System.Windows.Forms.ProgressBar();
            this.slcLanguage = new System.Windows.Forms.ComboBox();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.драйвераToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.TWRPToolStripMenuItem});
            this.mainMenu.Name = "mainMenu";
            // 
            // драйвераToolStripMenuItem
            // 
            resources.ApplyResources(this.драйвераToolStripMenuItem, "драйвераToolStripMenuItem");
            this.драйвераToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DriverInstallToolStripMenuItem,
            this.AboutDriversToolStripMenuItem});
            this.драйвераToolStripMenuItem.Name = "драйвераToolStripMenuItem";
            // 
            // DriverInstallToolStripMenuItem
            // 
            resources.ApplyResources(this.DriverInstallToolStripMenuItem, "DriverInstallToolStripMenuItem");
            this.DriverInstallToolStripMenuItem.Name = "DriverInstallToolStripMenuItem";
            this.DriverInstallToolStripMenuItem.Click += new System.EventHandler(this.DriverInstallToolStripMenuItem_Click);
            // 
            // AboutDriversToolStripMenuItem
            // 
            resources.ApplyResources(this.AboutDriversToolStripMenuItem, "AboutDriversToolStripMenuItem");
            this.AboutDriversToolStripMenuItem.Name = "AboutDriversToolStripMenuItem";
            this.AboutDriversToolStripMenuItem.Click += new System.EventHandler(this.AboutDriversToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // TWRPToolStripMenuItem
            // 
            resources.ApplyResources(this.TWRPToolStripMenuItem, "TWRPToolStripMenuItem");
            this.TWRPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OfficialTWRPStripMenuItem,
            this.Xda4PdaToolStripMenuItem});
            this.TWRPToolStripMenuItem.Name = "TWRPToolStripMenuItem";
            // 
            // OfficialTWRPStripMenuItem
            // 
            resources.ApplyResources(this.OfficialTWRPStripMenuItem, "OfficialTWRPStripMenuItem");
            this.OfficialTWRPStripMenuItem.Name = "OfficialTWRPStripMenuItem";
            this.OfficialTWRPStripMenuItem.Click += new System.EventHandler(this.OfficialTWRPStripMenuItem_Click);
            // 
            // Xda4PdaToolStripMenuItem
            // 
            resources.ApplyResources(this.Xda4PdaToolStripMenuItem, "Xda4PdaToolStripMenuItem");
            this.Xda4PdaToolStripMenuItem.Name = "Xda4PdaToolStripMenuItem";
            this.Xda4PdaToolStripMenuItem.Click += new System.EventHandler(this.Xda4PdaToolStripMenuItem_Click);
            // 
            // openRecoveryFile
            // 
            this.openRecoveryFile.FileName = "Get recovery file";
            resources.ApplyResources(this.openRecoveryFile, "openRecoveryFile");
            // 
            // btnOpenRecovery
            // 
            resources.ApplyResources(this.btnOpenRecovery, "btnOpenRecovery");
            this.btnOpenRecovery.Name = "btnOpenRecovery";
            this.btnOpenRecovery.UseVisualStyleBackColor = true;
            this.btnOpenRecovery.Click += new System.EventHandler(this.btnOpenRecovery_Click);
            // 
            // lblOpenRecovery
            // 
            resources.ApplyResources(this.lblOpenRecovery, "lblOpenRecovery");
            this.lblOpenRecovery.Name = "lblOpenRecovery";
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDoing
            // 
            resources.ApplyResources(this.lblDoing, "lblDoing");
            this.lblDoing.Name = "lblDoing";
            // 
            // pbDoing
            // 
            resources.ApplyResources(this.pbDoing, "pbDoing");
            this.pbDoing.Name = "pbDoing";
            // 
            // slcLanguage
            // 
            resources.ApplyResources(this.slcLanguage, "slcLanguage");
            this.slcLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.slcLanguage.FormattingEnabled = true;
            this.slcLanguage.Name = "slcLanguage";
            this.slcLanguage.SelectedValueChanged += new System.EventHandler(this.slcLanguage_SelectedValueChanged);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.slcLanguage);
            this.Controls.Add(this.pbDoing);
            this.Controls.Add(this.lblDoing);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblOpenRecovery);
            this.Controls.Add(this.btnOpenRecovery);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem драйвераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DriverInstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutDriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TWRPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OfficialTWRPStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Xda4PdaToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openRecoveryFile;
        private System.Windows.Forms.Button btnOpenRecovery;
        private System.Windows.Forms.Label lblOpenRecovery;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDoing;
        private System.Windows.Forms.ProgressBar pbDoing;
        private System.Windows.Forms.ComboBox slcLanguage;
    }
}

