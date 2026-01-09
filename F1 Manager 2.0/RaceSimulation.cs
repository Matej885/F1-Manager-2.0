using System;
using System.Collections.Generic;
using System.Threading;
using static F1_Manager_2._0.Teams;

namespace F1_Manager_2._0
{
    public class RaceSimulation
    {
        private List<Teams> teamsInRace;

        public RaceSimulation(List<Teams> teams)
        {
            teamsInRace = teams;
        }

        public void SimulateRace(PlayerTeam playerteam)
        {
            Console.Clear();
            Console.WriteLine("Race simulation started!");
            List<string> pool = new List<string>();
            List<string> results = new List<string>();
            Random rnd = new Random();

            // Naplnenie poolu jazdcami podľa výkonu = DriverRating + TeamRating
            foreach (var team in teamsInRace)
            {
                for (int i = 0; i < team.Driver1Rating * team.TeamRating; i++)
                {
                    pool.Add(team.Driver1Name);
                }
                for (int i = 0; i < team.Driver2Rating * team.TeamRating; i++)
                {
                    pool.Add(team.Driver2Name);
                }
            }
            // Pridanie hráčovho tímu do poolu
            for (int i = 0; i < playerteam.driver1rating * playerteam.TeamPower; i++)
            {
                pool.Add(playerteam.driver1name);
            }
            for (int i = 0; i < playerteam.driver2rating * playerteam.TeamPower; i++)
            {
                pool.Add(playerteam.driver2name);
            }
            // Výber top 22 unikátnych jazdcov
            while (results.Count < 22)
            {
                string name = pool[rnd.Next(pool.Count)];
                if (!results.Contains(name))
                    results.Add(name);
            }

            // Priraďovanie bodov a výpis výsledkov
            int place = 1;
            foreach (string name in results)
            {
                int pts = 0;
                switch (place)
                {
                    case 1: pts = 25; break;
                    case 2: pts = 18; break;
                    case 3: pts = 15; break;
                    case 4: pts = 12; break;
                    case 5: pts = 10; break;
                    case 6: pts = 8; break;
                    case 7: pts = 6; break;
                    case 8: pts = 4; break;
                    case 9: pts = 2; break;
                    case 10: pts = 1; break;
                }

                // Pridanie bodov jazdcovi a tímu
                foreach (var team in teamsInRace)
                {
                    if (name == team.Driver1Name)
                    {
                        team.Driver1Points += pts;
                        team.TeamPoints += pts;
                    }
                    else if (name == team.Driver2Name)
                    {
                        team.Driver2Points += pts;
                        team.TeamPoints += pts;
                        break;
                    }
                    else if (name == playerteam.driver1name)
                    {
                        playerteam.pointsDriver1 += pts;
                        if (playerteam.teamtype == "1")
                        {
                            if (place >= 5)
                            {
                                playerteam.Money += 100000;
                            }
                            else
                            {

                            }
                        }
                        else if (playerteam.teamtype == "2")
                        {
                            if (place >= 8)
                            {
                                playerteam.Money += 100000;
                            }
                            else
                            {
                            }
                        }
                        else if (playerteam.teamtype == "3")
                        {
                            if (place >= 10)
                            {
                                playerteam.Money += 100000;
                            }
                            else
                            {
                            }
                        }
                        else if (playerteam.teamtype == "4")
                        {
                            if (place >= 12)
                            {
                                playerteam.Money += 100000;
                            }
                            else
                            {
                            }
                        }
                        break;
                    }
                    else if (name == playerteam.driver2name)
                    {
                        playerteam.pointsDriver2 += pts;
                        if (playerteam.teamtype == "1")
                        {
                            if (place >= 5)
                            {
                                playerteam.Money += 100000;
                            }
                            else
                            {

                            }
                        }
                        else if (playerteam.teamtype == "2")
                        {
                            if (place >= 8)
                            {
                                playerteam.Money += 100000;
                            }
                            else
                            {
                            }
                        }
                        else if (playerteam.teamtype == "3")
                        {
                            if (place >= 10)
                            {
                                playerteam.Money += 100000;
                            }
                            else
                            {
                            }
                        }
                        else if (playerteam.teamtype == "4")
                        {
                            if (place >= 12)
                            {
                                playerteam.Money += 100000;
                            }
                            else
                            {
                            }
                        }
                        break;
                    }
                }

                Console.WriteLine($"{place}. {name} (+{pts} bodov)");
                Thread.Sleep(100);
                place++;
                Random rand = new Random(); // jeden Random pre všetko

                foreach (var driver in teamsInRace)
                {
                    int A = rand.Next(1, 1);          // zlepšenie 1-3 bodov
                    int random1 = rnd.Next(0, 101);  // šanca 25%

                    if (random1 < 15) // 15% šanca
                    {
                        // vyber náhodne Driver1 alebo Driver2
                        if (rand.Next(0, 2) == 0)
                        {
                            driver.Driver1Rating += 1;
                        }
                        else
                        {
                            driver.Driver2Rating += 1;
                        }
                    }
                }
            }
            Console.WriteLine("Pre ukončenie preteku stlačte ľubovoľnú klávesu...");
            Console.ReadLine();
            Console.Clear();
            playerteam.Races++;
        }
    }
}