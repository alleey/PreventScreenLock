using System.Reflection;

namespace PreventScreenLock.App.Presentation
{
    public static class UIConstants
    {
        public static string AppTitle => $"PreventScreenLock";
        public static string AppTitleWithVersion => $"{AppTitle} v{AppVersion}";
        public static string AppVersion => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0.0";
    }
}
