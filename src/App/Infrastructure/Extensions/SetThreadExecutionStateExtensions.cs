using PreventScreenLock.App.Core.Interfaces;

namespace PreventScreenLock.App.Core.Extensions
{
    public delegate uint SetThreadExecutionStateDelegate(uint esFlags);

    public static class SetThreadExecutionStateExtensions
    {
        public static bool IsSetThreadExecutionStateAvailable(this IApiResolver apiResolver)
            => apiResolver.GetSetThreadExecutionStateDelegate() != null;

        public static SetThreadExecutionStateDelegate? GetSetThreadExecutionStateDelegate(this IApiResolver apiResolver)
            => apiResolver.Resolve<SetThreadExecutionStateDelegate>("kernel32.dll", "SetThreadExecutionState");
    }
}