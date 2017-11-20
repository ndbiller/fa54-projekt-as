using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;
using TeamManager.Presenters;
using TeamManager.Views.Interfaces;

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
        public static void Start(TechnicalConceptType conceptType, DatabaseType dbType)
        {
            BasePresenter.SetConceptAndDatabaseType(conceptType, dbType);
            StartProgram();
        }

        private static ConsolePresenter presenter;

        private static readonly List<ConsoleKey> AllowedKeys = new List<ConsoleKey>
        {
            ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E,
            ConsoleKey.F, ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J
        };

        private static void StartProgram()
        {
            presenter = new ConsolePresenter();

            while (true)
            {
                presenter.PrintMenu();
                Console.Write("\nInput: ");
                ConsoleKeyInfo input = Console.ReadKey();

                presenter.PrintMenu();
                Console.Write($"\nInput: {input.KeyChar}");

                if (AllowedKeys.Contains(input.Key)
                    && Console.ReadKey().Key == ConsoleKey.Enter)
                    ParseKeyCommand(input);
            }
        }


        private static void ParseKeyCommand(ConsoleKeyInfo input)
        {
            Console.Clear();
            switch (input.Key)
            {
                case ConsoleKey.A:
                    Console.WriteLine("--- Show Teams ---");
                    presenter.AllTeams();
                    break;

                case ConsoleKey.B:
                    Console.WriteLine("--- New Team ---");
                    presenter.CreateNewTeam();
                    break;

                case ConsoleKey.C:
                    Console.WriteLine("--- Edit Team ---");
                    presenter.EditTeam();
                    break;

                case ConsoleKey.D:
                    Console.WriteLine("--- Delete Team ---");
                    presenter.DeleteTeam();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine("--- Show Players ---");
                    presenter.AllPlayers();
                    break;

                case ConsoleKey.F:
                    Console.WriteLine("--- New Player ---");
                    presenter.CreateNewPlayer();
                    break;

                case ConsoleKey.G:
                    Console.WriteLine("--- Edit Player ---");
                    presenter.EditPlayer();
                    break;

                case ConsoleKey.H:
                    Console.WriteLine("--- Delete Player ---");
                    presenter.DeletePlayer();
                    break;

                case ConsoleKey.I:
                    Console.WriteLine("--- Show Unsigned Players ---");
                    presenter.ShowUnsignedPlayers();
                    break;

                case ConsoleKey.J:
                    Console.WriteLine("--- Close ---");
                    presenter.Close();
                    break;

                default:
                    Console.WriteLine("Invalid Input! Please try again...");
                    break;
            }
            Console.ReadKey();
        }


    }
}
