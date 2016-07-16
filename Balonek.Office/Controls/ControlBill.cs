using Balonek.Office.Objects;
using Balonek.Office.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Balonek.Office.Controls
{
    public partial class ControlBill : UserControl
    {
        private Bill _currentBill;
        private List<Bill> _billList;
        private List<Bill> _billSearchList;

        private List<Client> _clientList;
        private List<BillPosition> _positionList;

        private bool _isAdding;
        private string _searchContent;

        public BindingList<BillPosition> AssociatedBillPositions = new BindingList<BillPosition>();
        private string _message;

        public ControlBill()
        {
            InitializeComponent();
            UpdateBillList();
            UpdateClientList();
            UpdateBillPositionList();
        }

        private void UpdateBillList(bool useCache = false)
        {
            if(!useCache)
                _billList = Program.Database.GetBillList();

            _billSearchList = _billList.OrderByDescending(p => p.Client.Id).ToList();
            if (!String.IsNullOrWhiteSpace(_searchContent))
                _billSearchList = _billList.Where(p => p.Client.Name.Contains(_searchContent)|| p.DateFrom.ToMonthAndYear().Contains(_searchContent)).ToList();

            this.listBoxPositions.Items.Clear();
            foreach (var bill in _billSearchList)
            {
                this.listBoxPositions.Items.Add(bill.ToString());
            }
        }

        private void UpdateClientList(bool useCache = false)
        {
            _clientList = Program.Database.GetClientList();
            this.comboBoxClient.Items.Clear();
            foreach (var client in _clientList)
            {
                this.comboBoxClient.Items.Add(client.ToString());
            }
        }

        private void UpdateBillPositionList()
        {
            _positionList = Program.Database.GetBillPositionList();
        }

        private void listBoxBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxPositions.SelectedIndex;
            if (index < 0)
                return;

            _currentBill = _billSearchList[index];
            if (_currentBill == null)
            {
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }

            LoadCurrentBill();
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
            buttonExport.Enabled = true;
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxClient.SelectedIndex;
            if (index < 0)
                return;

            if (_clientList[index] == null)
                return;

            _currentBill.Client = _clientList[index];
            textBoxClientName.Text = _currentBill.Client.Name;

            LoadAssociatedBillPositions();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            _currentBill = new Bill();
            if (_billList.Any())
                _currentBill.Id = _billList.Max(c => c.Id) + 1;
            else
                _currentBill.Id = 1;

            LoadCurrentBill();
            EnableEditMode(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            if (_currentBill == null)
                return;
            _isAdding = false;
            EnableEditMode(true);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            if (_currentBill == null)
                return;

            Program.Database.DeleteBill(_currentBill);
            EnableEditMode(false);

            _currentBill = new Bill();
            LoadCurrentBill();
            UpdateBillList();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateCurrentClient();
            if (CanSave)
            {
                if (_isAdding)
                    Program.Database.AddBill(_currentBill);
                else
                    Program.Database.UpdateBill(_currentBill);

                EnableEditMode(false);
                UpdateBillList();
            }
            else
                MessageBox.Show(_message);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EnableEditMode(false);
        }

        private void LoadCurrentBill()
        {
            textBoxId.Text = _currentBill.Id.ToString();
            textBoxClientName.Text = _currentBill.Client.Name;
            var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            if (_currentBill.DateFrom == null || _currentBill.DateFrom <= DateTime.MinValue)
                _currentBill.DateFrom = firstDayOfMonth;

            if (_currentBill.DateTo == null || _currentBill.DateTo <= DateTime.MinValue)
                _currentBill.DateTo = lastDayOfMonth;

            pickerDateFrom.Value = _currentBill.DateFrom;
            pickerDateTo.Value = _currentBill.DateTo;

            LoadAssociatedBillPositions();
        }

        private void LoadAssociatedBillPositions()
        {
            var results = _positionList.Where(pb => pb.Date >= _currentBill.DateFrom && pb.Date <= _currentBill.DateTo && pb.Client.Id == _currentBill.Client.Id).ToList();
            _currentBill.Positions = results;
            AssociatedBillPositions = new BindingList<BillPosition>(results);
            var source = new BindingSource(AssociatedBillPositions, null);
            dataGridPositions.DataSource = source;

            CalculateSum();
        }

        private void UpdateCurrentClient()
        {
            //_currentPosition.ClientId = textBoxName.Text;
            //_currentPosition.ClientName = textBoxClientName.Text;
            _currentBill.DateFrom = pickerDateFrom.Value;
            _currentBill.DateTo = pickerDateTo.Value;
        }

        private void EnableEditMode(bool enabled)
        {
            //textBoxClientName.ReadOnly = !enabled;
            buttonAdd.Enabled = !enabled;
            buttonEdit.Enabled = !enabled;
            buttonDelete.Enabled = !enabled;
            buttonSave.Enabled = enabled;
            buttonCancel.Enabled = enabled;
            buttonExport.Enabled = !enabled;
            pickerDateFrom.Enabled = enabled;
            pickerDateTo.Enabled = enabled;
            comboBoxClient.Enabled = enabled;
            listBoxPositions.Enabled = !enabled;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _searchContent = textBoxSearch.Text;
            UpdateBillList(true);
        }

        private void CalculateSum()
        {
            var totalsum = 0m;
            if(AssociatedBillPositions.Any())
            {
                foreach (var position in AssociatedBillPositions)
                {
                    totalsum += position.Time * position.Rate;  
                }
            }
            textBoxTotal.Text = totalsum.ToString();
            _currentBill.Total = totalsum;
        }

        private void pickerDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAssociatedBillPositions();
        }

        private bool CanSave
        {
            get
            {
                _message = string.Empty;
                if (_currentBill.Client.Id == 0)
                    _message += "Es wurde kein Kunde ausgewählt!";
                if(pickerDateFrom.Value >= pickerDateTo.Value)
                    _message += "Es wurde ein ungültiger Zeitraum ausgewählt!";

                return String.IsNullOrEmpty(_message);
            } 
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Open Document Text(*.odt)|*.odt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = string.Format("Rechnung {0} - {1}.odt", _currentBill.Client.Name, _currentBill.DateFrom.ToMonth());

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateBillFromTemplate(saveFileDialog.FileName);
                MessageBox.Show(_message);
            }
        }

        private void CreateBillFromTemplate(string billDocument)
        {
            _message = string.Empty;
            var templateFile = Program.Database.GetBillTemplate();
            if (!File.Exists(templateFile))
            {
                _message = string.Format("Template '{0}' exisitert nicht!", Path.GetFullPath(templateFile));
                return;
            }

            if (File.Exists(billDocument))
                File.Delete(billDocument);

            var editor = new OpenDocumentEditor();
            editor.CreateFromTemplate(templateFile);
            editor.ReplaceStringWithDictonary(_currentBill.StringReplacementDictionary());
            editor.SaveDocument(billDocument);
            editor.Close();
        }
    }
}
