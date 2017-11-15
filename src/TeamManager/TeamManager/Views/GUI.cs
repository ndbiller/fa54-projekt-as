using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamManager.Main.ConceptTypes;
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
        public static void Start(ConceptType type)
        {
            BasePresenter.SetConceptType(type);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

}
