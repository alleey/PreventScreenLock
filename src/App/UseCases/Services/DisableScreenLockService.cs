using System.Timers;
using PreventScreenLock.App.Utilities;
using Timer = System.Timers.Timer;

namespace PreventScreenLock.App.Infrastructure.Services
{
    public class DisableScreenLockService : IDisableScreenLockService
    {
        private const int DefaultTimerInterval = 120000;
        private readonly int _updateInterval;
        private Timer? _timer;
        private bool _isRunning;

        public DisableScreenLockService(int updateInterval = DefaultTimerInterval)
        {
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
                WinApi.SetThreadExecutionState(WinApi.ES_CONTINUOUS | WinApi.ES_SYSTEM_REQUIRED | WinApi.ES_DISPLAY_REQUIRED);
            }
            else
            {
                WinApi.SetThreadExecutionState(WinApi.ES_CONTINUOUS);
            }
        }
    }

}