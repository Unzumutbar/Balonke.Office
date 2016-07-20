﻿namespace Balonek.Office.Controls
{
    partial class ControlBillPosition
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBillPosition));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonEdit = new System.Windows.Forms.ToolStripButton();
            this.buttonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.buttonCancel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.listBoxPositions = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelZipCity = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBoxRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.labelClient = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.comboBoxDescription = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonEdit,
            this.buttonDelete,
            this.toolStripSeparator1,
            this.buttonSave,
            this.buttonCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(568, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(58, 24);
            this.buttonAdd.Text = "Neu";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(98, 24);
            this.buttonEdit.Text = "Bearbeiten";
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(83, 24);
            this.buttonDelete.Text = "Löschen";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(92, 24);
            this.buttonSave.Text = "Speichern";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 24);
            this.buttonCancel.Text = "Abbruch";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxSearch);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxPositions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(568, 402);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(215, 23);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // listBoxPositions
            // 
            this.listBoxPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPositions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPositions.FormattingEnabled = true;
            this.listBoxPositions.ItemHeight = 17;
            this.listBoxPositions.Location = new System.Drawing.Point(0, 28);
            this.listBoxPositions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxPositions.Name = "listBoxPositions";
            this.listBoxPositions.Size = new System.Drawing.Size(215, 361);
            this.listBoxPositions.TabIndex = 0;
            this.listBoxPositions.SelectedIndexChanged += new System.EventHandler(this.listBoxClients_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Controls.Add(this.labelId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxId, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxClientName, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelDescription, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelZipCity, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTime, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelTime, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.textBoxRate, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTotal, 4, 12);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerDate, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelClient, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxClient, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDescription, 2, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 402);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelId
            // 
            this.labelId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(17, 21);
            this.labelId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(84, 17);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "PositionsNr.";
            // 
            // textBoxId
            // 
            this.textBoxId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxId.Enabled = false;
            this.textBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxId.Location = new System.Drawing.Point(107, 18);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(71, 23);
            this.textBoxId.TabIndex = 1;
            this.textBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxClientName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxClientName, 3);
            this.textBoxClientName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClientName.Location = new System.Drawing.Point(107, 82);
            this.textBoxClientName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.ReadOnly = true;
            this.textBoxClientName.Size = new System.Drawing.Size(221, 23);
            this.textBoxClientName.TabIndex = 3;
            this.textBoxClientName.TabStop = false;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(17, 121);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(35, 17);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Text";
            // 
            // labelZipCity
            // 
            this.labelZipCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelZipCity.AutoSize = true;
            this.labelZipCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZipCity.Location = new System.Drawing.Point(17, 157);
            this.labelZipCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelZipCity.Name = "labelZipCity";
            this.labelZipCity.Size = new System.Drawing.Size(49, 17);
            this.labelZipCity.TabIndex = 7;
            this.labelZipCity.Text = "Datum";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.Location = new System.Drawing.Point(107, 205);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(71, 23);
            this.textBoxTime.TabIndex = 6;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTime.TextChanged += new System.EventHandler(this.decimalTextBox_TextChanged);
            this.textBoxTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(17, 208);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(83, 17);
            this.labelTime.TabIndex = 12;
            this.labelTime.Text = "Stunden (h)";
            // 
            // textBoxRate
            // 
            this.textBoxRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRate.Location = new System.Drawing.Point(257, 205);
            this.textBoxRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRate.Name = "textBoxRate";
            this.textBoxRate.ReadOnly = true;
            this.textBoxRate.Size = new System.Drawing.Size(71, 23);
            this.textBoxRate.TabIndex = 7;
            this.textBoxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxRate.TextChanged += new System.EventHandler(this.decimalTextBox_TextChanged);
            this.textBoxRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 208);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Satz (€)";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(257, 240);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(71, 23);
            this.textBoxTotal.TabIndex = 8;
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 243);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Summe";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.SetColumnSpan(this.dateTimePickerDate, 2);
            this.dateTimePickerDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerDate.Enabled = false;
            this.dateTimePickerDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(107, 154);
            this.dateTimePickerDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerDate.Size = new System.Drawing.Size(146, 23);
            this.dateTimePickerDate.TabIndex = 5;
            this.dateTimePickerDate.Value = new System.DateTime(2016, 7, 5, 0, 0, 0, 0);
            // 
            // labelClient
            // 
            this.labelClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClient.Location = new System.Drawing.Point(17, 70);
            this.labelClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClient.Name = "labelClient";
            this.tableLayoutPanel1.SetRowSpan(this.labelClient, 2);
            this.labelClient.Size = new System.Drawing.Size(49, 17);
            this.labelClient.TabIndex = 3;
            this.labelClient.Text = "Kunde";
            // 
            // comboBoxClient
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxClient, 3);
            this.comboBoxClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClient.Enabled = false;
            this.comboBoxClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(107, 53);
            this.comboBoxClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(221, 25);
            this.comboBoxClient.TabIndex = 2;
            this.comboBoxClient.SelectedIndexChanged += new System.EventHandler(this.comboBoxClient_SelectedIndexChanged);
            // 
            // comboBoxDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxDescription, 3);
            this.comboBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxDescription.Enabled = false;
            this.comboBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDescription.FormattingEnabled = true;
            this.comboBoxDescription.Location = new System.Drawing.Point(107, 117);
            this.comboBoxDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxDescription.Name = "comboBoxDescription";
            this.comboBoxDescription.Size = new System.Drawing.Size(221, 25);
            this.comboBoxDescription.TabIndex = 15;
            // 
            // ControlBillPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlBillPosition";
            this.Size = new System.Drawing.Size(568, 429);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonCancel;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private System.Windows.Forms.ToolStripButton buttonEdit;
        private System.Windows.Forms.ToolStripButton buttonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxPositions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelZipCity;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxRate;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.ComboBox comboBoxDescription;
    }
}
