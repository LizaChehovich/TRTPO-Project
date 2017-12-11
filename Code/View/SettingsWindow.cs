using System;
using System.Linq;
using System.Windows.Forms;
using RSS_Reader.Model;

namespace RSS_Reader.View
{
    public partial class SettingsWindow : Form
    {
        public delegate void ProfileReadyHandler(Profile profile);
        public event ProfileReadyHandler ProfileReady;

        private readonly Profile _profile = new Profile();

        public string Result { get; set; }

        public SettingsWindow(Profile profile)
        {
            InitializeComponent();
            _profile.AddResources(profile.ResourcesList);
            _profile.AddIncludeFilters(profile.IncludeFiltersList);
            _profile.AddExcludeFilters(profile.ExcludeFiltersList);
            DialogResult = DialogResult.Abort;
            UpdateExcludes();
            UpdateIncludes();
            UpdateResources();
        }

        private void ShowMessage(string message) => MessageBox.Show(message, @"Ошибка", MessageBoxButtons.OK);

        private void UpdateResources()
        {
            lbResourses.Items.Clear();
            lbResourses.Items.AddRange(_profile.ResourcesList.ToArray());
        }

        private void UpdateIncludes()
        {
            lbInclude.Items.Clear();
            lbInclude.Items.AddRange(_profile.IncludeFiltersList.ToArray());
        }

        private void UpdateExcludes()
        {
            lbExclude.Items.Clear();
            lbExclude.Items.AddRange(_profile.ExcludeFiltersList.ToArray());
        }

        private void HelpToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ProfileReady?.Invoke(_profile);
            Close();
        }

        private void btAbort_Click(object sender, System.EventArgs e) => Close();

        private void btAddRes_Click(object sender, System.EventArgs e)
        {
            var dataEntryWindow = new DataEntryWindow {Owner = this};
            if(dataEntryWindow.ShowDialog()==DialogResult.Abort) return;
            if (!Uri.IsWellFormedUriString(Result, UriKind.Absolute))
            {
                ShowMessage(@"Данная строка не является интернет-ресурсом");
                return;
            }
            if (!_profile.AddResource(Result))
            {
                ShowMessage(@"Такой ресурс уже есть");
            }
            else
            {
                UpdateResources();
            }
        }

        private void btRemRes_Click(object sender, System.EventArgs e)
        {
            if (lbResourses.SelectedIndex == -1)
            {
                ShowMessage(@"Выберите ресурс из списка");
            }
            else
            {
                _profile.RemoveResourse(_profile.ResourcesList.ElementAt(lbResourses.SelectedIndex));
                UpdateResources();
            }
        }

        private void btAddInc_Click(object sender, System.EventArgs e)
        {
            var dataEntryWindow = new DataEntryWindow { Owner = this };
            if (dataEntryWindow.ShowDialog() == DialogResult.Abort) return;
            if (!_profile.AddIncludeFilter(Result))
            {
                ShowMessage(@"Такой фильтр уже есть");
            }
            else
            {
                UpdateIncludes();
            }
        }

        private void btRemInc_Click(object sender, System.EventArgs e)
        {
            if (lbInclude.SelectedIndex == -1)
            {
                ShowMessage(@"Выберите фильтр из списка");
            }
            else
            {
                _profile.RemoveIncludeFilter(_profile.IncludeFiltersList.ElementAt(lbInclude.SelectedIndex));
                UpdateIncludes();
            }
        }

        private void btAddExc_Click(object sender, System.EventArgs e)
        {
            var dataEntryWindow = new DataEntryWindow { Owner = this };
            if (dataEntryWindow.ShowDialog() == DialogResult.Abort) return;
            if (!_profile.AddExcludeFilter(Result))
            {
                ShowMessage(@"Такой фильтр уже есть");
            }
            else
            {
                UpdateExcludes();
            }
        }

        private void btRemExc_Click(object sender, System.EventArgs e)
        {
            if (lbExclude.SelectedIndex == -1)
            {
                ShowMessage(@"Выберите фильтр из списка");
            }
            else
            {
                _profile.RemoveExcludeFilter(_profile.ExcludeFiltersList.ElementAt(lbExclude.SelectedIndex));
                UpdateExcludes();
            }
        }
    }
}
