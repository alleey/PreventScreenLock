namespace PreventScreenLock.App.UseCases.Interfaces
{
    public interface IRegistryService
    {
        object? GetValue(string keyName, string valueName);
        void SetValue(string keyName, string valueName, object value);
        void DeleteValue(string keyName, string valueName, bool throwOnMissingValue);
    }
}