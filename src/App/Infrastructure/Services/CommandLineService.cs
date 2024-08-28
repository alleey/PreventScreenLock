using PreventScreenLock.App.UseCases.Interfaces;

namespace PreventScreenLock.App.Infrastructure.Services
{
    public class CommandLineService : ICommandLineService
    {
        public string[] GetCommandLineArgs()
        {
            return Environment.GetCommandLineArgs();
        }

        public string GetLaunchPath()
        {
            return Environment.ProcessPath ?? "";
        }
    }

}