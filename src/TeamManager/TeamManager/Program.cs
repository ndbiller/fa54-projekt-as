using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamManager.Utilities;

namespace TeamManager
{
    static class Program
    {
        /// <summary>
        /// Allows Windows Forms application to start also in console mode.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        /// <summary>
        /// Main interance of the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (!args[0].ToLower().StartsWith("/g")) // We don't want to allocate console when using gui.
                    AllocConsole();

                switch (args[0].ToLower())
                {
                    case "/t:1":
                        InitializeDataStructure(ConceptType.First);
                        TUI.Start();
                        break;
                    case "/t:2":
                        InitializeDataStructure(ConceptType.Second);
                        TUI.Start();
                        break;
                    case "/g:1":
                        InitializeDataStructure(ConceptType.First);
                        GUI.Start();
                        break;
                    case "/g:2":
                        InitializeDataStructure(ConceptType.Second);
                        GUI.Start();
                        break;
                    case "/?":
                        PrintHelp();
                        break;
                    default:
                        Console.WriteLine("Invalid syntax. Use /? parameter to display help.");
                        Console.ReadKey();
                        break;
                }
            }
            else // -> when you start the app through the windows explorer or from the console without parameters.
            {
                InitializeDataStructure(ConceptType.First); // Default = First concept type.
                GUI.Start();
            }
        }


        /// <summary>
        /// Initialize the data structure from the database.
        /// </summary>
        /// <param name="conceptType"></param>
        private static void InitializeDataStructure(ConceptType conceptType)
        {
            // In this part we initializing our data structure from the db depending on the concept type.
            // TODO: Implement data structure.
            switch (conceptType)
            {
                case ConceptType.First:
                    break;

                case ConceptType.Second:
                    break;
            }
        }


        /// <summary>
        /// Prints help to the user when using the application through the console.
        /// </summary>
        private static void PrintHelp()
        {
            Console.WriteLine("\nStarts the team manager app from the console or gui and allows you choose " +
                              "the concept type.");

            Console.WriteLine("\n\nTeamManager [/T:[CONCEPT_TYPE]] | [/G:[CONCEPT_TYPE]]\n");
            Console.WriteLine("\t/T:1 \t Starts the app in console/terminal (TUI) mode with concept 1.");
            Console.WriteLine("\t/T:2 \t Starts the app in console/terminal (TUI) mode with concept 2.");
            Console.WriteLine("\t/G:1 \t Starts the app in windows user interface (GUI) mode with concept 1.");
            Console.WriteLine("\t/G:2 \t Starts the app in windows user interface (GUI) mode with concept 2.");

            Console.WriteLine("\nExample: TeamManager /t:1");

            Console.ReadKey();
        }
    }
}
