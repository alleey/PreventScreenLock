using PreventScreenLock.App.Properties;
using System.Windows.Forms;

namespace PreventScreenLock.App
{
    public class NotificationService : INotificationService, IDisposable
    {
        private readonly NotifyIcon _notifyIcon;
        public event Action? RequestAttention;

        public NotificationService()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = Resources.IconNotification;
            _notifyIcon.MouseDoubleClick += _notifyIcon_MouseDoubleClick;
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
