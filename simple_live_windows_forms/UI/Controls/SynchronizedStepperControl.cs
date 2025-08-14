using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;

namespace simple_ids_cam_view.UI.Controls
{
    public partial class SynchronizedStepperControl : UserControl
    {
        public event Action<int> ValueChanged; // event to notify when value changes
        public event Action<string> AutoModeChanged; // event to notify when auto mode changes

        public SynchronizedStepperControl()
        {
            InitializeComponent();
            EnableUI(false);

            groupBox.Click += (object s, EventArgs e) => this.labelAuto.Focus();
        }

        public void SetValue(double val)
        {
            this.Value = (int)val;
        }

        public void InitializeAutomodeUI(string _automode)
        {
            RadioButtonOn.Checked = _automode == AutoMode.Continuous;
            RadioButtonOff.Checked = _automode == AutoMode.Off;
        }

        private void TextBoxValue_KeyDown(object sender, KeyEventArgs e)
        {
            // only proceed for ENTER key
            if (e.KeyCode != Keys.Enter) return;

            // check if it is a valid value in the textbox
            bool isInteger = int.TryParse(textBoxValue.Text, out int value);

            if (isInteger)
                this.Value = value;
            else
            {
                ExceptionHelper.ShowWarningMessage("Not a valid value!");
                this.Value = Value + 0; // this will restore the textbox with previous value
            }

            Parent?.Focus(); // clear focus
        }


        private void RadioButtonOn_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonOn.Checked)
            {
                RadioButtonOff.Checked = false;
                EnableUI(false);
                AutoModeChanged?.Invoke(AutoMode.Continuous);
            }
        }

        private void RadioButtonOff_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonOff.Checked)
            {
                RadioButtonOn.Checked = false;
                EnableUI(true);
                AutoModeChanged?.Invoke(AutoMode.Off);
            }
        }

        private void EnableUI(bool enabled)
        {
            trackBar.Enabled = enabled;
            FlpValue.Enabled = enabled;
        }

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.Value = trackBar.Value;
        }

        private void LabelDecrement_MouseDown(object sender, MouseEventArgs e)
        {
            this.Value = Value - Increment;
        }

        private void LabelIncrement_MouseDown(object sender, MouseEventArgs e)
        {
            this.Value = Value + Increment;
        }

        public int Minimum
        {
            get => trackBar.Minimum;
            set => trackBar.Minimum = value;
        }

        public int Maximum
        {
            get => trackBar.Maximum;
            set => trackBar.Maximum = value;
        }

        public int Value
        {
            get => trackBar.Value;
            private set
            {
                value = Math.Clamp(value, Minimum, Maximum);
                trackBar.Value = value;
                textBoxValue.Text = value.ToString();
                ValueChanged?.Invoke(value);
            }
        }

        public string CustomName
        {
            get => groupBox.Text;
            set => groupBox.Text = value;
        }

        public int Increment
        {
            get => (int)trackBar.LargeChange;
            set
            {
                trackBar.SmallChange = value;
                trackBar.LargeChange = value;
            }

        }
    }
}
