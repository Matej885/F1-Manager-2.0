using F1_Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace F1_Manager_2._0
{
    public class MainMenu
    {
        public bool raceday = false;
        public void Menu(Teams teams, PlayerTeam playerTeam)
        {
            List<Teams> allTeams = Teams.TeamList.AllTeams;
            RaceSimulation raceSimulation = new RaceSimulation(allTeams);
            Upgrades upgrades = new Upgrades();
            int day = 1;
            while (raceday == false)
            {
                Tracks tracks = new Tracks();
                tracks.CheckRaceDay(day);
                Console.WriteLine("Vitaj v hre F1 Manager 2.0!");
                Console.WriteLine($"{playerTeam.teamName}");
                Console.WriteLine($"Day: {day}");
                Console.WriteLine("1. Zobrazit štatistiky timu");
                Console.WriteLine("2. Prejsť do garáže a prezrieť si upgrady");
                Console.WriteLine("Enter - Pokračovať na ďalší deň");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Team Stats: ");
                    Console.WriteLine($"Jazdec 1: {playerTeam.driver1name} - Rating: {playerTeam.driver1rating} - Body: {playerTeam.pointsDriver1}");
                    Console.WriteLine($"Jazdec 2: {playerTeam.driver2name} - Rating: {playerTeam.driver2rating} - Body: {playerTeam.pointsDriver2}");
                    Console.WriteLine($"Sila monopostu: {playerTeam.TeamPower}");
                    Console.WriteLine($"Peniaze: ${playerTeam.Money}");
                }
                else if (input == "2")
                {
                    int i = 0;
                    Random random = new Random();
                    Random randomprice = new Random();
                    Console.WriteLine("Available Upgrades:");
                    while (i < 4)
                    {
                        int price = randomprice.Next(1500, 10000);
                        int index = random.Next(upgrades.Parts.Count);
                        Console.WriteLine($"{index} - {upgrades.Parts[index]} - {price} $");
                        upgrades.Parts.RemoveAt(index);
                        i++;
                    }
                    upgrades.Parts.Clear();
                    upgrades.AddUpgrades();
                    Console.WriteLine("Enter the number of the upgrade you want to buy or press Enter to go back:");
                    string upgradeInput = Console.ReadLine();
                    Console.ReadLine();
                }
                else
                {
                    day++;
                }
            }
        }
    }
}
