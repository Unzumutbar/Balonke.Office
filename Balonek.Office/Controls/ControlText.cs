using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unzumutbar.Extensions;

namespace Balonek.Office.Controls
{
    public partial class ControlText : UserControl
    {
        private List<Text> _textList;
        private List<Text> _textSearchList;
        private Text _currentText;
        private bool _isAdding;
        private string _searchContent;

        public ControlText()
        {
            InitializeComponent();
            UpdateClientList();
        }

        private void UpdateClientList(bool useCache = false)
        {
            if (!useCache)
                _textList = Program.Database.Texts.Get();

            _textSearchList = _textList;
            if (_searchContent.IsNotNullOrWhitespace())
                _textSearchList = _textList.Where(t => t.Value.Contains(_searchContent)).ToList();

            this.listBoxTexts.Items.Clear();
            foreach (var text in _textSearchList)
            {
                this.listBoxTexts.Items.Add(text.ToString());
            }
        }

        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxTexts.SelectedIndex;
            if (index < 0)
                return;

            _currentText = _textSearchList[index];
            if (_currentText == null)
            {
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }

            LoadCurrentText();
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            _currentText = new Text();

            LoadCurrentText();
            EnableEditMode(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            if (_currentText == null)
                return;
            _isAdding = false;
            EnableEditMode(true);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            if (_currentText == null)
                return;

            Program.Database.Texts.Delete(_currentText);
            EnableEditMode(false);

            _currentText = new Text();
            LoadCurrentText();
            UpdateClientList();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateCurrentClient();
            if (_isAdding)
                Program.Database.Texts.Add(_currentText);
            else
                Program.Database.Texts.Update(_currentText);

            EnableEditMode(false);
            UpdateClientList();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EnableEditMode(false);
        }

        private void LoadCurrentText()
        {
            textBoxId.Text = _currentText.Id.ToString();
            textBoxText.Text = _currentText.Value;
        }

        private void UpdateCurrentClient()
        {
            _currentText.Value = textBoxText.Text;
        }

        private void EnableEditMode(bool enabled)
        {
            textBoxText.ReadOnly = !enabled;

            buttonAdd.Enabled = !enabled;
            buttonEdit.Enabled = !enabled;
            buttonDelete.Enabled = !enabled;
            buttonSave.Enabled = enabled;
            buttonCancel.Enabled = enabled;
            listBoxTexts.Enabled = !enabled;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _searchContent = textBoxSearch.Text;
            UpdateClientList(true);
        }
    }
}
