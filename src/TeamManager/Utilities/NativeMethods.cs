using System.Security;
using System.Runtime.InteropServices;

namespace TeamManager.Utilities
{
    /// <summary>
    /// Windows api native methods wrapped into a class with suppress unmanaged code security in order to make the compiler happy.
    /// </summary>
    [ComVisible(false), SuppressUnmanagedCodeSecurity]
    internal class NativeMethods
    {
        /// <summary>
        /// Allows to allocate console view even if the project configurations set to windows forms as output.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();


        /// <summary>
        /// Frees console allocation.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int FreeConsole();


        /// <summary>
        /// Brings window focus to the front with the handle of the window.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(int hWnd);
    }
}
