using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using TeamManager.Database;
using TeamManager.Models.Strategy;
using TeamManager.Presenters;
using TeamManager.Utilities;
using TeamManager.Views;
using System.IO;

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

        /// <summary> Event handler for the console closed event to call the <see cref="CloseCallback"/> method so it doesn't get garbage collected. </summary>
        private static event ConsoleClosedHandler ClosedHandler;

        /// <summary> The default flag for specifying whether to use <see cref="Gui"/> or <see cref="Tui"/>. </summary>
        private static bool _startGui = true;

        /// <summary> The default <see cref="DatabaseType"/> that is used for initializing the wanted <see cref="IDataLayer"/>. </summary>
        private static DatabaseType _dbType = Defaults.DatabaseType;

        /// <summary> The default <see cref="StrategyType"/> that is used for initializing the wanted <see cref="IStrategy"/>. </summary>
        private static StrategyType _strategyType = Defaults.StrategyType;

        /// <summary> The allowed arguments that are acceptable to be pass to the executeable through the console for specifying different configurations. </summary>
        private static readonly List<string> AllowedArgs = new List<string>
        {
            "/t", "/g",
            "/s:1", "/s:2", "/s-mt:1", "/s-mt:2",
            "/db:mongo", "/db:sql",
            "/?", "/h", "--help"
        };




        /// <summary>
        /// The main father entrance for the application.
        /// We can define in the beginning of the application the Strategy(asc, desc, ascMt, descMt), Database type and GUI or TUI. 
        /// Checks whether the user passed arguments to the console and initialize the application with the wanted data.
        /// </summary>
        /// <param name="args">The arguements that are being passed to the executeable through the console. </param>
        static void Main(string[] args)
        {
            ValidateConfigurationFile();
            Log.Info($"##### Application started with Session ID => {SessionId} #####");

            // Uncomment me if you want debugging console arguments. 
            // NOTE: You'll also need to change output type in project configuration to console so debugging will work.
            //args = new[] { "/g", "/s:1", "/db:sql" };
            if (args.Length > 0)
                if (!ParseArgs(args)) { CloseCallback(CtrlType.CLOSE); return; }

            BasePresenter.SetStrategyAndDatabaseType(_strategyType, _dbType);

            if (_startGui)
            {
                Log.Info("Starting GUI...");
                Gui.Show();
                CloseCallback(CtrlType.CLOSE);
            }
            else
            {
                Log.Info("Starting TUI...");
                Tui.Show();
            }
        }
        


        /// <summary>
        /// Checks to see whether the configuration file exists, otherwise, create it from stream.
        /// </summary>
        private static void ValidateConfigurationFile()
        {
            string confFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            if (!File.Exists(confFile))
                File.WriteAllText(confFile, Properties.Resources.AppConfig);
        }

        /// <summary>
        /// Parses the arguments that are passed to the executeable and determines whether the parsing operation were successful.
        /// </summary>
        /// <param name="args">The arguments that are passed from the console. </param>
        /// <returns>Returns false if parse failed, true if successful. </returns>
        private static bool ParseArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i].ToLower();

                if (!args.Contains("/g") && _startGui) // Only allocate console when not using gui(/g).
                    HookConsole();

                if (!AllowedArgs.Contains(arg))
                {
                    InvalidSyntax();
                    return false;
                }

                if (arg.StartsWith("/h") || arg.StartsWith("/?") || arg.StartsWith("--help"))
                {
                    PrintHelp();
                    return false;
                }

                if (arg.StartsWith("/s"))
                {
                    if (!ParseStrategyTypeArg(arg))
                        return false;
                }

                if (arg.StartsWith("/d"))
                {
                    if (!ParseDatabaseTypeArg(arg))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Parses the <see cref="StrategyType"/> argument for modifying the <see cref="_strategyType"/> before the main 
        /// initializes the database and strategy type.
        /// </summary>
        /// <param name="arg">The <see cref="StrategyType"/> argument that is passed from the console. </param>
        /// <returns>Returns false if parse failed, true if successful. </returns>
        private static bool ParseStrategyTypeArg(string arg)
        {
            switch (arg)
            {
                case "/s:1":
                    Log.Info("Using AscendingStrategy.");
                    _strategyType = StrategyType.First;
                    return true;

                case "/s:2":
                    Log.Info("Using DescendingStrategy.");
                    _strategyType = StrategyType.Second;
                    return true;

                case "/s-mt:1":
                    Log.Info("Using multi-threaded AscendingStrategy.");
                    _strategyType = StrategyType.FirstMt;
                    return true;

                case "/s-mt:2":
                    Log.Info("Using multi-threaded DescendingStrategy.");
                    _strategyType = StrategyType.SecondMt;
                    return true;


                default:
                    InvalidSyntax();
                    return false;
            }
        }

        /// <summary>
        /// Parses the <see cref="DatabaseType"/> argument for modifying the <see cref="_dbType"/> before the main 
        /// initializes the database and strategy type.
        /// </summary>
        /// <param name="arg">The <see cref="DatabaseType"/> argument that is passed from the console. </param>
        /// <returns>Returns false if parse failed, true if successful. </returns>
        private static bool ParseDatabaseTypeArg(string arg)
        {
            switch (arg)
            {
                case "/db:mongo":
                    Log.Info("Using mongo-db as database.");
                    _dbType = DatabaseType.Mongo;
                    return true;

                case "/db:sql":
                    Log.Info("Using sql as database.");
                    _dbType = DatabaseType.PostgreSql;
                    return true;


                default:
                    InvalidSyntax();
                    return false;
            }
        }

        /// <summary>
        /// Hooks the console using the <see cref="NativeMethods"/> class methods that are exported from the windows api dlls in order to 
        /// allow the console to show even when the project output type is set to Windows Application, that way we can swap between <see cref="Gui"/>
        /// or <see cref="Tui"/>.
        /// Also registers a callback method with the <see cref="NativeMethods.SetConsoleCtrlHandler"/> that will register a
        /// close event to the console even if someones click the X button on the top right side so we can do last wrapping before
        /// console closes.
        /// </summary>
        private static void HookConsole()
        {
            _startGui = false;
            ClosedHandler += CloseCallback;
            NativeMethods.AllocConsole();
            NativeMethods.SetConsoleCtrlHandler(ClosedHandler, true);
            AppDomain.CurrentDomain.ProcessExit += delegate { ClosedHandler?.Invoke(CtrlType.CLOSE); };
        }

        /// <summary>
        /// Callback method that is registered to the windows kernal with the <see cref="ConsoleClosedHandler"/> for catching the 
        /// console close event and doing last wrapping.
        /// For more information, please see:
        /// <see cref="https://docs.microsoft.com/en-us/windows/console/setconsolectrlhandler"/>
        /// </summary>
        /// <param name="eventType">The event type that defines the kind of event that occured when the console application closed. </param>
        /// <returns></returns>
        private static bool CloseCallback(int eventType)
        {
            if (!eventType.In(CtrlType.C, CtrlType.BREAK, CtrlType.CLOSE, CtrlType.LOGOFF, CtrlType.SHUTDOWN)) return true;

            Log.Debug($"Closed EventType = {eventType}");
            Log.Info($"##### Application Closed with Session ID => {SessionId} #####");

            return false;
        }

        /// <summary> 
        /// Prints the help window to the user with all the configuration options. 
        /// </summary>
        private static void PrintHelp()
        {
            Console.WriteLine("\nStarts the team manager app from the tui or gui and allows you to specify " +
                              "different configurations.");

            Console.WriteLine("\nTeamManager [/T | /G]   [[/S | /S-MT]:[1 | 2]]   [/DB:[SQL | MONGO]]\n");

            Console.WriteLine("\tUser Interface Configuration:\n" +
                              "\t/T \t    Starts the app in console/terminal (TUI) mode.\n" +
                              "\t/G \t    Starts the app in windows user interface (GUI) mode.\n");

            Console.WriteLine("\tStrategy Configuration:\n" +
                              "\t/S:1 \t    Using Ascending Strategy that retrieves the data in ascending order.\n" +
                              "\t/S:2 \t    Using Descending Strategy that retrieves the data in descending order.\n" +
                              "\t/S-MT:1     Using Ascending Strategy that retrieves the data in ascending order using multi-threaded calls.\n" +
                              "\t/S-MT:2     Using Descending Strategy that retrieves the data in descending order using multi-threaded calls.\n");


            Console.WriteLine("\tDatabase Configuration:\n" +
                              "\t/DB:SQL     Using SQL relational database.\n" +
                              "\t/DB:MONGO   Using Mongo no-relational database.\n");

            Console.WriteLine("### Examples: ###\n" +
                              "TeamManager /t /s-mt:1 /db:mongo\n" +
                              "TeamManager /t /s-mt:1 /db:sql\n" +
                              "TeamManager /g /s:2 /db:sql\n" +
                              "TeamManager /g /s-mt:2 /db:mongo\n");

            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }


        /// <summary> Prints out invalid syntax when invalid syntax received. </summary>
        private static void InvalidSyntax()
        {
            Log.Info("Received invalid syntax from console.");
            if (!_startGui) HookConsole();
            Console.WriteLine("Invalid syntax. Use /? parameter to display help.");
            Console.ReadKey();
        }

    }
}
