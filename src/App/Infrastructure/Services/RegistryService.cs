using Microsoft.Win32;
using PreventScreenLock.App.UseCases.Interfaces;

namespace PreventScreenLock.App.Infrastructure.Services
{
    public class RegistryService : IRegistryService
    {
        public object? GetValue(string keyName, string valueName)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(keyName))
            {
                return key?.GetValue(valueName);
            }
        }

        public void SetValue(string keyName, string valueName, object value)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                key?.SetValue(valueName, value);
            }
        }

        public void DeleteValue(string keyName, string valueName, bool throwOnMissingValue)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                key?.DeleteValue(valueName, throwOnMissingValue);
            }
        }
    }

}