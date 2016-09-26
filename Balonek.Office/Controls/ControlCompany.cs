using Balonek.Database.Entities;
using Balonek.Office.Forms;
using Balonek.Office.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Balonek.Office.Controls
{
    public partial class ControlCompany : UserControl
    {
        private Company _company;
        private ShowWildCardsForm ShowWildCardsForm;

        public ControlCompany()
        {
            try
            {
                InitializeComponent();
                ReadSettingFromDatabase();
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
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
                UpdateCurrentCompany();
                Program.Database.Company.Update(_company);
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
        }

        private void UpdateCurrentCompany()
        {
            _company.CompanyName = textBoxCompany.Text;
            _company.Name = textBoxName.Text;
            _company.Street = textBoxStreet.Text;
            _company.Zip = textBoxZip.Text;
            _company.City = textBoxCity.Text;
            _company.Telephone = textBoxTelephone.Text;
            _company.Fax = textBoxFax.Text;
            _company.Email = textBoxEmail.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EnableEditMode(false);
            ReadSettingFromDatabase();
        }

        private void ReadSettingFromDatabase()
        {
            _company = Program.Database.Company.Get();
            textBoxCompany.Text = _company.CompanyName;
            textBoxName.Text = _company.Name;
            textBoxStreet.Text = _company.Street;
            textBoxZip.Text = _company.Zip;
            textBoxCity.Text = _company.City;
            textBoxTelephone.Text = _company.Telephone;
            textBoxFax.Text = _company.Fax;
            textBoxEmail.Text = _company.Email;

            textBoxDatabaseVersion.Text = _company.DataBaseVersion.ToString();
            textBoxTemplateBills.Text = _company.TemplateBillPath;
        }

        private void EnableEditMode(bool enabled)
        {
            textBoxCompany.ReadOnly = !enabled;
            textBoxName.ReadOnly = !enabled;
            textBoxStreet.ReadOnly = !enabled;
            textBoxZip.ReadOnly = !enabled;
            textBoxCity.ReadOnly = !enabled;
            textBoxTelephone.ReadOnly = !enabled;
            textBoxFax.ReadOnly = !enabled;
            textBoxEmail.ReadOnly = !enabled;
            textBoxTemplateBills.ReadOnly = !enabled;
            buttonFindTemplate.Enabled = enabled;

            buttonEdit.Enabled = !enabled;
            buttonSave.Enabled = enabled;
            buttonCancel.Enabled = enabled;
            buttonExport.Enabled = !enabled;
        }

        private void buttonFindTemplate_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Open Document Text(*.odt)|*.odt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _company.TemplateBillPath = openFileDialog.FileName;
                this.textBoxTemplateBills.Text = openFileDialog.FileName;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (ShowWildCardsForm == null || (ShowWildCardsForm.IsDisposed))
            {
                var parent = this.ParentForm;
                ShowWildCardsForm = new ShowWildCardsForm() { Owner = parent, Location = new Point(parent.Location.X + parent.Width, parent.Location.Y) };
            }
            ShowWildCardsForm.SetParentControl(this);
            ShowWildCardsForm.CreateWildCards(_company);
            ShowWildCardsForm.Show();
        }
    }
}
