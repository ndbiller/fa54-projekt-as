using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static void Start(TechnicalConceptType conceptType, DatabaseType dbType)
        {
            BasePresenter.SetConceptAndDatabaseType(conceptType, dbType);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

}
