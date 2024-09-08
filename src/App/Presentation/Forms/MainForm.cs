using PreventScreenLock.App.Core.Extensions;
using PreventScreenLock.App.Core.Interfaces;
using PreventScreenLock.App.Infrastructure.Services;
using PreventScreenLock.App.Presentation;
using PreventScreenLock.App.Properties;

namespace PreventScreenLock.App
{
    public partial class MainForm : Form
    {
        private readonly Func<SettingsForm> _settingsFormFactory;
        private readonly IDisableScreenLockService _disableScreenLockService;
        private readonly INotificationService _notificationService;

        public MainForm(Func<SettingsForm> settingsFormFactory,
            IDisableScreenLockService disableScreenLockService,
            INotificationService notificationService,
            ILaunchSettings launchSettings)
        {
            _settingsFormFactory = settingsFormFactory;
            _disableScreenLockService = disableScreenLockService;
            _notificationService = notificationService;

            InitializeComponent();
            this.Text = $"{UIConstants.AppTitleWithVersion}";

            _notificationService.RequestAttention += ShowMainWindow;

            this.Icon = _disableScreenLockService.IsScreenLockDisabled() ? Resources.IconUnlocked : Resources.IconLocked;
            _disableScreenLockService.LockStatusChanged += (ScreenLockStatus status) =>
            {
                this.Icon = status == ScreenLockStatus.Disabled ? Resources.IconUnlocked : Resources.IconLocked;
            };

            if (launchSettings.StartMinimized)
            {
                HideMainWindow();
            }
            if (launchSettings.AutoDisable)
            {
                DisableLockingControls();
            }
        }

        private void btnPreventLock_Click(object sender, EventArgs e)
        {
            if (!_disableScreenLockService.IsScreenLockDisabled())
            {
                DisableLockingControls();
                HideMainWindow();
            }
            else
            {
                EnableLockingControls();
            }
        }

        private void EnableLockingControls()
        {
            btnPreventLock.Text = "&Disable Screen Lock";
            disableToolStrip.Text = "&Disable";
            _disableScreenLockService.Stop();
        }

        private void DisableLockingControls()
        {
            btnPreventLock.Text = "&Enable Screen Lock";
            disableToolStrip.Text = "&Enable";
            _disableScreenLockService.Start();
            _notificationService.ShowBalloonTip("Prevent Screen Lock", "Screen lock prevention is active.");
        }

        private void ShowMainWindow()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            _notificationService.ShowInTray(false);
        }

        private void HideMainWindow()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            _notificationService.ShowInTray(true, contextMenuStrip);
        }

        private void disableToolStrip_Click(object sender, EventArgs e)
        {
            btnPreventLock_Click(sender, e);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideMainWindow();
            }
        }

        private void showToolStrip_Click(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var settingsDialog = _settingsFormFactory();
            settingsDialog.ShowDialog(this);
        }
    }
}
