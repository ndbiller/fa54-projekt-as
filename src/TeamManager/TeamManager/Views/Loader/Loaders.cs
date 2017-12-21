using System;
using System.Threading;
using System.Windows.Forms;
using log4net;
using TeamManager.Utilities;

namespace TeamManager.Views.Loader
{
    /// <summary>
    /// <see cref="Loaders"/> class used for displaying a loader window without freezing the main thread in a thread safe manner.
    /// </summary>
    public class Loaders
    {
        /// <summary> Logger instance of the class <see cref="Loaders"/> </summary>
        private static readonly ILog Log = Logger.GetLogger();

        /// <summary> Tells us which loader is currently running when we want to terminate the thread that runs it. </summary>
        private static LoaderType _loaderType;

        /// <summary> The window to display as loader. </summary>
        private static LoaderWindow _loaderWindow;




        /// <summary>
        /// Starts a loader with the specified loader type and the amount of miliseconds to sleep the main ui thread to visualize work.
        /// </summary>
        /// <param name="loader">The loader type defined by the <see cref="LoaderType"/> enum. </param>
        /// <param name="sleepMiliseconds">When not specified, default will be 500. </param>
        public static void StartLoader(LoaderType loader, int sleepMiliseconds = 500)
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
        /// Stops the specified loader thread with the window handle in order to get the parent window to front.
        /// </summary>
        /// <param name="windowHandle">If you're calling from a Form/Window, pass the <see cref="Form.Handle"/> property. </param>
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
        /// Brings the window focus using the windows api extern methods.
        /// </summary>
        /// <param name="handle">The handle of the window. </param>
        private static void WindowToFront(IntPtr handle)
        {
            NativeMethods.SetForegroundWindow(handle.ToInt32());
        }

    }
}
