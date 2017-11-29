using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using RSS_Reader.Controller;
using RSS_Reader.Model;

namespace RSS_Reader.View
{
    public partial class MainWindow : Form
    {
        private readonly User _user;
        private readonly NewsLoader _loader = new NewsLoader();
        private Thread _loaderThread;
        private bool _updateIsEnable = true;
        private List<News> _newsList;

        private const int UpdateInterval = 900000;

        public MainWindow(User user)
        {
            InitializeComponent();
            _user = user;
            DialogResult = DialogResult.Cancel;
            InitializaGui();
            InitializeLoader();
            InitializeTimer();
        }

        private void InitializaGui()
        {
            LogOutToolStripMenuItem.Visible = _user.Status == Status.Registered;
            SettingsToolStripMenuItem.Visible = _user.Status == Status.Registered;
        }

        private void InitializeLoader()
        {
            _loader.NewsListReady += ShowNews;
            _loader.ExceptionTrown += ShowMessage;
            StartLoading();
        }

        private void InitializeTimer()
        {
            tmUpdate.Interval = UpdateInterval;
            tmUpdate.Tick += StartLoading;
            tmUpdate.Start();
        }

        private void StartLoading(object sender, EventArgs e)
        {
            if (!_updateIsEnable) return;
            StartLoading();
        }

        private void StartLoading()
        {
            _updateIsEnable = false;
            _loaderThread = new Thread(_loader.LoadNewses);
            _loader.UpdateUserProfile(_user.Profile);
            _loaderThread.Start();
        }

        private void ShowNews(List<News> newsList)
        {
            if (!InvokeRequired)
            {
                _newsList = newsList;
                ClearInformation();
                foreach (var news in _newsList)
                {
                    dgvNews.Rows.Add(news.Category, news.Title, news.Description, news.PublicationDate, news.Link);
                }
                _updateIsEnable = true;
                _loaderThread?.Abort();
            }
            else
            {
                Invoke(new Action<List<News>>(ShowNews), newsList);
            }
        }

        private void ClearInformation()
        {
            dgvNews.Rows.Clear();
            tbTitle.Clear();
            tbDescription.Clear();
            tbPubDate.Clear();
        }

        private void ShowMessage(string message)
        {
            if (!InvokeRequired)
            {
                if (DialogResult.OK == MessageBox.Show(message, @"Ошибка", MessageBoxButtons.OKCancel))
                {
                    _loaderThread.Abort();
                    StartLoading();
                }
                else
                {
                    Close();
                }
            }
            else
            {
               Invoke(new Action<string>(ShowMessage), message);
            }
        }

        private void UpdateUserProfile(Profile profile)
        {
            _user.Profile = profile;
            new FileManager().SaveUserProfile(_user);
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _updateIsEnable = false;
            var settingsWindow = new SettingsWindow(_user.Profile);
            settingsWindow.ProfileReady += UpdateUserProfile;
            if (settingsWindow.ShowDialog() == DialogResult.OK)
            {
                StartLoading();
            }
            _updateIsEnable = true;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvNews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var news = GetSelectedNews(e.RowIndex);
            tbTitle.Text = news?.Title;
            tbDescription.Text = news?.Description;
            tbPubDate.Text = news?.PublicationDate;
        }

        private void dgvNews_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var news = GetSelectedNews(e.RowIndex);
            if (news != null) Process.Start(news.Link);
        }

        private News GetSelectedNews(int rowIndex)
        {
            if (!_updateIsEnable || rowIndex < 0) return null;
            var selectedNews = dgvNews.Rows[rowIndex];
            return _newsList.FirstOrDefault(n =>
                n.Category.Equals(selectedNews.Cells[0].Value) && n.Description.Equals(selectedNews.Cells[2].Value));
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loaderThread.Abort();
        }
    }
}