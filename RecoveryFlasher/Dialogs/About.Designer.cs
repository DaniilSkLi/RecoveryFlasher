
namespace RecoveryFlasher
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.btnPDA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnGitHub
            // 
            resources.ApplyResources(this.btnGitHub, "btnGitHub");
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.UseVisualStyleBackColor = true;
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // btnPDA
            // 
            resources.ApplyResources(this.btnPDA, "btnPDA");
            this.btnPDA.Name = "btnPDA";
            this.btnPDA.UseVisualStyleBackColor = true;
            this.btnPDA.Click += new System.EventHandler(this.btnPDA_Click);
            // 
            // About
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPDA);
            this.Controls.Add(this.btnGitHub);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGitHub;
        private System.Windows.Forms.Button btnPDA;
    }
}