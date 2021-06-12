using RecoveryFlasher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoveryFlasher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DeleteTMPFolder();
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

            MessageBox.Show("Драйвера установлены!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("Драйвера подходят только для телеонов Xiaomi (Mi, Redmi, Poco)!\n\nДанные 'драйвера', а точнее их установщик - это программа взятая из официальной программы Xiaomi 'Mi Unlock'. Её можно найти в папке с 'Mi Unlock' под названием 'MiUsbDriver.exe'.\n\nДля их установки, нужно нажать в данной программе кнопку 'Установить', и подключить телефон в режиме 'fastboot'. Если телефон уже был подключён - переподключить.", "О драйверах", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void OfficialTWRPStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://twrp.me/Devices/");
        }

        private void Xda4PdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Рекавери для своего телефона можно найти в разделе вашего телефона на таких форумах как '4PDA.ru' и 'xda-developers.com'.\nЧаще всего рекавери находяться в разделе 'Неофициальные прошивки'.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult msgResult = MessageBox.Show("Рекавери не выбрано.", "Уведомление", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

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
            LabelDoing("Распаковка ADB...");

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
            LabelDoing("Проверка fastboot...");

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
                DialogResult msgResult = MessageBox.Show("Устройство не подключено.\n\nПопробовать снова?\n\nЕсли устройства дальше нет, проверьте драйвера.", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                    LabelDoing($"Устройство(а): {output} Прошивка рекавери через {i} сек.");
                    ProgressDoingAdd();
                    Thread.Sleep(1000);
                }
                Flash();
            }
        }

        private void Flash()
        {
            LabelDoing("Прошивка...");
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
                    LabelDoing("Удачно!");

                    MessageBox.Show("Поздравляю!\nУ вас кастомное рекавери :)\n\nЕсли телефон не перезагрузился в рекавери, попробуйте войти в него сами, на Xiaomi устройствах это делаеться зажатием при вкл. кнопки вкл. и громкость +.\nЕсли всё ещё нет рекавери то возможно ваш телефон нельзя прошить таким способом.\n\nХорошего дня!");
                }
                else
                {
                    LabelDoing("Ошибка :(");
                    MessageBox.Show("Произошла ошибка :(\n\nДетали ошибки: " + output, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                LabelDoing("Ошибка :(");
                MessageBox.Show("Произошла ошибка :(\n\nДетали ошибки: " + output, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RemoveAll();
            End();
        }

        private void RecoveryCopy()
        {
            CreateTMPFolder();

            LabelDoing("Копирование рекавери файла...");
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
            LabelDoing("Удаление временных файлов...");

            string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string path = Path.GetPathRoot(system);

            DeleteTMPFolder();
            if (File.Exists($"{path}\\recovery.img"))
            {
                File.Delete($"{path}\\recovery.img");
            }

            LabelDoing("Файлы удалены.");
        }

        private void End()
        {
            Action action = () => { btnStart.Enabled = true; btnOpenRecovery.Enabled = true; };
            Invoke(action);
        }
    }
}
