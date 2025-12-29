using F1_Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace F1_Manager_2._0
{
    public class Scenes
    {
        public PlayerTeam SetUp(Tracks tracks)
        {
            PlayerTeam playerTeam = new PlayerTeam();

            // Vytvoríme zoznam všetkých jazdcov
            List<(string Name, int Rating, string TeamName)> allDrivers = new List<(string, int, string)>();
            foreach (var team in Teams.TeamList.AllTeams)
            {
                allDrivers.Add((team.Driver1Name, team.Driver1Rating, team.TeamName));
                allDrivers.Add((team.Driver2Name, team.Driver2Rating, team.TeamName));
            }

            // Vypíšeme všetkých jazdcov s indexom
            Console.WriteLine("Pre výber jazdca napíš jeho INDEX ČÍSLO");
            int index = 1;
            foreach (var driver in allDrivers)
            {
                Console.WriteLine($"{index}: {driver.Name} ({driver.TeamName})");
                index++;
            }

            // Vyber prvého jazdca

            Console.Write("Vyber prvého jazdca: ");
            int input = int.Parse(Console.ReadLine());
            playerTeam.driver1name = allDrivers[input - 1].Name;
            playerTeam.driver1rating = allDrivers[input - 1].Rating;
            playerTeam.teamName = allDrivers[input - 1].TeamName;
            allDrivers.RemoveAt(input - 1);
            Console.Clear();

            // Vyber druhého jazdca
                Console.WriteLine("Vyber druhého jazdca: ");
            int index2 = 1;
            foreach (var driver in allDrivers)
            {
                Console.WriteLine($"{index2}: {driver.Name} ({driver.TeamName})");
                index2++;
            }
            int input2 = int.Parse(Console.ReadLine());
            playerTeam.driver2name = allDrivers[input2 - 1].Name;
            playerTeam.driver2rating = allDrivers[input2 - 1].Rating;

            Console.WriteLine($"\nTvoj tím: {playerTeam.driver1name} a {playerTeam.driver2name} ");
            return playerTeam;
        }
    }
}
