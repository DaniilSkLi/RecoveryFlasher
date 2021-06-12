
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
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.драйвераToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.TWRPToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // драйвераToolStripMenuItem
            // 
            this.драйвераToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DriverInstallToolStripMenuItem,
            this.AboutDriversToolStripMenuItem});
            this.драйвераToolStripMenuItem.Name = "драйвераToolStripMenuItem";
            this.драйвераToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.драйвераToolStripMenuItem.Text = "Драйвера MI";
            // 
            // DriverInstallToolStripMenuItem
            // 
            this.DriverInstallToolStripMenuItem.Name = "DriverInstallToolStripMenuItem";
            this.DriverInstallToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.DriverInstallToolStripMenuItem.Text = "Установить";
            this.DriverInstallToolStripMenuItem.Click += new System.EventHandler(this.DriverInstallToolStripMenuItem_Click);
            // 
            // AboutDriversToolStripMenuItem
            // 
            this.AboutDriversToolStripMenuItem.Name = "AboutDriversToolStripMenuItem";
            this.AboutDriversToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.AboutDriversToolStripMenuItem.Text = "О драйверах";
            this.AboutDriversToolStripMenuItem.Click += new System.EventHandler(this.AboutDriversToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // TWRPToolStripMenuItem
            // 
            this.TWRPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OfficialTWRPStripMenuItem,
            this.Xda4PdaToolStripMenuItem});
            this.TWRPToolStripMenuItem.Name = "TWRPToolStripMenuItem";
            this.TWRPToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.TWRPToolStripMenuItem.Text = "Найти рекавери";
            // 
            // OfficialTWRPStripMenuItem
            // 
            this.OfficialTWRPStripMenuItem.Name = "OfficialTWRPStripMenuItem";
            this.OfficialTWRPStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.OfficialTWRPStripMenuItem.Text = "На оф. сайте TWRP";
            this.OfficialTWRPStripMenuItem.Click += new System.EventHandler(this.OfficialTWRPStripMenuItem_Click);
            // 
            // Xda4PdaToolStripMenuItem
            // 
            this.Xda4PdaToolStripMenuItem.Name = "Xda4PdaToolStripMenuItem";
            this.Xda4PdaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.Xda4PdaToolStripMenuItem.Text = "На 4PDA/XDA";
            this.Xda4PdaToolStripMenuItem.Click += new System.EventHandler(this.Xda4PdaToolStripMenuItem_Click);
            // 
            // openRecoveryFile
            // 
            this.openRecoveryFile.FileName = "Get recovery file";
            this.openRecoveryFile.Filter = "Recovery|*.img";
            this.openRecoveryFile.Title = "Открыть файл рекавери";
            // 
            // btnOpenRecovery
            // 
            this.btnOpenRecovery.Location = new System.Drawing.Point(12, 27);
            this.btnOpenRecovery.Name = "btnOpenRecovery";
            this.btnOpenRecovery.Size = new System.Drawing.Size(138, 23);
            this.btnOpenRecovery.TabIndex = 1;
            this.btnOpenRecovery.Text = "Выбрать рекавери";
            this.btnOpenRecovery.UseVisualStyleBackColor = true;
            this.btnOpenRecovery.Click += new System.EventHandler(this.btnOpenRecovery_Click);
            // 
            // lblOpenRecovery
            // 
            this.lblOpenRecovery.AutoSize = true;
            this.lblOpenRecovery.Location = new System.Drawing.Point(156, 31);
            this.lblOpenRecovery.Name = "lblOpenRecovery";
            this.lblOpenRecovery.Size = new System.Drawing.Size(245, 15);
            this.lblOpenRecovery.TabIndex = 2;
            this.lblOpenRecovery.Text = "*Рекавери должно иметь расширение .img";
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(12, 56);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(138, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Прошить рекавери";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDoing
            // 
            this.lblDoing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDoing.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDoing.Location = new System.Drawing.Point(12, 96);
            this.lblDoing.Name = "lblDoing";
            this.lblDoing.Size = new System.Drawing.Size(776, 25);
            this.lblDoing.TabIndex = 4;
            this.lblDoing.Text = "Прогресс";
            // 
            // pbDoing
            // 
            this.pbDoing.Location = new System.Drawing.Point(12, 124);
            this.pbDoing.Name = "pbDoing";
            this.pbDoing.Size = new System.Drawing.Size(138, 23);
            this.pbDoing.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbDoing);
            this.Controls.Add(this.lblDoing);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblOpenRecovery);
            this.Controls.Add(this.btnOpenRecovery);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "RecoveryFlasher";
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
    }
}

