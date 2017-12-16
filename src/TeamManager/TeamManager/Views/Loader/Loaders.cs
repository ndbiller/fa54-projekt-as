using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TeamManager.Views.Loader
{
    /// <summary>
    /// Loaders class used for display loaders statically and thread safe while doing long proccessing.
    /// </summary>
    public class Loaders
    {
        /// <summary>
        /// Used for bringing form to front with the handle of the form.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        private static LoaderType _loaderType;

        private static LoaderForm _loaderForm;



        /// <summary>
        /// Starting loader with specified loader type and the amount of miliseconds to sleep the main ui thread to visualize work.
        /// </summary>
        /// <param name="loader"></param>
        public static void StartLoader(LoaderType loader, int sleepMiliseconds)
        {
            _loaderType = loader;

            switch (loader)
            {
                case LoaderType.Loader:
                    if (_loaderForm == null)
                        LoadFormOnThread(_loaderForm = new LoaderForm());
                    break;

                case LoaderType.SplashScreen:
                    break;
            }

            Thread.Sleep(sleepMiliseconds);
        }

        /// <summary>
        /// Stops specified loader thread with the form handle in order to get the parent form to front.
        /// </summary>
        /// <param name="formHandle"></param>
        public static void StopLoader(IntPtr formHandle)
        {
            if (_loaderForm == null) return;

            switch (_loaderType)
            {
                case LoaderType.Loader:
                    if (_loaderForm.InvokeRequired)
                        _loaderForm.Invoke(new MethodInvoker(()=> _loaderForm.Close()));
                    break;

                case LoaderType.SplashScreen:

                    break;
            }

            WindowToFront(formHandle);
        }

        /// <summary>
        /// Running loader form on a separate thread so the main ui thread will be free when displaying another form.
        /// </summary>
        /// <param name="form"></param>
        private static void LoadFormOnThread(Form form)
        {
            form.LostFocus += (sender, e) => form.Focus();

            new Thread(() => form.ShowDialog()).Start();
        }

        /// <summary>
        /// Brings the window to front.
        /// </summary>
        /// <param name="handle"></param>
        private static void WindowToFront(IntPtr handle)
        {
            SetForegroundWindow(handle.ToInt32());
        }

    }
}
