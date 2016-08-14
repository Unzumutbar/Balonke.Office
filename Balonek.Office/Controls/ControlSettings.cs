using Balonek.Office.Objects;
using Balonek.Office.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Balonek.Office.Controls
{
    public partial class ControlSettings : UserControl
    {
        private Settings _settings;

        public ControlSettings()
        {
            try
            {
                InitializeComponent();
                LoadSettings();
            }
            catch (Exception ex)
            {
                Program.Logger.LogError(ex);
                MessageBox.Show(StaticStrings.ErrorMessage(ex));
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EnableEditMode(true);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                EnableEditMode(false);
                Program.Database.UpdateSettings(_settings);
            }
            catch (Exception ex)
            {
                Program.Logger.LogError(ex);
                MessageBox.Show(StaticStrings.ErrorMessage(ex));
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EnableEditMode(false);
            ReadSettingFromDatabase();
        }

        private void LoadSettings()
        {
            ReadSettingFromDatabase();
            textBoxDatabaseVersion.Text = _settings.DataBaseVersion.ToString();
            textBoxTemplateBills.Text = _settings.TemplateBillPath;
        }

        private void ReadSettingFromDatabase()
        {
            _settings = new Settings();
            _settings.DataBaseVersion = Program.Database.GetDatabaseVersion();
            _settings.TemplateBillPath = Program.Database.GetBillTemplate();
        }

        private void EnableEditMode(bool enabled)
        {
            textBoxTemplateBills.ReadOnly = !enabled;
            buttonFindTemplate.Enabled = enabled;

            buttonEdit.Enabled = !enabled;
            buttonSave.Enabled = enabled;
            buttonCancel.Enabled = enabled;
        }

        private void buttonFindTemplate_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Open Document Text(*.odt)|*.odt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            var result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                _settings.TemplateBillPath = openFileDialog.FileName;
                this.textBoxTemplateBills.Text = openFileDialog.FileName;
            }
        }
    }
}
