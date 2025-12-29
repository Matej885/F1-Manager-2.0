using F1_Manager;
using System;
using System.Collections.Generic;

namespace F1_Manager_2._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "F1 Manager 2.0";

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
