namespace PreventScreenLock.App
{
    public interface INotificationService
    {
        event Action? RequestAttention;
        void ShowBalloonTip(string title, string text);
        void ShowInTray(bool show, ContextMenuStrip? contextMenuStrip = null);
    }
}
