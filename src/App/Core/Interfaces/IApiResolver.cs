namespace PreventScreenLock.App.Core.Interfaces
{
    public interface IApiResolver
    {
        T? Resolve<T>(string dllName, string functionName) where T : Delegate;
    }

    public static class ApiResolverExtensions
    {
        public static bool IsApiAvailable(this IApiResolver apiResolver, string dllName, string functionName) 
            => apiResolver.Resolve<Delegate>(dllName, functionName) != null;
    }
}