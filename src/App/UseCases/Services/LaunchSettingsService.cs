using PreventScreenLock.App.UseCases.Interfaces;
using PreventScreenLock.App.Core.Interfaces;

public class LaunchSettingsService : ILaunchSettings
{
    private const string RegistryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
    private const string AppName = "PreventScreenLockApp";
    private const string ArgMinimized = "--minimized";
    private const string ArgAutoDisable = "--autodisable";

    private readonly IRegistryService _registryService;
    private readonly ICommandLineService _commandLineService;

    public bool AutoLaunch { get; set; }
    public bool StartMinimized { get; set; }
    public bool AutoDisable { get; set; }

    public LaunchSettingsService(IRegistryService registryService, ICommandLineService commandLineService)
    {
        _registryService = registryService;
        _commandLineService = commandLineService;
        LoadSettings();
    }

    public void SaveSettings()
    {
        if (AutoLaunch)
        {
            var commandLine = $"\"{_commandLineService.GetLaunchPath()}\"";
            if (StartMinimized) commandLine += " " + ArgMinimized;
            if (AutoDisable) commandLine += " " + ArgAutoDisable;

            _registryService.SetValue(RegistryKeyPath, AppName, commandLine);
        }
        else
        {
            _registryService.DeleteValue(RegistryKeyPath, AppName, false);
        }
    }

    public void LoadSettings()
    {
        string value = (_registryService.GetValue(RegistryKeyPath, AppName) as string) ?? "";

        AutoLaunch = !string.IsNullOrEmpty(value);
        if (AutoLaunch)
        {
            StartMinimized = value.Contains(ArgMinimized);
            AutoDisable = value.Contains(ArgAutoDisable);
        }

        // Load command-line arguments
        string[] args = _commandLineService.GetCommandLineArgs();
        StartMinimized = StartMinimized || Array.Exists(args, arg => arg.Equals(ArgMinimized, StringComparison.OrdinalIgnoreCase));
        AutoDisable = AutoDisable || Array.Exists(args, arg => arg.Equals(ArgAutoDisable, StringComparison.OrdinalIgnoreCase));
    }
}
