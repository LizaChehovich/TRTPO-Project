using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using RSS_Reader.Controller;
using RSS_Reader.Model;

namespace RSS_Reader.View
{
    public partial class SettingsWindow : Form
    {
        public delegate void ProfileReadyHandler(Profile profile);
        public event ProfileReadyHandler ProfileReady;

        private readonly ProfileManager _manager;

        public SettingsWindow(Profile profile)
        {
            InitializeComponent();
            _manager = new ProfileManager(profile);
            DialogResult = DialogResult.Abort;
            UpdateExcludes();
            UpdateIncludes();
            UpdateResources();
        }

        private void ShowMessage(string message)
        {

            MessageBox.Show(message, @"Ошибка", MessageBoxButtons.OK);

        }

        private void UpdateResources()
        {
            lbResourses.Items.Clear();
            lbResourses.Items.AddRange(_manager.Profile.ResourcesList.ToArray());
        }

        private void UpdateIncludes()
        {
            lbInclude.Items.Clear();
            lbInclude.Items.AddRange(_manager.Profile.IncludeFiltersList.ToArray());
        }

        private void UpdateExcludes()
        {
            lbExclude.Items.Clear();
            lbExclude.Items.AddRange(_manager.Profile.ExcludeFiltersList.ToArray());
        }

        private void HelpToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ProfileReady?.Invoke(_manager.Profile);
            Close();
        }

        private void btAbort_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btAddRes_Click(object sender, System.EventArgs e)
        {
            var resource = Interaction.InputBox(@"Введите адрес ресурса");
            if(resource.Trim().Equals(string.Empty))
            {
                ShowMessage(@"Недопустимый адрес");
            }
            else if (_manager.AddResource(resource))
            {
                UpdateResources();
            }
            else
            {
                ShowMessage(@"Такой адрес уже есть");
            }
        }

        private void btRemRes_Click(object sender, System.EventArgs e)
        {
            if (lbResourses.SelectedIndex == 1)
                ShowMessage(@"Выберите ресурс из списка");
            else
            {
                _manager.RemoveResource(_manager.Profile.ResourcesList[lbResourses.SelectedIndex]);
                UpdateResources();
            }
        }

        private void btAddInc_Click(object sender, System.EventArgs e)
        {

            UpdateIncludes();
        }

        private void btRemInc_Click(object sender, System.EventArgs e)
        {
            if (lbInclude.SelectedIndex == 1)
                ShowMessage(@"Выберите фильтр из списка");
            else
            {
                _manager.RemoveIncludeFilter(_manager.Profile.IncludeFiltersList[lbInclude.SelectedIndex]);
                UpdateIncludes();
            }
        }

        private void btAddExc_Click(object sender, System.EventArgs e)
        {

            UpdateExcludes();
        }

        private void btRemExc_Click(object sender, System.EventArgs e)
        {
            if (lbExclude.SelectedIndex == 1)
                ShowMessage(@"Выберите фильтр из списка");
            else
            {
                _manager.RemoveExcludeFilter(_manager.Profile.ExcludeFiltersList[lbExclude.SelectedIndex]);
                UpdateExcludes();
            }
        }
    }
}
