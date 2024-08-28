namespace PreventScreenLock.App.Core.Interfaces
{
    public interface ILaunchSettings
    {
        bool AutoLaunch { get; set; }
        bool StartMinimized { get; set; }
        bool AutoDisable { get; set; }

        void SaveSettings();
        void LoadSettings();
    }
}