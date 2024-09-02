using System.Reflection;

namespace PreventScreenLock.App.Presentation
{
    public static class UIConstants
    {
        public static string AppTitleShort => $"PreventScreenLock";
        public static string AppTitle => $"{AppTitleShort} v{AppVersion}";
        public static string AppVersion => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0.0";
    }
}
