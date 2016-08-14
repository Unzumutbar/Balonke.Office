using Balonek.Office.Forms;
using Balonek.Office.Objects;
using Balonek.Office.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Balonek.Office.Utils.Enums;

namespace Balonek.Office.Controls
{
    public partial class ControlBillPosition : UserControl
    {
        private List<BillPosition> _positionList;
        private List<BillPosition> _singlePositionList;
        private List<BillPosition> _periodicalPositionList;
        private List<Client> _clientList;
        private List<BillPositionText> _positionTextList;
        private BillPosition _currentPosition;

        private AutoPositionsForm AutoPositionsForm;

        private bool _isAdding;
        private string _searchContent;
        private string _message;

        public ControlBillPosition()
        {
            try
            {
                InitializeComponent();
                UpdatePositionList();
                UpdateClientList();
                UpdatePositionTextList();
                UpdatePositionType();
                UpdatePeriodType();
            }
            catch (Exception ex)
            {
                Program.Logger.LogError(ex);
                MessageBox.Show(StaticStrings.ErrorMessage(ex));
            }
}

        private void UpdatePeriodType()
        {
            var enumList = new List<string>();
            foreach (Period value in Enum.GetValues(typeof(Period)))
                comboBoxPeriod.Items.Add(value.GetDescription());

            comboBoxPeriod.SelectedItem = Period.Weekly.GetDescription();
        }

        private void UpdatePositionType()
        {
            var enumList = new List<string>();
            foreach (PositionType value in Enum.GetValues(typeof(PositionType)))
                comboBoxPositionType.Items.Add(value.GetDescription());

            comboBoxPositionType.SelectedItem = PositionType.Single.GetDescription();
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

        public void UpdatePositionList(bool useCache = false)
        {
            if(!useCache)
                _positionList = Program.Database.GetBillPositionList();

            UpdateSinglePositionList();
            UpdatePeriodicalPositionList();
        }

        private void UpdatePeriodicalPositionList()
        {
            _periodicalPositionList = _positionList.Where(p => p.Type == PositionType.Periodical).OrderByDescending(p => p.Date).ToList();
            if (!String.IsNullOrWhiteSpace(_searchContent))
                _periodicalPositionList = _positionList.Where(p => p.Client.Name.Contains(_searchContent) || p.Description.Contains(_searchContent)).ToList();

            this.listBoxRepeatition.Items.Clear();
            foreach (var position in _periodicalPositionList)
            {
                this.listBoxRepeatition.Items.Add(position.ToString());
            }
        }

        private void UpdateSinglePositionList()
        {
            _singlePositionList = _positionList.Where(p => p.Type == PositionType.Single).OrderByDescending(p => p.Date).ToList();
            if (!String.IsNullOrWhiteSpace(_searchContent))
                _singlePositionList = _positionList.Where(p => p.Client.Name.Contains(_searchContent) || p.Description.Contains(_searchContent)).ToList();

            this.listBoxPositions.Items.Clear();
            foreach (var position in _singlePositionList)
            {
                this.listBoxPositions.Items.Add(position.ToString());
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

        private void listBoxSingle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = _singlePositionList;
            PositionIsSelected(sender as ListBox, _singlePositionList);
        }

        private void listBoxPeriodical_SelectedIndexChanged(object sender, EventArgs e)
        {
            PositionIsSelected(sender as ListBox, _periodicalPositionList);
        }

        private void PositionIsSelected(ListBox listbox, List<BillPosition>list)
        {
            int index = listbox.SelectedIndex;
            if (index < 0)
                return;

            _currentPosition = list[index];
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

            var client = _clientList[index];
            if (client == null)
                return;

            _currentPosition.Client = client;
            textBoxClientName.Text = client.Name;
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _isAdding = true;
                _currentPosition = new BillPosition();
                if (_positionList.Any())
                    _currentPosition.Id = _positionList.Max(c => c.Id) + 1;
                else
                    _currentPosition.Id = 1;

                LoadCurrentPosition();
                EnableEditMode(true);
                comboBoxPositionType.Focus();
                comboBoxPositionType.SelectedItem = PositionType.Single.GetDescription();
            }
            catch (Exception ex)
            {
                Program.Logger.LogError(ex);
                MessageBox.Show(StaticStrings.ErrorMessage(ex));
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                _isAdding = false;
                if (_currentPosition == null)
                    return;
                _isAdding = false;
                EnableEditMode(true);
            }
            catch (Exception ex)
            {
                Program.Logger.LogError(ex);
                MessageBox.Show(StaticStrings.ErrorMessage(ex));
            }
}

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Program.Logger.LogError(ex);
                MessageBox.Show(StaticStrings.ErrorMessage(ex));
            }


}

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Program.Logger.LogError(ex);
                MessageBox.Show(StaticStrings.ErrorMessage(ex));
            }
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

            comboBoxPositionType.SelectedItem = _currentPosition.Type.GetDescription();
            comboBoxPeriod.SelectedItem = _currentPosition.Period.GetDescription();
            SwitchPositionType();
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
            buttonAuto.Enabled = !enabled;
            dateTimePickerDate.Enabled = enabled;
            comboBoxClient.Enabled = enabled;
            listBoxPositions.Enabled = !enabled;
            comboBoxDescription.Enabled = enabled;
            comboBoxPositionType.Enabled = enabled;
            comboBoxPeriod.Enabled = enabled;
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

        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentPosition == null)
                return;

            _currentPosition.Period = (Period)EnumExtensions.GetValueFromDescription<Period>(comboBoxPeriod.Text);
        }

        private void comboBoxPositionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentPosition == null)
                return;

            _currentPosition.Type = (PositionType)EnumExtensions.GetValueFromDescription<PositionType>(comboBoxPositionType.Text);
            SwitchPositionType();
        }

        private void SwitchPositionType()
        {
            var isPeriodical = _currentPosition.Type == PositionType.Periodical;
            comboBoxPeriod.Visible = isPeriodical;
            if (isPeriodical)
                labelDate.Text = "Startdatum";
            else
                labelDate.Text = "Datum";
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            if (AutoPositionsForm == null || (AutoPositionsForm.IsDisposed))
            {
                var parent = this.ParentForm;
                AutoPositionsForm = new AutoPositionsForm() { Owner = parent, Location = new Point(parent.Location.X + parent.Width, parent.Location.Y) };
            }
            AutoPositionsForm.SetPositionList(_positionList);
            AutoPositionsForm.SetParentControl(this);
            AutoPositionsForm.Show();
        }
    }
}
