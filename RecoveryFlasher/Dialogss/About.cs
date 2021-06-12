using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RecoveryFlasher
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void btnGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/DaniilSkLi/RecoveryFlasher");
        }

        private void btnPDA_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://4pda.to/forum/index.php?showuser=7402299");
        }
    }
}
