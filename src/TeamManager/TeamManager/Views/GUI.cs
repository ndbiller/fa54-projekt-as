using System;
using System.Windows.Forms;
using TeamManager.Views.Windows;

namespace TeamManager.Views
{
    /// <summary>
    /// Opening the Team Manager app in user interface mode(GUI).
    /// </summary>
    public class Gui
    {
        /// <summary>
        /// Main entry point for the GUI application.
        /// </summary>
        [STAThread]
        public static void Show()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }

}
