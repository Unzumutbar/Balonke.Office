namespace Balonek.Office.Controls
{
    partial class ControlSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSettings));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.buttonCancel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDatabaseVersion = new System.Windows.Forms.Label();
            this.textBoxDatabaseVersion = new System.Windows.Forms.TextBox();
            this.textBoxTemplateBills = new System.Windows.Forms.TextBox();
            this.labelTemplateBills = new System.Windows.Forms.Label();
            this.buttonFindTemplate = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(757, 498);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.labelDatabaseVersion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDatabaseVersion, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTemplateBills, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTemplateBills, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonFindTemplate, 5, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(728, 498);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelDatabaseVersion
            // 
            this.labelDatabaseVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDatabaseVersion.AutoSize = true;
            this.labelDatabaseVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatabaseVersion.Location = new System.Drawing.Point(23, 26);
            this.labelDatabaseVersion.Name = "labelDatabaseVersion";
            this.labelDatabaseVersion.Size = new System.Drawing.Size(97, 20);
            this.labelDatabaseVersion.TabIndex = 0;
            this.labelDatabaseVersion.Text = "DB-Version";
            // 
            // textBoxDatabaseVersion
            // 
            this.textBoxDatabaseVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDatabaseVersion.Enabled = false;
            this.textBoxDatabaseVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDatabaseVersion.Location = new System.Drawing.Point(173, 23);
            this.textBoxDatabaseVersion.Name = "textBoxDatabaseVersion";
            this.textBoxDatabaseVersion.Size = new System.Drawing.Size(192, 27);
            this.textBoxDatabaseVersion.TabIndex = 1;
            this.textBoxDatabaseVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxTemplateBills
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxTemplateBills, 3);
            this.textBoxTemplateBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTemplateBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTemplateBills.Location = new System.Drawing.Point(173, 66);
            this.textBoxTemplateBills.Name = "textBoxTemplateBills";
            this.textBoxTemplateBills.ReadOnly = true;
            this.textBoxTemplateBills.Size = new System.Drawing.Size(490, 27);
            this.textBoxTemplateBills.TabIndex = 2;
            // 
            // labelTemplateBills
            // 
            this.labelTemplateBills.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTemplateBills.AutoSize = true;
            this.labelTemplateBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplateBills.Location = new System.Drawing.Point(23, 69);
            this.labelTemplateBills.Name = "labelTemplateBills";
            this.labelTemplateBills.Size = new System.Drawing.Size(110, 20);
            this.labelTemplateBills.TabIndex = 3;
            this.labelTemplateBills.Text = "Templatepfad";
            // 
            // buttonFindTemplate
            // 
            this.buttonFindTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFindTemplate.Enabled = false;
            this.buttonFindTemplate.Image = ((System.Drawing.Image)(resources.GetObject("buttonFindTemplate.Image")));
            this.buttonFindTemplate.Location = new System.Drawing.Point(669, 66);
            this.buttonFindTemplate.Name = "buttonFindTemplate";
            this.buttonFindTemplate.Size = new System.Drawing.Size(34, 27);
            this.buttonFindTemplate.TabIndex = 4;
            this.buttonFindTemplate.UseVisualStyleBackColor = true;
            this.buttonFindTemplate.Click += new System.EventHandler(this.buttonFindTemplate_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // ControlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControlSettings";
            this.Size = new System.Drawing.Size(757, 528);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton buttonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelDatabaseVersion;
        private System.Windows.Forms.TextBox textBoxDatabaseVersion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxTemplateBills;
        private System.Windows.Forms.Label labelTemplateBills;
        private System.Windows.Forms.Button buttonFindTemplate;
    }
}
