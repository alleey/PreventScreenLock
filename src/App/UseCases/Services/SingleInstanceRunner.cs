using PreventScreenLock.App.Core.Interfaces;

namespace PreventScreenLock.App.UseCases.Services
{
    class SingleInstanceRunner : ISingleInstanceRunner
    {
        public void Execute(Action action,
            Action? onExistingInstance = null,
            string mutexName = "PreventScreenLockApp")
        {
            using (var mutex = new Mutex(true, mutexName, out var createdNew))
            {
                if (createdNew)
                {
                    action();
                    return;
                }
            }

            onExistingInstance?.Invoke();
        }
    }

}