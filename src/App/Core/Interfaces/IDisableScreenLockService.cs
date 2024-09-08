using PreventScreenLock.App.Core.Interfaces;

namespace PreventScreenLock.App.Infrastructure.Services
{
    public enum ScreenLockStatus
    {
        Enabled, Disabled
    }
    public interface IDisableScreenLockService
    {
        event Action<ScreenLockStatus>? LockStatusChanged;
        ScreenLockStatus LockStatus{ get; }
        void Start();
        void Stop();
    }
}