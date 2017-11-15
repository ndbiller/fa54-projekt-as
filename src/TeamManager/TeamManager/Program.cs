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
            //AllocConsole();
            //TUI.Start();

            //if (args.Length != 0)
            //{
            //    if (!args[0].ToLower().StartsWith("/g")) // We don't want to allocate console when using gui.
            //        AllocConsole();

            //    switch (args[0].ToLower())
            //    {
            //        case "/t:1":
            //            InitializeDataStructure(ConceptType.First);
            //            TUI.Start();
            //            break;
            //        case "/t:2":
            //            InitializeDataStructure(ConceptType.Second);
            //            TUI.Start();
            //            break;
            //        case "/g:1":
            //            InitializeDataStructure(ConceptType.First);
            //            GUI.Start();
            //            break;
            //        case "/g:2":
            //            InitializeDataStructure(ConceptType.Second);
            //            GUI.Start();
            //            break;
            //        case "/?":
            //            PrintHelp();
            //            break;
            //        default:
            //            Console.WriteLine("Invalid syntax. Use /? parameter to display help.");
            //            Console.ReadKey();
            //            break;
            //    }
            //}
            //else // -> when you start the app through the windows explorer or from the console without parameters.
            //{
            //    //InitializeDataStructure(ConceptType.First); // Default = First concept type.
            //    //GUI.Start();
            //    Console.WriteLine("Hello from console");
            //    Console.ReadKey();
            //}

            Console.WriteLine("mLab MongoDB Connection via MongoDB.Driver 2.4.4 for ConceptType.Second:\n");
            Console.WriteLine("- TeamManager temporarily set to Output type: Console Application. \n- Code in Program.cs Main temporarily commented out.\n");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            FillMongoDB();
            TestMongoDB();
        }

        private static void FillMongoDB()
        {
            Console.Clear();
            Console.WriteLine("Dropping old collections.");
            DBLayerMongo.Database.DropCollection("team");
            DBLayerMongo.Database.DropCollection("player");

            Console.WriteLine("Creating Team.");
            DBLayerMongo.Teams.InsertOne(new Team()
            {
                Name = "Team One"
            });
            DBLayerMongo.Teams.InsertOne(new Team()
            {
                Name = "Team Two"
            });
            DBLayerMongo.Teams.InsertOne(new Team()
            {
                Name = "Team Three"
            });

            Console.WriteLine("Getting first Team Id.");
            string teamId = DBLayerMongo.Teams.Find(t => t.Name == "Team One").First().Id;

            Console.WriteLine("Creating first Team Players.");
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player One",
                Team = teamId
            });
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player Two",
                Team = teamId
            });
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player Three",
                Team = teamId
            });

            Console.WriteLine("Getting second Team Id.");
            string secondTeamId = DBLayerMongo.Teams.Find(t => t.Name == "Team Two").First().Id;

            Console.WriteLine("Creating second Team Players.");
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player Four",
                Team = secondTeamId
            });
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player Five",
                Team = secondTeamId
            });

            Console.WriteLine("Getting third Team Id.");
            string thirdTeamId = DBLayerMongo.Teams.Find(t => t.Name == "Team Three").First().Id;

            Console.WriteLine("Creating third Team Players.");
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player Six",
                Team = thirdTeamId
            });
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player Seven",
                Team = thirdTeamId
            });
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player Eight",
                Team = thirdTeamId
            });
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = "Player Nine",
                Team = thirdTeamId
            });

            Console.WriteLine("Finished creating Teams and Players.");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private static void TestMongoDB()
        {
            Console.Clear();
            Console.WriteLine("Querying for Team One.");
            List<Team> teams = DBLayerMongo.Teams.Find(t => t.Name == "Team One").ToList();
            Console.WriteLine("Teams found: {0}", teams.Count());
            string teamId = "";
            foreach (Team team in teams)
            {
                Console.WriteLine(team.Name);
                teamId = team.Id;

                Console.WriteLine("Querying for Players of {0}.", team.Name);
                List<Player> players = DBLayerMongo.Players.Find(p => p.Team == teamId).ToList();
                Console.WriteLine("Players found: {0}", players.Count());
                foreach (Player player in players)
                {
                    Console.WriteLine(player.Name);
                }
            }

            Console.WriteLine("Query finished.");
            Console.WriteLine("\nPress any key to quit.");
            Console.ReadKey();
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
