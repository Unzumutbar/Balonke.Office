namespace Balonek.Office.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonClients = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBillPositions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBills = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSettings = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonClients,
            this.toolStripSeparator1,
            this.buttonBillPositions,
            this.toolStripSeparator2,
            this.buttonBills,
            this.toolStripSeparator3,
            this.toolStripSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(172, 977);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonClients
            // 
            this.buttonClients.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonClients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClients.Image = ((System.Drawing.Image)(resources.GetObject("buttonClients.Image")));
            this.buttonClients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonClients.Name = "buttonClients";
            this.buttonClients.Size = new System.Drawing.Size(169, 32);
            this.buttonClients.Text = "Kunden";
            this.buttonClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClients.Click += new System.EventHandler(this.buttonClients_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // buttonBillPositions
            // 
            this.buttonBillPositions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonBillPositions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBillPositions.Image = ((System.Drawing.Image)(resources.GetObject("buttonBillPositions.Image")));
            this.buttonBillPositions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBillPositions.Name = "buttonBillPositions";
            this.buttonBillPositions.Size = new System.Drawing.Size(169, 32);
            this.buttonBillPositions.Text = "Stundenerfassung";
            this.buttonBillPositions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBillPositions.Click += new System.EventHandler(this.buttonBillPositions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // buttonBills
            // 
            this.buttonBills.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonBills.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBills.Image = ((System.Drawing.Image)(resources.GetObject("buttonBills.Image")));
            this.buttonBills.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBills.Name = "buttonBills";
            this.buttonBills.Size = new System.Drawing.Size(169, 32);
            this.buttonBills.Text = "Rechnungen";
            this.buttonBills.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBills.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSettings.Image")));
            this.toolStripSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(169, 32);
            this.toolStripSettings.Text = "Einstellungen";
            this.toolStripSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(172, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(1090, 977);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 977);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Sosias kleines Büro";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonClients;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonBillPositions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonBills;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripSettings;
    }
}