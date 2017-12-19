using System;
using System.Windows.Forms;
using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;
using TeamManager.Presenters;
using TeamManager.Views.Forms;

namespace TeamManager.Views
{
    /// <summary>
    /// Opening the Team Manager app in user interface mode(GUI).
    /// </summary>
    public class GUI
    {
        /// <summary>
        /// Main entry point for the GUI application.
        /// </summary>
        [STAThread]
        public static void Show()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

}
