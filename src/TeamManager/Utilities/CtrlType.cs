namespace TeamManager.Utilities
{
    /// <summary>
    /// Type defintion for the id's of the <see cref="CtrlType"/> that can occur whenever the console closes.
    /// The event type we get back from the <see cref="NativeMethods.SetConsoleCtrlHandler"/> that registers to the kernal
    /// of the windows api a method callback in <see cref="Program.CloseCallback"/>.
    /// For more information, please see:
    /// <see cref="https://docs.microsoft.com/en-us/windows/console/setconsolectrlhandler"/>
    /// </summary>
    public struct CtrlType
    {
        /// <summary> When CTRL + C event occurs. </summary>
        public static readonly int C        = 0;

        /// <summary> When BREAK event occurs. </summary>
        public static readonly int BREAK    = 1;

        /// <summary> When clicking on the top right X button event occurs. </summary>
        public static readonly int CLOSE    = 2;
        
        /// <summary> When user logs off and applications wrapping up event occurs. </summary>
        public static readonly int LOGOFF   = 5;

        /// <summary> When user shutdown and applications wrapping up event occurs. </summary>
        public static readonly int SHUTDOWN = 6;
    }
}
