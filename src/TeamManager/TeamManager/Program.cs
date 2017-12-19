using System;
using System.Runtime.InteropServices;
using log4net;
using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;
using TeamManager.Presenters;
using TeamManager.Utilities;
using TeamManager.Views;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[assembly: Fody.ConfigureAwait(false)]

namespace TeamManager
{
    static class Program
    {
        /// <summary> Logger instance of the class <see cref="Program"/> </summary>
        private static readonly ILog Log = Logger.GetLogger();

        /// <summary> Unique session id of the application. </summary>
        private static readonly Guid SessionId = Guid.NewGuid();


        /// <summary>
        /// The main father entrance for the application.
        /// We can define in the beginning of the application the TechnicalConcept(1,2,1mt,2mt), Database type and GUI or TUI. 
        /// Checks whether the user passed arguments to the console and initialize the application with the wanted data.
        /// </summary>
        /// <param name="args">The arguements that being passed to the executeable through the console.</param>
        static void Main(string[] args)
        {
            Log.Info($"##### Application started. Session ID => {SessionId} #####");

            // Default = FirstMt and MongoDB Connections.
            var conceptType = Defaults.TechnicalConceptType;
            var dbType      = Defaults.DatabaseType;
            var startGui    = false;

            // Uncomment me if you want debugging console. 
            // NOTE: You'll also need to change output type to console in project properties in order to make it work.
            //args = new[] { "/t:1", "/db:mongo" }; 
            if (args.Length != 0)
            {
                if (!args[0].ToLower().StartsWith("/g")) // We don't want to allocate console when using gui.
                    NativeMethods.AllocConsole();
                else
                    startGui = true;
                 

                switch (args[0].ToLower())
                {
                    case "/t:1":
                    case "/g:1":
                        Log.Info("Using TechnicalConcept1.");
                        conceptType = TechnicalConceptType.First;
                        break;

                    case "/t:2":
                    case "/g:2":
                        Log.Info("Using TechnicalConcept2.");
                        conceptType = TechnicalConceptType.Second;
                        break;

                    case "/t-mt:1":
                    case "/g-mt:1":
                        Log.Info("Using multi-threaded TechnicalConcept1.");
                        conceptType = TechnicalConceptType.FirstMt;
                        break;

                    case "/t-mt:2":
                    case "/g-mt:2":
                        Log.Info("Using multi-threaded TechnicalConcept2.");
                        conceptType = TechnicalConceptType.SecondMt;
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
                        Log.Info("Using mongo-db as database.");
                        dbType = DatabaseType.Mongo;
                        break;

                    case "/db:sql":
                        Log.Info("Using sql as database.");
                        dbType = DatabaseType.Sql;
                        break;

                    default:
                        InvalidSyntax();
                        return;
                }


                BasePresenter.SetConceptAndDatabaseType(conceptType, dbType);

                if (startGui)
                {
                    Log.Info("Starting GUI...");
                    Gui.Show();
                }
                else
                {
                    Log.Info("Starting TUI...");
                    Tui.Show();
                }
            }
            else // -> when you start the app through the windows explorer or from the console without parameters.
            {
                Log.Info("Starting GUI with default configuration.");
                BasePresenter.SetConceptAndDatabaseType(conceptType, dbType);
                Gui.Show();
            }

            Log.Info($"##### Application Closed. Session ID => {SessionId} #####");
        }


        /// <summary> Prints help to the user when using the application through the console. </summary>
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

            Console.WriteLine("\t/T-MT:1  Starts the app in console/terminal (TUI) mode using multi-threaded calls with concept 1.");
            Console.WriteLine("\t/T-MT:2  Starts the app in console/terminal (TUI) mode using multi-threaded calls with concept 2.");
            Console.WriteLine("\t/G-MT:1  Starts the app in windows user interface (GUI) mode using multi-threaded calls with concept 1.");
            Console.WriteLine("\t/G-MT:2  Starts the app in windows user interface (GUI) mode using multi-threaded calls with concept 2.\n");

            Console.WriteLine("\tSecond Parameter:");
            Console.WriteLine("\t/DB:SQL \t Using relational SQL database.");
            Console.WriteLine("\t/DB:MONGO \t Using no-relational Mongo-DB Database.");

            Console.WriteLine("\n### Examples: ###\n" +
                              "TeamManager /t:1 /db:mongo\n" +
                              "TeamManager /t-mt:1 /db:mongo\n" +
                              "TeamManager /g:2 /db:sql\n" +
                              "TeamManager /g-mt:2 /db:sql\n");

            Console.ReadKey();
        }


        /// <summary> Prints out invalid syntax when invalid syntax received. </summary>
        private static void InvalidSyntax()
        {
            Log.Info("Received invalid syntax from console.");
            Console.WriteLine("Invalid syntax. Use /? parameter to display help.");
            Console.ReadKey();
        }
    }
}
