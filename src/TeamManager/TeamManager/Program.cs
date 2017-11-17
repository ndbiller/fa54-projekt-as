using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamManager.Database;
using TeamManager.Main.ConceptTypes;
using TeamManager.Models.ResourceData;
using TeamManager.Views;

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
#if !MONGO_DB
            if (args.Length != 0)
            {
                if (!args[0].ToLower().StartsWith("/g")) // We don't want to allocate console when using gui.
                    AllocConsole();

                switch (args[0].ToLower())
                {
                    case "/t:1":
                        TUI.Start(ConceptType.First);
                        break;
                    case "/t:2":
                        TUI.Start(ConceptType.Second);
                        break;
                    case "/g:1":
                        GUI.Start(ConceptType.First);
                        break;
                    case "/g:2":
                        GUI.Start(ConceptType.Second);
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
                GUI.Start(ConceptType.First);
            }
#endif
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
