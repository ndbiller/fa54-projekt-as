using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;
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
        public static void Start(TechnicalConceptType conceptType, DatabaseType dbType)
        {
            BasePresenter.SetConceptAndDatabaseType(conceptType, dbType);
            StartProgram();
        }


        private static List<ConsoleKey> AllowedKeys = new List<ConsoleKey>
        {
            ConsoleKey.A,
            ConsoleKey.B,
            ConsoleKey.C,
            ConsoleKey.D,
            ConsoleKey.E,
            ConsoleKey.F,
            ConsoleKey.G,
            ConsoleKey.H,
            ConsoleKey.I,
            ConsoleKey.J
        };

        private static void StartProgram()
        {
            while (true)
            {

                PrintMenu();
                Console.Write($"\nInput: ");
                ConsoleKeyInfo input = Console.ReadKey();

                PrintMenu();
                Console.Write($"\nInput: {input.KeyChar}");

                if (AllowedKeys.Contains(input.Key)
                    && Console.ReadKey().Key == ConsoleKey.Enter)
                    ParseKey(input);

            }
        }


        private static void ParseKey(ConsoleKeyInfo input)
        {
            Console.Clear();
            switch (input.Key)
            {
                case ConsoleKey.A:
                    Console.WriteLine("Show Teams");
                    break;
                case ConsoleKey.B:
                    Console.WriteLine("New Team");
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("Edit Team ");
                    break;
                case ConsoleKey.D:
                    Console.WriteLine("Delete Team");
                    break;
                case ConsoleKey.E:
                    Console.WriteLine("Show Players");
                    break;
                case ConsoleKey.F:
                    Console.WriteLine("New Player");
                    break;
                case ConsoleKey.G:
                    Console.WriteLine("Edit Player");
                    break;
                case ConsoleKey.H:
                    Console.WriteLine("Delete Player");
                    break;
                case ConsoleKey.I:
                    Console.WriteLine("Show Unsigned Players");
                    break;
                case ConsoleKey.J:
                    Console.WriteLine("Close");
                    break;

                default:
                    Console.WriteLine("Invalid Input! Please try again...");
                    break;
            }
            Console.ReadKey();
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("         TEAM-MANAGER-SYSTEM            ");
            Console.WriteLine("========================================");
            Console.WriteLine("    Show Teams            \t(a)         ");
            Console.WriteLine("    New Team              \t(b)         ");
            Console.WriteLine("    Edit Team             \t(c)         ");
            Console.WriteLine("    Delete Team           \t(d)         ");
            Console.WriteLine("========================================");
            Console.WriteLine("    Show Players          \t(e)         ");
            Console.WriteLine("    New Player            \t(f)         ");
            Console.WriteLine("    Edit Player           \t(g)         ");
            Console.WriteLine("    Delete Player         \t(h)         ");
            Console.WriteLine("========================================");
            Console.WriteLine("    Show Unsigned Players \t(i)         ");
            Console.WriteLine("    Close                 \t(j)         ");
        }

    }
}
