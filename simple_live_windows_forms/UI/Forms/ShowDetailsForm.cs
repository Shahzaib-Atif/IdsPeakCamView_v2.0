using System.Windows.Forms;

namespace TriCamPylonView.UI.Forms
{
    public partial class ShowDetailsForm : Form
    {
        public ShowDetailsForm()
        {
            InitializeComponent();
        }

        // close the form when ESC is pressed
        private void ShowDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
