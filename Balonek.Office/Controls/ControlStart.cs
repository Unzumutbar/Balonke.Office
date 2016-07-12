using System;
using System.Media;
using System.Windows.Forms;

namespace Balonek.Office.Controls
{
    public partial class ControlStart : UserControl
    {
        public ControlStart()
        {
            InitializeComponent();
        }

        private void panelSecret_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Balonek.Office.Properties.Resources.secret);
            audio.Play();
        }
    }
}
