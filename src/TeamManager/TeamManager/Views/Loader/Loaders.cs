using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using log4net;
using TeamManager.Utilities;

namespace TeamManager.Views.Loader
{
    /// <summary>
    /// Loaders class used for display loaders statically and thread safe while doing long proccessing.
    /// </summary>
    public class Loaders
    {
        private static readonly ILog Log = Logger.GetLogger();

        private static LoaderType _loaderType;

        private static LoaderWindow _loaderWindow;


        /// <summary>
        /// Starting loader with specified loader type and the amount of miliseconds to sleep the main ui thread to visualize work.
        /// </summary>
        /// <param name="loader"></param>
        /// <param name="sleepMiliseconds"></param>
        public static void StartLoader(LoaderType loader, int sleepMiliseconds)
        {
            _loaderType = loader;

            switch (loader)
            {
                case LoaderType.Loader:
                    Log.Info("Starting loader of type LoaderType.Loader.");
                    if (_loaderWindow == null)
                        LoadWindowOnThread(_loaderWindow = new LoaderWindow());
                    break;

                case LoaderType.SplashScreen:
                    Log.Info("Starting loader of type LoaderType.SplashScreen.");

                    break;
            }

            Thread.Sleep(sleepMiliseconds);
        }

        /// <summary>
        /// Stops specified loader thread with the window handle in order to get the parent window to front.
        /// </summary>
        /// <param name="windowHandle"></param>
        public static void StopLoader(IntPtr windowHandle)
        {
            if (_loaderWindow == null) return;

            switch (_loaderType)
            {
                case LoaderType.Loader:
                    Log.Info("Stopping loader of type LoaderType.Loader.");
                    if (_loaderWindow.InvokeRequired)
                        _loaderWindow.Invoke(new MethodInvoker(()=> _loaderWindow.Close()));
                    break;

                case LoaderType.SplashScreen:
                    Log.Info("Stopping loader of type LoaderType.SplashScreen.");

                    break;
            }

            WindowToFront(windowHandle);
        }

        /// <summary>
        /// Running loader window on a separate thread so the main ui thread will be free when displaying another window.
        /// </summary>
        /// <param name="window"></param>
        private static void LoadWindowOnThread(Form window)
        {
            Log.Info("Running loader on different thread.");

            window.LostFocus += (sender, e) => window.Focus();

            new Thread(() => window.ShowDialog()).Start();
        }

        /// <summary>
        /// Brings the window to front.
        /// </summary>
        /// <param name="handle"></param>
        private static void WindowToFront(IntPtr handle)
        {
            NativeMethods.SetForegroundWindow(handle.ToInt32());
        }

    }
}
