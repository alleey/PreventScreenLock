namespace PreventScreenLock.App.Infrastructure.Services
{
    public interface IDisableScreenLockService
    {
        bool IsLocked { get; }
        void Start();
        void Stop();
    }
}