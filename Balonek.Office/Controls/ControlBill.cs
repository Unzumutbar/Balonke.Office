﻿using Balonek.Database.Entities;
using Balonek.Office.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unzumutbar.Extensions;

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
            try
            {
                InitializeComponent();
                UpdateBillList();
                UpdateClientList();
                UpdateBillPositionList();
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
        }

        private void UpdateBillList(bool useCache = false)
        {
            if (!useCache)
                _billList = Program.Database.Bills.Get();

            _billSearchList = _billList.OrderBy(p => p.Client.Id).ThenByDescending(p => p.DateFrom).ToList();
            if (_searchContent.IsNotNullOrWhitespace())
                _billSearchList = _billList.Where(p => p.Client.Name.Contains(_searchContent) || p.DateFrom.ToMonthAndYearGerman().Contains(_searchContent)).ToList();

            this.listBoxPositions.Items.Clear();
            foreach (var bill in _billSearchList)
            {
                this.listBoxPositions.Items.Add(bill.ToString());
            }
        }

        private void UpdateClientList(bool useCache = false)
        {
            _clientList = Program.Database.Clients.Get();
            this.comboBoxClient.Items.Clear();
            foreach (var client in _clientList)
            {
                this.comboBoxClient.Items.Add(client.ToString());
            }
        }

        private void UpdateBillPositionList()
        {
            _positionList = Program.Database.BillPositions.Get();
            _positionList = _positionList.Where(p => p.Type == PositionType.Single).ToList();
        }

        private void listBoxBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
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
            try
            {
                _isAdding = true;
                _currentBill = new Bill();

                LoadCurrentBill();
                EnableEditMode(true);
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
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
            try
            {
                _isAdding = false;
                if (_currentBill == null)
                    return;

                Program.Database.Bills.Delete(_currentBill);
                EnableEditMode(false);

                _currentBill = new Bill();
                LoadCurrentBill();
                UpdateBillList();
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
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
                        _currentBill = Program.Database.Bills.Add(_currentBill);
                    else
                        Program.Database.Bills.Update(_currentBill);

                    this.textBoxId.Text = _currentBill.Id.ToString();
                    EnableEditMode(false);
                    UpdateBillList();
                }
                else
                    BalonekMessageBox.ShowStop(Program.Logger, _message);
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
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

            if (_currentBill.DateFrom <= DateTime.MinValue)
                _currentBill.DateFrom = firstDayOfMonth;

            if (_currentBill.DateTo <= DateTime.MinValue)
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
            if (AssociatedBillPositions.Any())
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
                if (pickerDateFrom.Value >= pickerDateTo.Value)
                    _message += "Es wurde ein ungültiger Zeitraum ausgewählt!";

                return _message.IsNullOrWhitespace();
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Open Document Text(*.odt)|*.odt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = string.Format("Rechnung {0} - {1}.odt", _currentBill.Client.Name, _currentBill.DateFrom.ToMonthGerman());

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CreateBillFromTemplate(saveFileDialog.FileName);
                    BalonekMessageBox.Show(Program.Logger, _message);
                }
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
        }

        private void CreateBillFromTemplate(string billDocument)
        {
            try
            {
                _message = string.Empty;
                var templateFile = Program.Database.Company.Get().TemplateBillPath;
                if (!File.Exists(templateFile))
                {
                    _message = string.Format("Template '{0}' exisitert nicht!", Path.GetFullPath(templateFile));
                    return;
                }

                if (File.Exists(billDocument))
                    File.Delete(billDocument);

                var editor = new OpenDocumentEditor();
                editor.CreateFromTemplate(templateFile);
                editor.ReplaceWithDictonary(_currentBill.StringReplacementDictionary());
                editor.DeleteTableRow("%pos");
                editor.Save(billDocument);
                _message = string.Format("{0} erfolgreich exportiert.", Path.GetFullPath(billDocument));
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
        }
    }
}
