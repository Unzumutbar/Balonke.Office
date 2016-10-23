using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unzumutbar.Extensions;

namespace Balonek.Office.Controls
{
    public partial class ControlClient : UserControl
    {
        private List<Client> _clientList;
        private List<Client> _clientSearchList;
        private Client _currentClient;

        private bool _isAdding;
        private string _searchContent;
        private string _message;

        public ControlClient()
        {
            InitializeComponent();
            UpdateClientList();
        }

        private void UpdateClientList(bool useCache = false)
        {
            if (!useCache)
                _clientList = Program.Database.Clients.Get().Where(cli => !cli.Deleted).ToList();

            _clientSearchList = _clientList;
            if (_searchContent.IsNotNullOrWhitespace())
                _clientSearchList = _clientList.Where(c => c.Name.Contains(_searchContent) || c.City.Contains(_searchContent)).ToList();

            this.listBoxClients.Items.Clear();
            foreach (var client in _clientSearchList)
            {
                this.listBoxClients.Items.Add(client.ToString());
            }
        }

        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxClients.SelectedIndex;
            if (index < 0)
                return;

            _currentClient = _clientSearchList[index];
            if (_currentClient == null)
            {
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }

            LoadCurrentClient();
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            _currentClient = new Client();
            _currentClient.Id = Program.Database.Clients.GetNextId();
            _currentClient.Deleted = false;

            LoadCurrentClient();
            EnableEditMode(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            if (_currentClient == null)
                return;
            _isAdding = false;
            EnableEditMode(true);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            if (_currentClient == null)
                return;

            Program.Database.Clients.Delete(_currentClient);
            EnableEditMode(false);

            _currentClient = new Client();
            LoadCurrentClient();
            UpdateClientList();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateCurrentClient();
            if (CanSave)
            {
                if (_isAdding)
                    _currentClient = Program.Database.Clients.Add(_currentClient);
                else
                    Program.Database.Clients.Update(_currentClient);

                this.textBoxId.Text = _currentClient.Id.ToString();
                EnableEditMode(false);
                UpdateClientList();
            }
            else
                MessageBox.Show(_message);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EnableEditMode(false);
        }

        private void LoadCurrentClient()
        {
            textBoxId.Text = _currentClient.Id.ToString();
            textBoxName.Text = _currentClient.Name;
            textBoxStreet.Text = _currentClient.Street;
            textBoxZip.Text = _currentClient.Zip;
            textBoxCity.Text = _currentClient.City;
            textBoxTelephone.Text = _currentClient.Telephone;
            textBoxFax.Text = _currentClient.Fax;
            textBoxEmail.Text = _currentClient.Email;
        }

        private void UpdateCurrentClient()
        {
            if (textBoxId.Enabled && _isAdding)
                _currentClient.Id = int.Parse(textBoxId.Text);

            _currentClient.Name = textBoxName.Text;
            _currentClient.Street = textBoxStreet.Text;
            _currentClient.Zip = textBoxZip.Text;
            _currentClient.City = textBoxCity.Text;
            _currentClient.Telephone = textBoxTelephone.Text;
            _currentClient.Fax = textBoxFax.Text;
            _currentClient.Email = textBoxEmail.Text;
        }

        private void EnableEditMode(bool enabled)
        {
            textBoxId.Enabled = enabled && _isAdding;
            textBoxName.ReadOnly = !enabled;
            textBoxStreet.ReadOnly = !enabled;
            textBoxZip.ReadOnly = !enabled;
            textBoxCity.ReadOnly = !enabled;
            textBoxTelephone.ReadOnly = !enabled;
            textBoxFax.ReadOnly = !enabled;
            textBoxEmail.ReadOnly = !enabled;

            buttonAdd.Enabled = !enabled;
            buttonEdit.Enabled = !enabled;
            buttonDelete.Enabled = !enabled;
            buttonSave.Enabled = enabled;
            buttonCancel.Enabled = enabled;
            listBoxClients.Enabled = !enabled;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _searchContent = textBoxSearch.Text;
            UpdateClientList(true);
        }

        private bool CanSave
        {
            get
            {
                _message = string.Empty;
                var client = _clientList.Where(cli => cli.Id == _currentClient.Id).FirstOrDefault();
                if (client != null)
                    _message += string.Format("KundenNr.{0} existiert bereits für Kunde {1}\n", client.Id, client.Name);
                if (_currentClient.Name.IsNullOrWhitespace())
                    _message += "Es wurde kein Kundenname eingegeben!\n";

                return _message.IsNullOrWhitespace();
            }
        }

        private string currentText;

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxId.Enabled)
                return;

            var textbox = sender as TextBox;
            if (textbox.Text.Length > 0)
            {
                int result;
                bool isNumeric = int.TryParse(textbox.Text, out result);

                if (isNumeric)
                {
                    currentText = textbox.Text;
                }
                else
                {
                    textbox.Text = currentText;
                    textbox.Select(textbox.Text.Length, 0);
                }
            }
            base.OnTextChanged(e);
        }
    }
}
