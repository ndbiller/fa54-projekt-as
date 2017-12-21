using System;
using System.Collections.Generic;
using TeamManager.Presenters;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Windows
{
    /// <summary>
    /// The <see cref="MainTui"/> where the TUI starts which will allow you do the same things as in gui just without graphic interface.
    /// </summary>
    public class MainTui : IConsoleView
    {
        /// <summary> The presenter of the <see cref="MainTui"/> where all the logic happens. </summary>
        private readonly ConsolePresenter _presenter;

        /// <summary> The allowed keys to receive as input for the wanted action. </summary>
        private readonly List<ConsoleKey> _allowedKeys = new List<ConsoleKey>
        {
            ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E, ConsoleKey.F,
            ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J, ConsoleKey.X
        };




        /// <summary> 
        /// <see cref="MainTui"/> constructor will pass it's own instance to the presenter.
        /// </summary>
        public MainTui()
        {
            _presenter = new ConsolePresenter(this);
        }



        /// <summary>
        /// Displays the menu to select one of the options within the <see cref="_allowedKeys"/> range.
        /// Note that this has to run in infinite loop as it's the entry view of the tui.
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

                if (_allowedKeys.Contains(input.Key)
                    && Console.ReadKey().Key == ConsoleKey.Enter)
                    ParseKeyCommand(input);
            }
        }

        /// <summary>
        /// Every input received by the user will run into a switch statement to require the wanted action.
        /// </summary>
        /// <param name="input">The input received from the user.</param>
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
