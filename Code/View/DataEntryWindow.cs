using System;
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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btAbort_Click(object sender, EventArgs e) => Close();

        private void DataEntryWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Owner is SettingsWindow settingsWindow) settingsWindow.Result = tbResult.Text;
        }
    }
}
