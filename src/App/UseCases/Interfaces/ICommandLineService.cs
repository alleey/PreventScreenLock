namespace PreventScreenLock.App.UseCases.Interfaces
{
    public interface ICommandLineService
    {
        string GetLaunchPath();
        string[] GetCommandLineArgs();
    }

}