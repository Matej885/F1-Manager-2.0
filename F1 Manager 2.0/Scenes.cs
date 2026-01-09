using F1_Manager;
using System;
using System.Collections.Generic;

namespace F1_Manager_2._0
{
    public class Scenes
    {
        public PlayerTeam SetUp(Tracks tracks)
        {
            PlayerTeam playerTeam = new PlayerTeam();
            Console.Write("Napíš meno svojho tímu: ");
            playerTeam.teamName = Console.ReadLine();
            Console.WriteLine($"Budeš šéfovať {playerTeam.teamName}");

            Console.Write("Napíš svoje meno: ");
            playerTeam.playername = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Vitaj {playerTeam.playername} v F1 Manager 2.0!");

            // --- Výber typu tímu ---
            Console.WriteLine("\nVyber si typ tímu:");
            Console.WriteLine("1 - Súkromný majiteľ, flexibilná štruktúra. Počiatočné peniaze: $80,000,000, Sila monopostu: 6.");
            Console.WriteLine("2 - Malá korporácia. Počiatočné peniaze: $140,000,000 Sila monopostu: 7");
            Console.WriteLine("3 - Nadnárodná korporácia, vysoký rozpočet. Počiatočné peniaze: $170,000,000 Sila monopostu: 8.");
            Console.WriteLine("4 - Automobilka, vlastné know-how. Počiatočné peniaze: $210,000,000 Sila monopostu: 9.");

            while (true)
            {
                Console.Write("Vyber si tím (1-4): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": playerTeam.Money = 80000000; playerTeam.TeamPower = 60; playerTeam.teamtype = "1"; break;
                    case "2": playerTeam.Money = 140000000; playerTeam.TeamPower = 70; playerTeam.teamtype = "2"; break;
                    case "3": playerTeam.Money = 170000000; playerTeam.TeamPower = 80; playerTeam.teamtype = "3"; break;
                    case "4": playerTeam.Money = 210000000; playerTeam.TeamPower = 90; playerTeam.teamtype = "4"; break;
                    default: Console.WriteLine("Neplatná voľba"); continue;
                }
                return playerTeam;
                break;
            }
        }
        public PlayerTeam ChooseDrivers(PlayerTeam playerTeam)
        {
            Console.Clear();
            // --- Vytvorenie zoznamu všetkých jazdcov ---
            var allDrivers = new List<(string Name, int Rating, Teams Team, int Position)>();
            foreach (var team in Teams.TeamList.AllTeams)
            {
                allDrivers.Add((team.Driver1Name, team.Driver1Rating, team, 1));
                allDrivers.Add((team.Driver2Name, team.Driver2Rating, team, 2));
            }
            // --- Výber prvého jazdca ---
            while (true)
            {
                Console.WriteLine("\nVyber prvého jazdca:");
                Console.WriteLine($"Máš {playerTeam.Money.ToString("N0")}$");

                // Výpis všetkých jazdcov s cenou
                for (int i = 0; i < allDrivers.Count; i++)
                {
                    int cost = allDrivers[i].Position == 1 ? allDrivers[i].Team.Driver1Cost : allDrivers[i].Team.Driver2Cost;

                    Console.Write($"{i + 1}: {allDrivers[i].Name} ({allDrivers[i].Team.TeamName}) - Cena contractu: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{cost.ToString("N0")}$");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }

                // Bezpečný vstup
                if (!int.TryParse(Console.ReadLine(), out int input1) || input1 < 1 || input1 > allDrivers.Count)
                {
                    Console.Clear();
                    Console.WriteLine("Neplatná voľba, skús to znova.");
                    continue;
                }

                input1 -= 1; // index v poli začína od 0

                var firstDriver = allDrivers[input1];
                int driverCost = firstDriver.Position == 1 ? firstDriver.Team.Driver1Cost : firstDriver.Team.Driver2Cost;

                // Skontrolujeme, či má hráč dosť peňazí
                if (playerTeam.Money >= driverCost)
                {
                    playerTeam.Money -= driverCost;           // odpočítame cenu
                    playerTeam.driver1name = firstDriver.Name;
                    playerTeam.driver1rating = firstDriver.Rating;
                    playerTeam.driver2cost = driverCost;
                    // Odstránenie jazdca z pôvodného tímu
                    firstDriver.Team.RemoveDriver(firstDriver.Position);
                    allDrivers.RemoveAt(input1); // aby sa neopakoval

                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Nemáš dosť peňazí na tohto jazdca, skús iného.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }

            // --- Výber druhého jazdca ---
            while (true)
            {
                Console.WriteLine("\nVyber druhého jazdca:");
                Console.WriteLine($"Máš {playerTeam.Money.ToString("N0")}$");

                for (int i = 0; i < allDrivers.Count; i++)
                {
                    int cost = allDrivers[i].Position == 1 ? allDrivers[i].Team.Driver1Cost : allDrivers[i].Team.Driver2Cost;

                    Console.Write($"{i + 1}: {allDrivers[i].Name} ({allDrivers[i].Team.TeamName}) - Cena contractu: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{cost.ToString("N0")}$");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }

                if (!int.TryParse(Console.ReadLine(), out int input2) || input2 < 1 || input2 > allDrivers.Count)
                {
                    Console.Clear();
                    Console.WriteLine("Neplatná voľba, skús to znova.");
                    continue;
                }

                input2 -= 1; // index začína od 0
                var secondDriver = allDrivers[input2];
                int driverCost = secondDriver.Position == 1 ? secondDriver.Team.Driver1Cost : secondDriver.Team.Driver2Cost;

                if (playerTeam.Money >= driverCost)
                {
                    playerTeam.Money -= driverCost;           // odpočítame cenu
                    playerTeam.driver2name = secondDriver.Name;
                    playerTeam.driver2rating = secondDriver.Rating;
                    playerTeam.driver2cost = driverCost;
                    // Odstránenie jazdca z pôvodného tímu
                    secondDriver.Team.RemoveDriver(secondDriver.Position);
                    allDrivers.RemoveAt(input2); // aby sa neopakoval

                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Nemáš dosť peňazí na tohto jazdca, skús iného.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            return playerTeam;
        }
    }

    // --- Pomocná metóda na odstránenie jazdca z tímu ---
    public static class TeamFunctions
    {
        // GLOBÁLNY POOL NÁHRADNÍKOV
        private static List<(string Name, int Rating)> replacements =
            new List<(string, int)>
            {
            ("Valtteri Bottas", 30),
            ("Josef Král", 15)
            };

        public static void RemoveDriver(this Teams team, int position)
        {
            // ak už nemáme koho dosadiť
            if (replacements.Count == 0)
                return;

            // vezmeme PRVÉHO z poolu
            var replacement = replacements[0];
            replacements.RemoveAt(0); // DÔLEŽITÉ – odstránime ho

            if (position == 1)
            {
                team.Driver1Name = replacement.Name;
                team.Driver1Rating = replacement.Rating;
                team.Driver1Points = 0;
            }
            else if (position == 2)
            {
                team.Driver2Name = replacement.Name;
                team.Driver2Rating = replacement.Rating;
                team.Driver2Points = 0;
            }
        }
    }
}




