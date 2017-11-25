using System;
using System.Runtime.InteropServices;
using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;
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
            // Default = First and MongoDB Connections.
            var conceptType = TechnicalConceptType.First;
            var dbType      = DatabaseType.MongoDB;
            var startGui    = false;

            // Uncomment me if you want debugging console. 
            // NOTE: You'll also need to change output type to console in project properties in order to make it work.
            //args = new[] { "/t:1", "/db:mongo" }; 
            if (args.Length != 0)
            {
                if (!args[0].ToLower().StartsWith("/g")) // We don't want to allocate console when using gui.
                    AllocConsole();
                else
                    startGui = true;
                 

                switch (args[0].ToLower())
                {
                    case "/t:1":
                    case "/g:1":
                        conceptType = TechnicalConceptType.First;
                        break;

                    case "/t:2":
                    case "/g:2":
                        conceptType = TechnicalConceptType.Second;
                        break;

                    case "/?":
                        PrintHelp();
                        return;

                    default:
                        InvalidSyntax();
                        return;
                }

                if (args.Length < 2)
                {
                    InvalidSyntax();
                    return;
                }

                switch (args[1].ToLower())
                {
                    case "/db:mongo":
                        dbType = DatabaseType.MongoDB;
                        break;

                    case "/db:sql":
                        dbType = DatabaseType.SQL;
                        break;

                    default:
                        InvalidSyntax();
                        return;
                }

                if (startGui)
                    GUI.Start(conceptType, dbType);
                else
                    TUI.Start(conceptType, dbType);
            }
            else // -> when you start the app through the windows explorer or from the console without parameters.
            {
                GUI.Start(conceptType, dbType);
            }
        }


        /// <summary>
        /// Prints help to the user when using the application through the console.
        /// </summary>
        private static void PrintHelp()
        {
            Console.WriteLine("\nStarts the team manager app from the console or gui and allows you to choose " +
                              "the concept type.");

            Console.WriteLine("\nTeamManager [/T:[CONCEPT_TYPE] /DB:[DATABASE_TYPE]] | " +
                              "\n            [/G:[CONCEPT_TYPE] /DB:[DATABASE_TYPE]]\n");

            Console.WriteLine("\tFirst Parameter:");
            Console.WriteLine("\t/T:1 \t Starts the app in console/terminal (TUI) mode with concept 1.");
            Console.WriteLine("\t/T:2 \t Starts the app in console/terminal (TUI) mode with concept 2.");
            Console.WriteLine("\t/G:1 \t Starts the app in windows user interface (GUI) mode with concept 1.");
            Console.WriteLine("\t/G:2 \t Starts the app in windows user interface (GUI) mode with concept 2.\n");

            Console.WriteLine("\tSecond Parameter:");
            Console.WriteLine("\t/DB:SQL \t Using relational SQL database.");
            Console.WriteLine("\t/DB:MONGO \t Using no-relational Mongo-DB Database.");

            Console.WriteLine("\n### Example: TeamManager /t:1 /db:mongo ###");
            Console.WriteLine("### Example: TeamManager /g:2 /db:sql ###");

            Console.ReadKey();
        }


        private static void InvalidSyntax()
        {
            Console.WriteLine("Invalid syntax. Use /? parameter to display help.");
            Console.ReadKey();
        }
    }
}
