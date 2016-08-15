namespace Balonek.Office.Forms
{
    partial class AutoPositionsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxPositions = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pickerDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pickerDateEnd = new System.Windows.Forms.DateTimePicker();
            this.labelZipCity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridPositions = new System.Windows.Forms.DataGridView();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingBillPosition = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBillPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxPositions, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.pickerDateFrom, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pickerDateEnd, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelZipCity, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridPositions, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(575, 524);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listBoxPositions
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxPositions, 4);
            this.listBoxPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPositions.FormattingEnabled = true;
            this.listBoxPositions.Location = new System.Drawing.Point(17, 45);
            this.listBoxPositions.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPositions.Name = "listBoxPositions";
            this.listBoxPositions.Size = new System.Drawing.Size(539, 206);
            this.listBoxPositions.TabIndex = 20;
            this.listBoxPositions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBoxPositions_ItemCheck);
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(254, 481);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 24);
            this.button1.TabIndex = 19;
            this.button1.Text = "Positionen hinzufügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pickerDateFrom
            // 
            this.pickerDateFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerDateFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickerDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickerDateFrom.Location = new System.Drawing.Point(117, 18);
            this.pickerDateFrom.Margin = new System.Windows.Forms.Padding(2);
            this.pickerDateFrom.Name = "pickerDateFrom";
            this.pickerDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pickerDateFrom.Size = new System.Drawing.Size(133, 23);
            this.pickerDateFrom.TabIndex = 9;
            this.pickerDateFrom.Value = new System.DateTime(2016, 7, 5, 0, 0, 0, 0);
            this.pickerDateFrom.ValueChanged += new System.EventHandler(this.pickerDateFrom_ValueChanged);
            // 
            // pickerDateEnd
            // 
            this.pickerDateEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerDateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickerDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickerDateEnd.Location = new System.Drawing.Point(354, 18);
            this.pickerDateEnd.Margin = new System.Windows.Forms.Padding(2);
            this.pickerDateEnd.Name = "pickerDateEnd";
            this.pickerDateEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pickerDateEnd.Size = new System.Drawing.Size(202, 23);
            this.pickerDateEnd.TabIndex = 10;
            this.pickerDateEnd.Value = new System.DateTime(2016, 7, 5, 0, 0, 0, 0);
            this.pickerDateEnd.ValueChanged += new System.EventHandler(this.pickerDateFrom_ValueChanged);
            // 
            // labelZipCity
            // 
            this.labelZipCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelZipCity.AutoSize = true;
            this.labelZipCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZipCity.Location = new System.Drawing.Point(17, 21);
            this.labelZipCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelZipCity.Name = "labelZipCity";
            this.labelZipCity.Size = new System.Drawing.Size(76, 17);
            this.labelZipCity.TabIndex = 8;
            this.labelZipCity.Text = "Datum von";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "bis";
            // 
            // dataGridPositions
            // 
            this.dataGridPositions.AllowUserToAddRows = false;
            this.dataGridPositions.AllowUserToDeleteRows = false;
            this.dataGridPositions.AutoGenerateColumns = false;
            this.dataGridPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPositions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Client,
            this.descriptionDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.rateDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridPositions, 4);
            this.dataGridPositions.DataSource = this.bindingBillPosition;
            this.dataGridPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPositions.Location = new System.Drawing.Point(17, 271);
            this.dataGridPositions.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridPositions.Name = "dataGridPositions";
            this.dataGridPositions.ReadOnly = true;
            this.dataGridPositions.RowHeadersVisible = false;
            this.dataGridPositions.RowTemplate.Height = 24;
            this.dataGridPositions.Size = new System.Drawing.Size(539, 206);
            this.dataGridPositions.TabIndex = 21;
            this.dataGridPositions.TabStop = false;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "Kunde";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Beschreibung";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Datum";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Stunden";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeDataGridViewTextBoxColumn.Width = 50;
            // 
            // rateDataGridViewTextBoxColumn
            // 
            this.rateDataGridViewTextBoxColumn.DataPropertyName = "Rate";
            this.rateDataGridViewTextBoxColumn.HeaderText = "Satz";
            this.rateDataGridViewTextBoxColumn.Name = "rateDataGridViewTextBoxColumn";
            this.rateDataGridViewTextBoxColumn.ReadOnly = true;
            this.rateDataGridViewTextBoxColumn.Width = 50;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Summe";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingBillPosition
            // 
            this.bindingBillPosition.DataSource = typeof(Balonek.Database.Objects.BillPosition);
            // 
            // AutoPositionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 524);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AutoPositionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Automatische Stundenerfassung";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBillPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelZipCity;
        private System.Windows.Forms.DateTimePicker pickerDateFrom;
        private System.Windows.Forms.DateTimePicker pickerDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox listBoxPositions;
        private System.Windows.Forms.BindingSource bindingBillPosition;
        private System.Windows.Forms.DataGridView dataGridPositions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
    }
}