using RecoveryFlasher.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;
using System.Drawing;

namespace RecoveryFlasher
{
    public partial class MainForm : Form
    {
        ComponentResourceManager res = new ComponentResourceManager(typeof(MainForm));
        Size DefaultFormSize;

        public MainForm()
        {
            InitializeComponent();
            DeleteTMPFolder();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DefaultFormSize = new Size(this.Size.Width, this.Size.Height);

            slcLanguage.DataSource = new CultureInfo[] {
                CultureInfo.GetCultureInfo("ru-RU"),
                CultureInfo.GetCultureInfo("en-001")
            };

            slcLanguage.DisplayMember = "EnglishName";
            slcLanguage.ValueMember = "Name";
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void DriverInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTMPFolder();
            File.WriteAllBytes("Temp/drivers.exe", Resources.MiUsbDriver);

            Process drv = Process.Start("Temp/drivers.exe");
            drv.WaitForExit();

            DeleteTMPFolder();

            MessageBox.Show(Localization.MessageBox.Content.DriverInstallSuccessful, Localization.MessageBox.Titles.Notification, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateTMPFolder()
        {
            if (!Directory.Exists("Temp"))
            {
                Directory.CreateDirectory("Temp");
            }
        }

        private void DeleteTMPFolder()
        {
            if (Directory.Exists("Temp"))
            {
                Directory.Delete("Temp", true);
            }
        }

        private void AboutDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Localization.MessageBox.Content.AboutDrivers, Localization.MessageBox.Titles.AboutDrivers, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void OfficialTWRPStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://twrp.me/Devices/");
        }

        private void Xda4PdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Localization.MessageBox.Content.FindRecovery, Localization.MessageBox.Titles.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpenRecovery_Click(object sender, EventArgs e)
        {
            DialogResult result = openRecoveryFile.ShowDialog();

            if ((result == DialogResult.OK) && openRecoveryFile.FileName != "")
            {
                btnStart.Enabled = true;

                lblOpenRecovery.Text = openRecoveryFile.FileName;
            }
            else
            {
                btnStart.Enabled = false;
                DialogResult msgResult = MessageBox.Show(Localization.MessageBox.Content.RecoveryNotSelect, Localization.MessageBox.Titles.Notification, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                if (msgResult == DialogResult.Retry)
                {
                    btnOpenRecovery_Click(sender, e);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnOpenRecovery.Enabled = false;
            slcLanguage.Enabled = false;

            Thread th = new Thread(Start);
            th.Start();
        }

        private void Start()
        {
            RecoveryCopy();
            ADBExtract();
            TestFastbootMode();
        }

        private void ADBExtract()
        {
            LabelDoing(Localization.LabelDoing.unzipADB);

            CreateTMPFolder();

            File.WriteAllBytes("Temp/adb.zip", Resources.ADB);

            ZipArchive archive = ZipFile.OpenRead("Temp/adb.zip");

            int totalFiles = 0;
            foreach(ZipArchiveEntry zipEntry in archive.Entries)
            {
                totalFiles++;
            }

            ProgressDoingClear(totalFiles);

            foreach (ZipArchiveEntry zipEntry in archive.Entries)
            {
                if (zipEntry.Name != "")
                {
                    string filePath = "Temp/adb/" + zipEntry.FullName;
                    if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    }
                    zipEntry.ExtractToFile(filePath, true);
                }

                ProgressDoingAdd();
            }

            archive.Dispose();
        }

        private void TestFastbootMode()
        {
            LabelDoing(Localization.LabelDoing.checkFastboot);

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C \"" + Directory.GetCurrentDirectory() + "\\Temp\\adb\\fastboot.exe\" devices";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();

            string output;

            output = process.StandardOutput.ReadToEnd();

            if (output == "")
            {
                DialogResult msgResult = MessageBox.Show(Localization.MessageBox.Content.DeviceNotFound, Localization.MessageBox.Titles.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgResult == DialogResult.Yes)
                {
                    TestFastbootMode();
                }
                else
                {
                    RemoveAll();
                    End();
                }
            }
            else
            {
                output = output.Replace("fastboot", "");
                output = output.Replace("\t", "");
                output = output.Replace("\r", "");
                output = output.Replace("\n", "");

                ProgressDoingClear(4);
                for (int i = 3; i >= 0; i--)
                {
                    LabelDoing(string.Format(Localization.LabelDoing.WaitBeforeFlashing, output, i));
                    ProgressDoingAdd();
                    Thread.Sleep(1000);
                }
                Flash();
            }
        }

        private void Flash()
        {
            LabelDoing(Localization.LabelDoing.Flashing);
            ProgressDoingClear(2);

            string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string path = Path.GetPathRoot(system);

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C \"" + Directory.GetCurrentDirectory() + "\\Temp\\adb\\fastboot.exe\" flash recovery " + path + "\\recovery.img";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();

            string output;

            output = process.StandardOutput.ReadToEnd();

            if (output == "")
            {
                ProgressDoingAdd();

                process.StartInfo.Arguments = "/C \"" + Directory.GetCurrentDirectory() + "\\Temp\\adb\\fastboot.exe\" boot " + path + "\\recovery.img";
                process.Start();
                process.WaitForExit();

                output = process.StandardOutput.ReadToEnd();

                if (output == "")
                {
                    ProgressDoingAdd();
                    LabelDoing(Localization.LabelDoing.Successful);

                    MessageBox.Show(Localization.MessageBox.Content.Congratulations);
                }
                else
                {
                    LabelDoing(Localization.LabelDoing.Error);
                    MessageBox.Show(Localization.MessageBox.Content.FlashError + output, Localization.MessageBox.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                LabelDoing(Localization.LabelDoing.Error);
                MessageBox.Show(Localization.MessageBox.Content.FlashError + output, Localization.MessageBox.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RemoveAll();
            End();
        }

        private void RecoveryCopy()
        {
            CreateTMPFolder();

            LabelDoing(Localization.LabelDoing.CopyRecoveryFile);
            ProgressDoingClear(0);

            string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string path = Path.GetPathRoot(system);
            File.Copy(openRecoveryFile.FileName, $"{path}\\recovery.img", true);
        }

        private void LabelDoing(string txt)
        {
            Action action = () => { lblDoing.Text = txt; };
            Invoke(action);
        }

        private void ProgressDoingAdd()
        {
            Action action = () => { pbDoing.Value++; };
            Invoke(action);
        }

        private void ProgressDoingClear(int max)
        {
            Action action = () => { pbDoing.Minimum = 0; pbDoing.Maximum = max; pbDoing.Value = 0; };
            Invoke(action);
        }

        private void RemoveAll()
        {
            LabelDoing(Localization.LabelDoing.DeleteTMPFiles);

            string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string path = Path.GetPathRoot(system);

            DeleteTMPFolder();
            if (File.Exists($"{path}\\recovery.img"))
            {
                File.Delete($"{path}\\recovery.img");
            }

            LabelDoing(Localization.LabelDoing.TMPFilesDeleted);
        }

        private void End()
        {
            Action action = () => { btnStart.Enabled = true; btnOpenRecovery.Enabled = true; slcLanguage.Enabled = true; };
            Invoke(action);
        }

        private void LanguageSet(string language)
        {
            this.SuspendLayout();

            FormWindowState state = FormWindowState.Normal;
            Size size = this.Size;

            if (this.WindowState == FormWindowState.Maximized)
                state = FormWindowState.Maximized;

            this.WindowState = FormWindowState.Normal;
            this.Size = DefaultFormSize;

            CultureInfo culture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (Control component in this.Controls)
            {
                if (component.GetType().Equals(typeof(MenuStrip)))
                {
                    MenuStrip menu = (MenuStrip)component;
                    foreach (ToolStripItem menu_item in menu.Items)
                    {
                        if (menu_item is ToolStripDropDownItem)
                        {
                            foreach (ToolStripItem dropDownItem in ((ToolStripDropDownItem)menu_item).DropDownItems)
                            {
                                res.ApplyResources(dropDownItem, dropDownItem.Name, culture);
                            }
                        }
                        res.ApplyResources(menu_item, menu_item.Name, culture);
                    }
                }
                res.ApplyResources(component, component.Name, culture);
            }

            this.WindowState = state;
            this.Size = size;

            this.ResumeLayout();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveAll();
        }

        private void slcLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LanguageSet(slcLanguage.SelectedItem.ToString());
            }
            catch
            {
                
            }
        }
    }
}
