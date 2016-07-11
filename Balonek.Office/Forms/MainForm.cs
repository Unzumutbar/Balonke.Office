using Balonek.Office.Controls;
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
        }
    }
}
