using System;
using System.Collections.Generic;
using TeamManager.Presenters;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Windows
{
    /// <summary>
    /// Opening the Team Manager app in console mode.
    /// </summary>
    public class MainTui : IConsoleView
    {

        private readonly ConsolePresenter _presenter;

        private readonly List<ConsoleKey> AllowedKeys = new List<ConsoleKey>
        {
            ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E,
            ConsoleKey.F, ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J,
            ConsoleKey.X
        };


        public MainTui()
        {
            _presenter = new ConsolePresenter(this);
        }

        /// <summary>
        /// Main entry point for the console application.
        /// </summary>
        public void Show()
        {
            while (true)
            {
                _presenter.PrintMenu();
                Console.Write("\nInput: ");
                ConsoleKeyInfo input = Console.ReadKey();

                _presenter.PrintMenu();
                Console.Write($"\nInput: {input.KeyChar}");

                if (AllowedKeys.Contains(input.Key)
                    && Console.ReadKey().Key == ConsoleKey.Enter)
                    ParseKeyCommand(input);
            }
        }


        private void ParseKeyCommand(ConsoleKeyInfo input)
        {
            Console.Clear();
            switch (input.Key)
            {
                case ConsoleKey.A:
                    Console.WriteLine("--- Show Teams ---");
                    _presenter.AllTeams();
                    break;

                case ConsoleKey.B:
                    Console.WriteLine("--- New Team ---");
                    _presenter.CreateNewTeam();
                    break;

                case ConsoleKey.C:
                    Console.WriteLine("--- Edit Team ---");
                    _presenter.EditTeam();
                    break;

                case ConsoleKey.D:
                    Console.WriteLine("--- Delete Team ---");
                    _presenter.DeleteTeam();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine("--- Show Players ---");
                    _presenter.AllPlayers();
                    break;

                case ConsoleKey.F:
                    Console.WriteLine("--- New Player ---");
                    _presenter.CreateNewPlayer();
                    break;

                case ConsoleKey.G:
                    Console.WriteLine("--- Edit Player ---");
                    _presenter.EditPlayer();
                    break;

                case ConsoleKey.H:
                    Console.WriteLine("--- Delete Player ---");
                    _presenter.DeletePlayer();
                    break;

                case ConsoleKey.I:
                    Console.WriteLine("--- Show Unsigned Players ---");
                    _presenter.ShowUnsignedPlayers();
                    break;

                case ConsoleKey.J:
                    Console.WriteLine("--- Show Team Players ---");
                    _presenter.ShowTeamPlayers();
                    break;

                case ConsoleKey.X:
                    Console.WriteLine("--- Close ---");
                    _presenter.Close();
                    break;

                default:
                    Console.WriteLine("Invalid Input! Please try again...");
                    break;
            }

            Console.ReadKey();
        }


    }
}
