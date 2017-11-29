using System.Windows.Forms;
using RSS_Reader.Controller;
using RSS_Reader.Model;

namespace RSS_Reader.View
{
    public partial class LoginWindow : Form
    {
        private User _user;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SetUser(User user) => _user = user;

        private void HelpToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void btLogIn_Click(object sender, System.EventArgs e)
        {
            var window = new LoginWindowForTheRegisteredUser();
            window.UserInfoReady += SetUser;
            Hide();
            HandleDialogResult(window.ShowDialog());
        }

        private void btRegister_Click(object sender, System.EventArgs e)
        {
            var window = new RegistrationWindow();
            window.UserInfoReady += SetUser;
            Hide();
            HandleDialogResult(window.ShowDialog());
        }

        private void btSkip_Click(object sender, System.EventArgs e)
        {
            _user = new RegistrationAndLoginManager().GetAnonymUser();
            Hide();
            ShowMainWindow();
        }

        private void ShowMainWindow()
        {
            Hide();
            HandleDialogResult(new MainWindow(_user).ShowDialog());
        }

        private void HandleDialogResult(DialogResult dialogResult)
        {
            switch (dialogResult)
            {
                case DialogResult.OK:
                    ShowMainWindow();
                    break;
                case DialogResult.Cancel:
                    Close();
                    break;
                default:
                    Show();
                    break;
            }
        }
    }
}
