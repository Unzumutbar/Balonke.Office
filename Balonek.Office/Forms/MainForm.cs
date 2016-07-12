using Balonek.Office.Controls;
using Balonek.Office.Utils;
using System;
using System.Media;
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
            LoadUserControl(new ControlSettings());
        }

        private void secret_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Balonek.Office.Properties.Resources.secret);
            audio.Play();
        }
    }
}
