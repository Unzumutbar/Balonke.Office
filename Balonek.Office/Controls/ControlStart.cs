using Balonek.Office.Utils;
using System.Windows.Forms;

namespace Balonek.Office.Controls
{
    public partial class ControlStart : UserControl
    {
        public ControlStart()
        {
            InitializeComponent();
            this.BackgroundImage = ImageArchive.GetRandomBackground();
        }
    }
}
