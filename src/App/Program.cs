using Microsoft.Extensions.DependencyInjection;
using PreventScreenLock.App.UseCases.Interfaces;
using PreventScreenLock.App.UseCases.Services;
using PreventScreenLock.App.Core.Interfaces;
using PreventScreenLock.App.Infrastructure.Services;
using PreventScreenLock.App.Core.Extensions;
using PreventScreenLock.App.Presentation;

namespace PreventScreenLock.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var apiResolver = serviceProvider.GetRequiredService<IApiResolver>(); 
            if (!apiResolver.IsSetThreadExecutionStateAvailable())
            {
                MessageBox.Show(
                    "Application does not support this version of Windows.",
                    UIConstants.AppTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Resolve the main form and run the application
            var singleInstanceRunner = serviceProvider.GetRequiredService<ISingleInstanceRunner>();

            singleInstanceRunner.Execute(() =>
            {
                ApplicationConfiguration.Initialize();
                Application.Run(serviceProvider.GetRequiredService<MainForm>());
            },
            onExistingInstance: () => {
                // The application is already running
                MessageBox.Show(
                    "Another instance of the application is already running. " +
                    "Please check system tray to bring up the existing application.",
                    UIConstants.AppTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            });
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Core services
            services.AddSingleton<ILaunchSettings, LaunchSettingsService>();
            services.AddSingleton<ISingleInstanceRunner, SingleInstanceRunner>();
            services.AddSingleton<IDisableScreenLockService, DisableScreenLockService>();
            services.AddSingleton<INotificationService, NotificationService>();

            // Infrastructure services
            services.AddSingleton<IRegistryService, RegistryService>();
            services.AddSingleton<ICommandLineService, CommandLineService>();
            services.AddSingleton<IApiResolver, ApiResolver>();

            // Presentation layer - forms
            services.AddTransient<MainForm>();
            services.AddTransient<SettingsForm>();
            services.AddTransient<Func<SettingsForm>>(provider =>
            {
                return () => provider.GetRequiredService<SettingsForm>();
            });
        }
    }
}