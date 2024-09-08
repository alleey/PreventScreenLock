using PreventScreenLock.App.Core.Extensions;
using PreventScreenLock.App.Infrastructure.Services;
using PreventScreenLock.App.Properties;

namespace PreventScreenLock.App
{
    public class NotificationService : INotificationService, IDisposable
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly IDisableScreenLockService _disableScreenLockService;

        public event Action? RequestAttention;

        public NotificationService(IDisableScreenLockService disableScreenLockService)
        {
            _disableScreenLockService = disableScreenLockService;
            _notifyIcon = new NotifyIcon();
            _notifyIcon.MouseDoubleClick += _notifyIcon_MouseDoubleClick;
            _notifyIcon.Icon = _disableScreenLockService.IsScreenLockDisabled() ? Resources.IconUnlocked : Resources.IconLocked;
            _disableScreenLockService.LockStatusChanged += (ScreenLockStatus status) =>
            {
                _notifyIcon.Icon = status == ScreenLockStatus.Disabled ? Resources.IconUnlocked : Resources.IconLocked;
            };
        }

        public void ShowBalloonTip(string title, string text)
        {
            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = text;
            _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            _notifyIcon.Text = "Screen lock prevention is active.";
            _notifyIcon.ShowBalloonTip(3000);
        }

        public void ShowInTray(bool show, ContextMenuStrip? contextMenuStrip)
        {
            _notifyIcon.Visible = show;
            _notifyIcon.ContextMenuStrip = show ? contextMenuStrip : null;
        }

        public void Dispose()
        {
            _notifyIcon?.Dispose();
        }

        private void _notifyIcon_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            RequestAttention?.Invoke();
        }
    }
}
