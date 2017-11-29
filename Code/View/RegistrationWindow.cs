using System;
using System.Windows.Forms;
using RSS_Reader.Controller;
using RSS_Reader.Model;

namespace RSS_Reader.View
{
    public partial class RegistrationWindow : Form
    {
        public delegate void UserInfoReadyHandler(User user);
        public event UserInfoReadyHandler UserInfoReady;

        private readonly RegistrationAndLoginManager _manager = new RegistrationAndLoginManager();

        public RegistrationWindow()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void HelpToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfoReady?.Invoke(_manager.RegisterUser(tbUserName.Text));
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException)
            {
                MessageBox.Show(@"Такой пользователь уже существует. Введите псевдоним", @"Ошибка",
                    MessageBoxButtons.OK);
                label.Text = @"Введите свой псевдоним";
            }
        }

        private void btAbort_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void tbUserName_TextChanged(object sender, EventArgs e) => btOK.Enabled = tbUserName.Text.Length != 0;
    }
}
