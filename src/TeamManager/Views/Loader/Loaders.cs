using System;
using System.Drawing;
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
        private static LoaderType _currentLoaderRunning;

        /// <summary> Sets a reference to the <see cref="ParentWindow"/> in order to display the loader in the center location of the window.</summary>
        public static Form ParentWindow { get; set; }

        /// <summary> The window to display as <see cref="LoaderType.Loader"/>. </summary>
        private static LoaderWindow _loaderWindow;

        /// <summary> The window to display as <see cref="LoaderType.SplashScreen"/>. </summary>
        private static SplashWindow _splashWindow;




        /// <summary>
        /// Starts a loader with the specified loader type and the amount in miliseconds to sleep the main thread 
        /// in order to visualize work.
        /// </summary>
        /// <param name="loader">The loader type defined by the <see cref="LoaderType"/> enum. </param>
        /// <param name="sleepMiliseconds">When not specified, default will be 500. </param>
        public static void StartLoader(LoaderType loader, int sleepMiliseconds = 500)
        {
            _currentLoaderRunning = loader;

            switch (loader)
            {
                case LoaderType.Loader: @default:
                    InvokeLoader(_loaderWindow ?? (_loaderWindow = new LoaderWindow()));
                    break;

                case LoaderType.SplashScreen:
                    InvokeLoader(_splashWindow ?? (_splashWindow = new SplashWindow()));
                    break;

                default:
                    goto @default;
            }

            Thread.Sleep(sleepMiliseconds);
        }

        /// <summary>
        /// Stops the specified loader thread with the window handle in order to get the parent window to front.
        /// </summary>
        /// <param name="windowHandle">If you're calling from a Form/Window, pass the <see cref="Form.Handle"/> property. </param>
        public static void StopLoader(IntPtr windowHandle)
        {
            switch (_currentLoaderRunning)
            {
                case LoaderType.Loader: @default:
                    Log.Info("Stopping loader of type LoaderType.Loader.");
                    _loaderWindow?.InvokeSafe(() => _loaderWindow.Close());
                    break;

                case LoaderType.SplashScreen:
                    Log.Info("Stopping loader of type LoaderType.SplashScreen.");
                    _splashWindow?.InvokeSafe(() => _splashWindow.Close());
                    break;

                default:
                    goto @default;
            }
            
            WindowToFront(windowHandle);
        }



        /// <summary>
        /// Running loader window on a separate thread so the main ui thread will be free when displaying another window.
        /// </summary>
        /// <param name="window"></param>
        private static void InvokeLoader(Form window)
        {
            if (window.Visible) return;

            window.LostFocus -= null;
            window.LostFocus += (sender, e) => window.Focus();

            if (ParentWindow != null && _currentLoaderRunning != LoaderType.SplashScreen)
            {
                window.StartPosition = FormStartPosition.Manual;

                int posX = ParentWindow.Location.X + ParentWindow.Width / 2 - window.Width / 2;
                int posY = ParentWindow.Location.Y + ParentWindow.Height / 2 - window.Height / 2;
                window.Location = new Point(posX, posY);
            }

            try
            {
                Thread thread = new Thread(() => window.ShowDialog());
                thread.Start();
                Log.Info($"Running loader of type {_currentLoaderRunning} on thread id => {thread.ManagedThreadId}.");
            }
            catch (Exception e)
            {
                Log.Error($"Failed to run loader of type {_currentLoaderRunning} on new thread." + e);
            }
        }

        /// <summary>
        /// Brings the window focus using the windows api extern methods.
        /// </summary>
        /// <param name="handle">The handle of the window. </param>
        private static void WindowToFront(IntPtr handle)
        {
            NativeMethods.SetForegroundWindow(handle);
        }

    }
}
