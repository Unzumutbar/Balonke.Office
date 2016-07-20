using Balonek.Office.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Balonek.Office.Controls
{
    public partial class ControlBillPositionAuto : UserControl
    {
        private List<BillPosition> _positionList;
        private List<BillPosition> _positionSearchList;
        private List<Client> _clientList;
        private List<BillPositionText> _positionTextList;
        private BillPosition _currentPosition;
        private Client _currentClient;
        private bool _isAdding;
        private string _searchContent;
        private string _message;

        public ControlBillPositionAuto()
        {
            InitializeComponent();
            UpdatePositionList();
            UpdateClientList();
            UpdatePositionTextList();
        }

        private void UpdatePositionTextList(bool useCache = false)
        {
            if (!useCache)
                _positionTextList = Program.Database.GetBillPositionTextList();

            this.comboBoxDescription.Items.Clear();
            if (_currentPosition != null)
                this.comboBoxDescription.Items.Add(_currentPosition.Description);
            else
                this.comboBoxDescription.Items.Add(string.Empty);

            foreach (var posText in _positionTextList)
            {
                this.comboBoxDescription.Items.Add(posText.Text);
            }
        }

        private void UpdatePositionList(bool useCache = false)
        {
            if(!useCache)
                _positionList = Program.Database.GetBillPositionList();

            _positionSearchList = _positionList.OrderByDescending(p => p.Date).ToList();
            if (!String.IsNullOrWhiteSpace(_searchContent))
                _positionSearchList = _positionList.Where(p => p.Client.Name.Contains(_searchContent) || p.Description.Contains(_searchContent)).ToList();

            this.listBoxPositions.Items.Clear();
            foreach (var client in _positionSearchList)
            {
                this.listBoxPositions.Items.Add(client.ToString());
            }
        }

        private void UpdateClientList()
        {
            _clientList = Program.Database.GetClientList();
            this.comboBoxClient.Items.Clear();
            foreach (var client in _clientList)
            {
                this.comboBoxClient.Items.Add(client.ToString());
            }
        }

        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxPositions.SelectedIndex;
            if (index < 0)
                return;

            _currentPosition = _positionSearchList[index];
            if (_currentPosition == null)
            {
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }

            LoadCurrentPosition();
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxClient.SelectedIndex;
            if (index < 0)
                return;

            _currentClient = _clientList[index];
            if (_currentClient == null)
                return;

            textBoxClientName.Text = _currentClient.Name;
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            _currentPosition = new BillPosition();
            if (_positionList.Any())
                _currentPosition.Id = _positionList.Max(c => c.Id) + 1;
            else
                _currentPosition.Id = 1;

            LoadCurrentPosition();
            EnableEditMode(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            if (_currentPosition == null)
                return;
            _isAdding = false;
            EnableEditMode(true);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            if (_currentPosition == null)
                return;

            Program.Database.DeleteBillPosition(_currentPosition);
            EnableEditMode(false);

            _currentPosition = new BillPosition();
            LoadCurrentPosition();
            UpdatePositionList();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateCurrentClient();
            if (CanSave)
            {
                if (_isAdding)
                    Program.Database.AddBillPosition(_currentPosition);
                else
                    Program.Database.UpdateBillPosition(_currentPosition);

                EnableEditMode(false);
                UpdatePositionList();
            }
            else
                MessageBox.Show(_message);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EnableEditMode(false);
        }

        private void LoadCurrentPosition()
        {
            textBoxId.Text = _currentPosition.Id.ToString();
            textBoxClientName.Text = _currentPosition.Client.Name;
            comboBoxDescription.Text = _currentPosition.Description;
            if (_currentPosition.Date == null || _currentPosition.Date <= DateTime.MinValue)
                _currentPosition.Date = DateTime.Today;

            dateTimePickerDate.Value = _currentPosition.Date;
            textBoxTime.Text = _currentPosition.Time.ToString();
            textBoxRate.Text = _currentPosition.Rate.ToString();
            textBoxTotal.Text = _currentPosition.Total.ToString();
        }

        private void UpdateCurrentClient()
        {
            //_currentPosition.ClientId = textBoxName.Text;
            //_currentPosition.ClientName = textBoxClientName.Text;
            _currentPosition.Description = comboBoxDescription.Text;
            _currentPosition.Date = dateTimePickerDate.Value;
            _currentPosition.Time = Decimal.Parse(textBoxTime.Text);
            _currentPosition.Rate = Decimal.Parse(textBoxRate.Text);
        }

        private void EnableEditMode(bool enabled)
        {
            //textBoxClientName.ReadOnly = !enabled;
            //textBoxDescription.ReadOnly = !enabled;
            textBoxTime.ReadOnly = !enabled;
            textBoxRate.ReadOnly = !enabled;

            buttonAdd.Enabled = !enabled;
            buttonEdit.Enabled = !enabled;
            buttonDelete.Enabled = !enabled;
            buttonSave.Enabled = enabled;
            buttonCancel.Enabled = enabled;
            dateTimePickerDate.Enabled = enabled;
            comboBoxClient.Enabled = enabled;
            listBoxPositions.Enabled = !enabled;
            comboBoxDescription.Enabled = enabled;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _searchContent = textBoxSearch.Text;
            UpdatePositionList(true);
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            var textbox = sender as TextBox;
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back
                & e.KeyChar != ',')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private string currentText;

        private void OnTextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox.Text.Length > 0)
            {
                float result;
                bool isNumeric = float.TryParse(textbox.Text, out result);

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

        private void decimalTextBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(sender, e);
            CalculateSum();
        }

        private void CalculateSum()
        {
            if (String.IsNullOrEmpty(textBoxTime.Text) || String.IsNullOrEmpty(textBoxRate.Text))
                return;

            var timeAsDecimal = Decimal.Parse(textBoxTime.Text);
            var rateAdDecimal = Decimal.Parse(textBoxRate.Text);
            var total = timeAsDecimal * rateAdDecimal;
            textBoxTotal.Text = total.ToString();
        }

        private bool CanSave
        {
            get
            {
                _message = string.Empty;
                if (_currentPosition.Client.Id == 0)
                    _message += "Es wurde kein Kunde ausgewählt!";
                if (String.IsNullOrWhiteSpace(comboBoxDescription.Text))
                    _message += "Es wurde keine Tatigkeitsbeschreibung eingegeben!";
                if (String.IsNullOrWhiteSpace(textBoxTime.Text))
                    _message += "Es wurde keine Zeit eingegeben!";
                if (String.IsNullOrWhiteSpace(textBoxRate.Text))
                    _message += "Es wurde kein Stundensatz eingegeben!";

                return String.IsNullOrEmpty(_message);
            }
        }
    }
}
