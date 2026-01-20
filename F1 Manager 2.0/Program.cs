using F1_Manager;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
namespace F1_Manager_2._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("Pre najlepší zážitok zmačkni Alt + Enter");
            Console.Title = "F1 Manager 2.0";
            int trackLength = 1;
            string car = "(=O=>";
            string[] loadingTexts = {
            "Loading tracks...",
            "Calculating tyre wear...",
            "Simulating AI strategies...",
            "Preparing pit stops...",
            "Finalizing setup...",
            "Optimalizing game graphics... ",
            "Loading CPU information... ",
            "Loading GPU information... ",
            "Connecting to servers... ",
            "Loading information about your mom... "
        }; 

            Random rnd = new Random();

            for (int i = 0; i <= trackLength; i++)
            {
                Console.WriteLine("LOADING");
                Console.WriteLine();

                // Text nad barom
                string text = loadingTexts[rnd.Next(loadingTexts.Length)];
                Console.WriteLine(text);

                // Trať s autom
                Console.Write("[");
                Console.Write(new string('-', i));
                Console.Write(car);
                Console.Write(new string('-', trackLength - i));
                Console.WriteLine("]");

                // Percentá
                int percent = i * 100 / trackLength;
                Console.WriteLine($"Loading... {percent}%");
                Random randomtime = new Random();
                int load = randomtime.Next(100, 500);
                Thread.Sleep(load); // rýchlosť loadingu
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
███████╗██╗    ███╗   ███╗ █████╗ ███╗   ██╗ █████╗  ██████╗ ███████╗██████╗ 
██╔════╝██║    ████╗ ████║██╔══██╗████╗  ██║██╔══██╗██╔════╝ ██╔════╝██╔══██╗
█████╗  ██║    ██╔████╔██║███████║██╔██╗ ██║███████║██║  ███╗█████╗  ██████╔╝
██╔══╝  ██║    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══██╗
██║     ██║    ██║ ╚═╝ ██║██║  ██║██║ ╚████║██║  ██║╚██████╔╝███████╗██║  ██║
╚═╝     ╚═╝    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝

                made by Matej Šustek & Dominik Škorvánek
");

            Console.ForegroundColor = ConsoleColor.White;
            List<Teams> allTeams = Teams.TeamList.AllTeams;
            Teams teams = new Teams();
            Tracks tracks = new Tracks();

            Scenes scenes = new Scenes();
            PlayerTeam playerTeam = scenes.SetUp(tracks);
            playerTeam = scenes.ChooseDrivers(playerTeam);
            RaceSimulation raceSimulation = new RaceSimulation(allTeams);
            MainMenu menu = new MainMenu();

            menu.Menu(teams, playerTeam);
            /*while (true)
            {
                raceSimulation.SimulateRace();
                Console.ReadLine();
            }*/
        }
    }
}
