using System.Windows.Forms;
using RSS_Reader.Controller;
using RSS_Reader.Model;

namespace RSS_Reader.View
{
    public partial class LoginWindowForTheRegisteredUser : Form
    {
        public delegate void UserInfoReadyHandler(User user);
        public event UserInfoReadyHandler UserInfoReady;

        private readonly RegistrationAndLoginManager _manager = new RegistrationAndLoginManager();

        public LoginWindowForTheRegisteredUser()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            InitializeGui();
        }

        private void InitializeGui() => lbUserName.Items.AddRange(_manager.GetUserNameList()?.ToArray());

        private void HelpToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            if (lbUserName.SelectedIndex != -1)
            {
                UserInfoReady?.Invoke(_manager.LogIn(lbUserName.Items[lbUserName.SelectedIndex].ToString()));
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(@"Выберите имя(псевдоним) в списке", @"Ошибка", MessageBoxButtons.OK);
            }
        }

        private void btAbort_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void lbUserName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            btOK.Enabled = lbUserName.SelectedIndex != -1;
        }
    }
}
