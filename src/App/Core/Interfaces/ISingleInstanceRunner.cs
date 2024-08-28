namespace PreventScreenLock.App.Core.Interfaces
{
    interface ISingleInstanceRunner
    {
        void Execute(Action action,
            Action? onExistingInstance = null,
            string mutexName = "PreventScreenLockApp");
    }

}