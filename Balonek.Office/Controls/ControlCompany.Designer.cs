﻿namespace Balonek.Office.Controls
{
    partial class ControlCompany
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCompany));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.buttonCancel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.labelStreet = new System.Windows.Forms.Label();
            this.textBoxZip = new System.Windows.Forms.TextBox();
            this.labelZipCity = new System.Windows.Forms.Label();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxTelephone = new System.Windows.Forms.TextBox();
            this.textBoxFax = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDatabaseVersion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTemplateBills = new System.Windows.Forms.TextBox();
            this.buttonFindTemplate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonEdit,
            this.toolStripSeparator1,
            this.buttonSave,
            this.buttonCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(757, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(116, 27);
            this.buttonEdit.Text = "Bearbeiten";
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(109, 27);
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
            this.buttonCancel.Size = new System.Drawing.Size(99, 27);
            this.buttonCancel.Text = "Abbruch";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(757, 465);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Controls.Add(this.labelId, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxName, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.labelName, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBoxStreet, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.labelStreet, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBoxZip, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.labelZipCity, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBoxCity, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBoxTelephone, 2, 11);
            this.tableLayoutPanel2.Controls.Add(this.textBoxFax, 2, 13);
            this.tableLayoutPanel2.Controls.Add(this.textBoxEmail, 2, 15);
            this.tableLayoutPanel2.Controls.Add(this.labelTel, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 15);
            this.tableLayoutPanel2.Controls.Add(this.textBoxDatabaseVersion, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 17);
            this.tableLayoutPanel2.Controls.Add(this.textBoxTemplateBills, 2, 17);
            this.tableLayoutPanel2.Controls.Add(this.buttonFindTemplate, 5, 17);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBoxCompany, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 19;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(728, 465);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelId
            // 
            this.labelId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(23, 26);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(89, 20);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Datenbank";
            // 
            // textBoxName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxName, 4);
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(163, 119);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(540, 27);
            this.textBoxName.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(23, 122);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 20);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name";
            // 
            // textBoxStreet
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxStreet, 4);
            this.textBoxStreet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStreet.Location = new System.Drawing.Point(163, 162);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.ReadOnly = true;
            this.textBoxStreet.Size = new System.Drawing.Size(540, 27);
            this.textBoxStreet.TabIndex = 4;
            // 
            // labelStreet
            // 
            this.labelStreet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStreet.AutoSize = true;
            this.labelStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreet.Location = new System.Drawing.Point(23, 165);
            this.labelStreet.Name = "labelStreet";
            this.labelStreet.Size = new System.Drawing.Size(59, 20);
            this.labelStreet.TabIndex = 5;
            this.labelStreet.Text = "Straße";
            // 
            // textBoxZip
            // 
            this.textBoxZip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZip.Location = new System.Drawing.Point(163, 205);
            this.textBoxZip.Name = "textBoxZip";
            this.textBoxZip.ReadOnly = true;
            this.textBoxZip.Size = new System.Drawing.Size(197, 27);
            this.textBoxZip.TabIndex = 6;
            // 
            // labelZipCity
            // 
            this.labelZipCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelZipCity.AutoSize = true;
            this.labelZipCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZipCity.Location = new System.Drawing.Point(23, 208);
            this.labelZipCity.Name = "labelZipCity";
            this.labelZipCity.Size = new System.Drawing.Size(87, 20);
            this.labelZipCity.TabIndex = 7;
            this.labelZipCity.Text = "Plz / Stadt";
            // 
            // textBoxCity
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxCity, 3);
            this.textBoxCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCity.Location = new System.Drawing.Point(366, 205);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.ReadOnly = true;
            this.textBoxCity.Size = new System.Drawing.Size(337, 27);
            this.textBoxCity.TabIndex = 8;
            // 
            // textBoxTelephone
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxTelephone, 4);
            this.textBoxTelephone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTelephone.Location = new System.Drawing.Point(163, 268);
            this.textBoxTelephone.Name = "textBoxTelephone";
            this.textBoxTelephone.ReadOnly = true;
            this.textBoxTelephone.Size = new System.Drawing.Size(540, 27);
            this.textBoxTelephone.TabIndex = 9;
            // 
            // textBoxFax
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxFax, 4);
            this.textBoxFax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFax.Location = new System.Drawing.Point(163, 311);
            this.textBoxFax.Name = "textBoxFax";
            this.textBoxFax.ReadOnly = true;
            this.textBoxFax.Size = new System.Drawing.Size(540, 27);
            this.textBoxFax.TabIndex = 10;
            // 
            // textBoxEmail
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxEmail, 4);
            this.textBoxEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(163, 354);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.ReadOnly = true;
            this.textBoxEmail.Size = new System.Drawing.Size(540, 27);
            this.textBoxEmail.TabIndex = 11;
            // 
            // labelTel
            // 
            this.labelTel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTel.AutoSize = true;
            this.labelTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTel.Location = new System.Drawing.Point(23, 271);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(54, 20);
            this.labelTel.TabIndex = 12;
            this.labelTel.Text = "TelNr.";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "FaxNr.";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "E-Mail";
            // 
            // textBoxDatabaseVersion
            // 
            this.textBoxDatabaseVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxDatabaseVersion.Enabled = false;
            this.textBoxDatabaseVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDatabaseVersion.Location = new System.Drawing.Point(163, 23);
            this.textBoxDatabaseVersion.Name = "textBoxDatabaseVersion";
            this.textBoxDatabaseVersion.Size = new System.Drawing.Size(80, 27);
            this.textBoxDatabaseVersion.TabIndex = 1;
            this.textBoxDatabaseVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Templatepfad";
            // 
            // textBoxTemplateBills
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxTemplateBills, 3);
            this.textBoxTemplateBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTemplateBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTemplateBills.Location = new System.Drawing.Point(163, 417);
            this.textBoxTemplateBills.Name = "textBoxTemplateBills";
            this.textBoxTemplateBills.ReadOnly = true;
            this.textBoxTemplateBills.Size = new System.Drawing.Size(500, 27);
            this.textBoxTemplateBills.TabIndex = 12;
            // 
            // buttonFindTemplate
            // 
            this.buttonFindTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFindTemplate.Enabled = false;
            this.buttonFindTemplate.Image = ((System.Drawing.Image)(resources.GetObject("buttonFindTemplate.Image")));
            this.buttonFindTemplate.Location = new System.Drawing.Point(669, 417);
            this.buttonFindTemplate.Name = "buttonFindTemplate";
            this.buttonFindTemplate.Size = new System.Drawing.Size(34, 27);
            this.buttonFindTemplate.TabIndex = 14;
            this.buttonFindTemplate.UseVisualStyleBackColor = true;
            this.buttonFindTemplate.Click += new System.EventHandler(this.buttonFindTemplate_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Unternehmen";
            // 
            // textBoxCompany
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxCompany, 4);
            this.textBoxCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCompany.Location = new System.Drawing.Point(163, 76);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.ReadOnly = true;
            this.textBoxCompany.Size = new System.Drawing.Size(540, 27);
            this.textBoxCompany.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // ControlCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControlCompany";
            this.Size = new System.Drawing.Size(757, 495);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonCancel;
        private System.Windows.Forms.ToolStripButton buttonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxDatabaseVersion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxTemplateBills;
        private System.Windows.Forms.Button buttonFindTemplate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.Label labelStreet;
        private System.Windows.Forms.TextBox textBoxZip;
        private System.Windows.Forms.Label labelZipCity;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxTelephone;
        private System.Windows.Forms.TextBox textBoxFax;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCompany;
    }
}
