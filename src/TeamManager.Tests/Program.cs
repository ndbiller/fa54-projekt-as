using System;
using System.Collections.Generic;
using MongoDB.Driver;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Tests.Modules
{
    static class Program
    {
        private static DBLayerSql Postgres { get; set; }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("mLab MongoDB Connection via MongoDB.Driver 2.4.4");
            Console.WriteLine("Heroku Postgresql DB Connection via Npgsql v4.0.30319\n");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            // Testing Mongo
            //Console.WriteLine("Testing mongoDB.");
            //TestMongoDB();
            //FillMongoDb();
            //Console.WriteLine("Press any key to continue.");
            //Console.ReadKey();

            // Testing SQL
            // Creating DB layer
            Postgres = new DBLayerSql();
            Console.WriteLine("SQL DB Layer created.");

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

            CreateTablesPostgresqlDb();
            FillPostgresqlDb();
            TestPostgresqlDb();
        }

        private static void CreateTablesPostgresqlDb()
        {
            Console.Clear();
            // Dropping tables, if they exist
            Console.WriteLine("Dropping existing tables.");
            String sqlDropTables = @"
                DROP TABLE IF EXISTS team, player;";
            Postgres.ExecuteSQL(sqlDropTables);
            // Create Tables
            Console.WriteLine("Creating tables.");
            // Create table team and add constraints
            String sqlTeam = @"
                CREATE TABLE team(
                    id SERIAL,
                    name CHAR(256)
                );";
            Postgres.ExecuteSQL(sqlTeam);
            String sqlSequenceTeam = @"
                ALTER SEQUENCE team_id_seq RESTART WITH 1 INCREMENT BY 1;";
            Postgres.ExecuteSQL(sqlSequenceTeam);
            String sqlConstraintsTeam = @"
                ALTER TABLE team
                ADD CONSTRAINT pk_team_id PRIMARY KEY(id);";
            Postgres.ExecuteSQL(sqlConstraintsTeam);
            // Create table player and add constraints
            String sqlPlayer = @"
                CREATE TABLE player(
                    id SERIAL,
                    name CHAR(256),
                    team_id INTEGER DEFAULT 0
                );";
            Postgres.ExecuteSQL(sqlPlayer);
            String sqlSequencePlayer = @"
                ALTER SEQUENCE player_id_seq RESTART WITH 1 INCREMENT BY 1;";
            Postgres.ExecuteSQL(sqlSequencePlayer);
            String sqlConstraintsPlayer = @"
                ALTER TABLE player
                ADD CONSTRAINT pk_player_id PRIMARY KEY(id),
                ADD CONSTRAINT fk_team_id FOREIGN KEY(team_id) REFERENCES team(id);";
            Postgres.ExecuteSQL(sqlConstraintsPlayer);
            Console.WriteLine("Tables created.");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private static void FillPostgresqlDb()
        {
            Console.Clear();
            // Filling tables
            Console.WriteLine("Filling tables.");
            // Fill the database with teams
            String sqlDefaultTeam = "INSERT INTO team(id,name) VALUES ('0','Unsigned');";
            Postgres.ExecuteSQL(sqlDefaultTeam);
            String sqlAddTeam1 = "INSERT INTO team(id,name) VALUES ('1','Greuther Fürth');";
            Postgres.ExecuteSQL(sqlAddTeam1);
            String sqlAddTeam2 = "INSERT INTO team(id,name) VALUES ('2','FC Nürnberg');";
            Postgres.ExecuteSQL(sqlAddTeam2);
            // Fill the database with players
            String sqlAddPlayer1 = "INSERT INTO player(id,name,team_id) VALUES ('0','Spieler_1','0');";
            Postgres.ExecuteSQL(sqlAddPlayer1);
            String sqlAddPlayer2 = "INSERT INTO player(id,name,team_id) VALUES ('1','Spieler_2','1');";
            Postgres.ExecuteSQL(sqlAddPlayer2);
            String sqlAddPlayer3 = "INSERT INTO player(id,name,team_id) VALUES ('2','Spieler_3','2');";
            Postgres.ExecuteSQL(sqlAddPlayer3);
            String sqlAddPlayer4 = "INSERT INTO player(id,name,team_id) VALUES ('3','Spieler_4','0');";
            Postgres.ExecuteSQL(sqlAddPlayer4);
            Console.WriteLine("Tables filled with testdata.");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private static void TestPostgresqlDb()
        {
            Console.Clear();
            // Testing connection
            Console.WriteLine("Testing Postgresql DB.");

            // TODO: Test the database CRUD operations

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private static void TestMongoDb()
        {
            Console.Clear();
            Console.WriteLine("Connecting to MongoDB.");
            DbLayerMongo mongo = new DbLayerMongo();
            Console.WriteLine("DB connected.");

            Console.WriteLine("Showing all Teams.");
            

            //Console.WriteLine("Dropping old collections.");
            //DBLayerMongo.Database.DropCollection("team");
            //DBLayerMongo.Database.DropCollection("player");

            //Console.WriteLine("Creating Team.");
            //DBLayerMongo.Team.InsertOne(new Team()
            //{
            //    Name = "Team One"
            //});
            //DBLayerMongo.Team.InsertOne(new Team()
            //{
            //    Name = "Team Two"
            //});
            //DBLayerMongo.Team.InsertOne(new Team()
            //{
            //    Name = "Team Three"
            //});

            //Console.WriteLine("Getting first Team Id.");
            //string teamId = DBLayerMongo.Team.Find(t => t.Name == "Team One").First().Id;

            //Console.WriteLine("Creating first Team Player.");
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player One",
            //    Team = teamId
            //});
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player Two",
            //    Team = teamId
            //});
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player Three",
            //    Team = teamId
            //});

            //Console.WriteLine("Getting second Team Id.");
            //string secondTeamId = DBLayerMongo.Team.Find(t => t.Name == "Team Two").First().Id;

            //Console.WriteLine("Creating second Team Player.");
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player Four",
            //    Team = secondTeamId
            //});
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player Five",
            //    Team = secondTeamId
            //});

            //Console.WriteLine("Getting third Team Id.");
            //string thirdTeamId = DBLayerMongo.Team.Find(t => t.Name == "Team Three").First().Id;

            //Console.WriteLine("Creating third Team Player.");
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player Six",
            //    Team = thirdTeamId
            //});
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player Seven",
            //    Team = thirdTeamId
            //});
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player Eight",
            //    Team = thirdTeamId
            //});
            //DBLayerMongo.Player.InsertOne(new Player()
            //{
            //    Name = "Player Nine",
            //    Team = thirdTeamId
            //});

            Console.WriteLine("Finished creating Team and Player.");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Querying for Team Name.");
            List<Team> teams = DBLayerMongo.TeamCollection.Find(t => t.Name == "Arsenal").ToList();
            Console.WriteLine("Team found: {0}", teams.Count);
            foreach (Team team in teams)
            {
                string teamID;
                Console.WriteLine("Name: {0}", team.Name);
                teamID = team.Id;
                Console.WriteLine("Querying for Players of {0}.", team.Name);
                List<Player> players = DBLayerMongo.PlayerCollection.Find(p => p.TeamId == teamID).ToList();
                foreach (Player player in players)
                    Console.WriteLine("Name: {0}", player.Name);
            }
            
            //string teamId = "";
            //foreach (Team team in teams)
            //{
            //    Console.WriteLine(team.Name);
            //    teamId = team.Id;

            //    Console.WriteLine("Querying for Player of {0}.", team.Name);
            //    List<Player> players = DBLayerMongo.PlayerCollection.Find(p => p.Team == teamId).ToList();
            //    Console.WriteLine("Player found: {0}", players.Count());
            //    foreach (Player player in players)
            //    {
            //        Console.WriteLine(player.Name);
            //    }
            //}

            Console.WriteLine("Query finished.");
            Console.WriteLine("\nPress any key to quit.");
            Console.ReadKey();
        }


        private static void FillMongoDb()
        {
            DbLayerMongo dbLayerMongo = new DbLayerMongo();
            DbLayerMongo.Database.DropCollection("team");
            DbLayerMongo.Database.DropCollection("player");

            var teams = new List<Team>
            {
                new Team("England"),
                new Team("Arsenal"),
                new Team("Chelsea"),
                new Team("Manchester United"),
                new Team("Scotland"),
                new Team("Wales")
            };

            var players = new List<Player>
            {
                new Player("Neville Southall"),
                new Player("James Chester"),
                new Player("Gareth Southgate"),
                new Player("Clarke Carlisle"),
                new Player("Jermaine Darlington"),
                new Player("Stuart Ripley"),
                new Player("Steve Stone")
            };

            DbLayerMongo.TeamCollection.InsertMany(teams);
            DbLayerMongo.PlayerCollection.InsertMany(players);

            var manchesterUnitedId = DbLayerMongo.TeamCollection.Find(t => t.Name == "Manchester United").First().Id;
            var playersManchester = new List<Player>
            {
                new Player("Bob Donaldson"    , manchesterUnitedId),
                new Player("Fred Erentz"      , manchesterUnitedId),
                new Player("Joe Cassidy"      , manchesterUnitedId),
                new Player("James McNaught"   , manchesterUnitedId),
                new Player("Dick Smith"       , manchesterUnitedId),
                new Player("Walter Cartwright", manchesterUnitedId),
                new Player("Harry Stafford"   , manchesterUnitedId)
            };

            DbLayerMongo.PlayerCollection.InsertMany(playersManchester);
        }


    }
}
