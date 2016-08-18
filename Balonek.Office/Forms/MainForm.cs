using Balonek.Office.Controls;
using Balonek.Office.Utils;
using System;
using System.Windows.Forms;

namespace Balonek.Office.Forms
{
    public partial class MainForm : Form
    {
        UserControl UserControl;
        public MainForm()
        {
            InitializeComponent();
            LoadUserControl(new ControlStart());

        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ControlClient());
        }

        private void buttonBillPositions_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ControlBillPosition());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ControlBill());
        }

        private void LoadUserControl(UserControl userControl)
        {
            this.splitContainer1.Panel2.Controls.Remove(UserControl);

            UserControl = userControl;
            UserControl.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(UserControl);
            this.secretPanel.BackgroundImage = ImageArchive.GetRandomSmallImage();
        }

        private void toolStripSettings_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ControlCompany());
        }

        private void secret_Click(object sender, EventArgs e)
        {
            try
            {
                var soundplayer = new BalonekSoundPlayer();
                soundplayer.PlaySecretMusic();
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
        }

        private void buttonText_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ControlText());
        }
    }
}
