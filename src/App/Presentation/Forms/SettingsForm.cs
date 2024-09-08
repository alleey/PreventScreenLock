using PreventScreenLock.App.Core.Interfaces;

namespace PreventScreenLock.App
{
    public partial class SettingsForm : Form
    {
        private readonly ILaunchSettings _launchSettings;

        public SettingsForm(ILaunchSettings launchSettings)
        {
            InitializeComponent();
            _launchSettings = launchSettings;

            // Load the settings when the form loads
            _launchSettings.LoadSettings();

            chkAutoLaunch.Checked = _launchSettings.AutoLaunch;
            chkMinimized.Checked = _launchSettings.StartMinimized;
            chkAutoDisable.Checked = _launchSettings.AutoDisable;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Update the settings based on the checkbox values
            _launchSettings.AutoLaunch = chkAutoLaunch.Checked;
            _launchSettings.StartMinimized = chkMinimized.Checked;
            _launchSettings.AutoDisable = chkAutoDisable.Checked;

            // Save the settings
            _launchSettings.SaveSettings();

            Close();
        }
    }
}
