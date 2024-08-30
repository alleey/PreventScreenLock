using PreventScreenLock.App.Core.Extensions;
using PreventScreenLock.App.Core.Interfaces;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PreventScreenLock.App.Infrastructure.Services
{
    internal static class SetThreadExecutionStateFlags
    {
        public const uint ES_CONTINUOUS = 0x80000000;
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;
        public const uint ES_DISPLAY_REQUIRED = 0x00000002;
    }

    public class DisableScreenLockService : IDisableScreenLockService
    {
        private const int DefaultTimerInterval = 120000;

        private readonly SetThreadExecutionStateDelegate? _setThreadExecutionStateDelegate;
        private readonly int _updateInterval;
        private Timer? _timer;
        private bool _isRunning;

        public DisableScreenLockService(IApiResolver apiResolver, int updateInterval = DefaultTimerInterval)
        {
            _setThreadExecutionStateDelegate = apiResolver.GetSetThreadExecutionStateDelegate();
            _updateInterval = updateInterval;
        }

        public bool IsLocked => _isRunning;

        public void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                _timer = new Timer(DefaultTimerInterval);
                _timer.Elapsed += OnTimerElapsed;
                _timer.Start();
                UpdateScreenLock();
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                _timer?.Stop();
                _timer?.Dispose();
                _timer = null;
                UpdateScreenLock();
            }
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            UpdateScreenLock();
        }

        private void UpdateScreenLock()
        {
            if (_isRunning)
            {
                _setThreadExecutionStateDelegate?.Invoke(SetThreadExecutionStateFlags.ES_CONTINUOUS
                                                         | SetThreadExecutionStateFlags.ES_SYSTEM_REQUIRED
                                                         | SetThreadExecutionStateFlags.ES_DISPLAY_REQUIRED);
            }
            else
            {
                _setThreadExecutionStateDelegate?.Invoke(SetThreadExecutionStateFlags.ES_CONTINUOUS);
            }
        }
    }
}