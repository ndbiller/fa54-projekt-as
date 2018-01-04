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
        internal static extern bool AllocConsole();


        /// <summary>
        /// Frees console allocation.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int FreeConsole();


        /// <summary>
        /// Catches the close event chain of the windows api when using console in order to do some wrapping before 
        /// terminating the application.
        /// Note that it can only catch the CTRL_CLOSE(eventType = 2) event when clicking the X button on the right top.
        /// </summary>
        /// <param name="callback">The method to call when the event occurs. </param>
        /// <param name="add">Whether to add it to the windows messages api chain or not. </param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetConsoleCtrlHandler(ConsoleClosedHandler callback, bool add);


        /// <summary>
        /// Brings window focus to the front with the handle of the window.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern int SetForegroundWindow(int hWnd);
    }

    /// <summary>
    /// Handler that will be used to catch a callback for the console closed event since we need to hook it to the windows api
    /// if someone click on the right top exit button.
    /// </summary>
    /// <param name="eventType">The close event type. </param>
    /// <returns></returns>
    public delegate bool ConsoleClosedHandler(int eventType);

}
