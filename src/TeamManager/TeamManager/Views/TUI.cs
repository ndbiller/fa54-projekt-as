using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Main.ConceptTypes;
using TeamManager.Presenters;
using TeamManager.Views.Interfaces;
using presenter = TeamManager.Presenters.ConsolePresenter;

namespace TeamManager.Views
{
    /// <summary>
    /// Opening the Team Manager app in console mode.
    /// </summary>
    public class TUI : IConsoleView
    {
        /// <summary>
        /// Main entry point for the console application.
        /// </summary>
        public static void Start(DatabaseType dbType, ConceptType conceptType)
        {
            BasePresenter.SetConceptAndDatabaseType(conceptType, dbType);
            StartProgram();
        }


        private static void StartProgram()
        {
            // TODO: Implement console.
            Console.WriteLine("Hello from console");
            Console.ReadKey();
        }
    }
}
