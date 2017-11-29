using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSS_Reader.View
{
    public partial class DataEntryWindow : Form
    {
        public DataEntryWindow()
        {
            InitializeComponent();
            DialogResult = DialogResult.Abort;
        }

        private void tbResult_TextChanged(object sender, EventArgs e) => btOK.Enabled = tbResult.Text.Length > 0;

        private void btOK_Click(object sender, EventArgs e)
        {
            if (Owner is SettingsWindow settingsWindow) settingsWindow.Result = tbResult.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btAbort_Click(object sender, EventArgs e) => Close();
    }
}
