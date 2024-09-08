using PreventScreenLock.App.Infrastructure.Services;

namespace PreventScreenLock.App.Core.Extensions
{
    public static class DisableScreenLockServiceExtensions
    {
        public static bool IsScreenLockEnabled(this IDisableScreenLockService service) 
            => service.LockStatus == ScreenLockStatus.Enabled;

        public static bool IsScreenLockDisabled(this IDisableScreenLockService service) 
            => service.LockStatus == ScreenLockStatus.Disabled;
    }
}