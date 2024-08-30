using PreventScreenLock.App.Core.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace PreventScreenLock.App.Infrastructure.Services
{
    public class ApiResolver : IApiResolver
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        public T? Resolve<T>(string dllName, string functionName) where T : Delegate
        {
            IntPtr libraryHandle = LoadLibrary(dllName);
            if (libraryHandle == IntPtr.Zero)
            {
                return null;
            }

            IntPtr procAddress = GetProcAddress(libraryHandle, functionName);
            if (procAddress == IntPtr.Zero)
            {
                return null;
            }

            return Marshal.GetDelegateForFunctionPointer<T>(procAddress);
        }
    }
}