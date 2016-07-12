namespace Balonek.Office.Controls
{
    partial class ControlStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlStart));
            this.panelSecret = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelSecret
            // 
            this.panelSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSecret.BackColor = System.Drawing.Color.Transparent;
            this.panelSecret.Location = new System.Drawing.Point(271, 337);
            this.panelSecret.Name = "panelSecret";
            this.panelSecret.Size = new System.Drawing.Size(104, 81);
            this.panelSecret.TabIndex = 0;
            this.panelSecret.Click += new System.EventHandler(this.panelSecret_Click);
            // 
            // ControlStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.panelSecret);
            this.Name = "ControlStart";
            this.Size = new System.Drawing.Size(800, 800);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSecret;
    }
}
