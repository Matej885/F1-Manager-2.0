using F1_Manager;
using System;
using System.Collections.Generic;

namespace F1_Manager_2._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Použijeme všetky tímy zo statického zoznamu
            Console.Title = "F1 Manager 2.0";
            MainMenu mainMenu = new MainMenu();
            PlayerTeam playerTeam = new PlayerTeam();
            List<Teams> allTeams = Teams.TeamList.AllTeams;
            Teams teams = new Teams();
            Scenes scenes = new Scenes();
            Tracks tracks = new Tracks();
            RaceSimulation raceSimulation = new RaceSimulation(allTeams);
            scenes.SetUp(tracks);
            mainMenu.Menu(teams, playerTeam);
        }
    }
}
