using System;
using System.Windows.Forms;
using TeamManager.Views.Windows;

namespace TeamManager.Views
{
    /// <summary> Graphic User Interface Class. </summary>
    public class Gui
    {
        /// <summary> Starts the Team Manager application in user interface(gui) mode. </summary>
        [STAThread]
        public static void Show()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }

}
