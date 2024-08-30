using PreventScreenLock.App.Core.Interfaces;

namespace PreventScreenLock.App.Core.Extensions
{
    public static class ApiResolverExtensions
    {
        public static bool IsApiAvailable(this IApiResolver apiResolver, string dllName, string functionName)
        {
            return apiResolver.Resolve<Delegate>(dllName, functionName) != null;
        }
    }
}