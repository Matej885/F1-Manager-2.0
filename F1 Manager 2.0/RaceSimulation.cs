using System;
using System.Collections.Generic;
using System.Threading;

namespace F1_Manager_2._0
{
    public class RaceSimulation
    {
        private List<Teams> teamsInRace;

        public RaceSimulation(List<Teams> teams)
        {
            teamsInRace = teams;
        }

        public void SimulateRace()
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

            // Výber top 20 unikátnych jazdcov
            while (results.Count < 20)
            {
                string name = pool[rnd.Next(pool.Count)];
                if (!results.Contains(name))
                {
                    results.Add(name);
                }
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
                        break;
                    }
                    else if (name == team.Driver2Name)
                    {
                        team.Driver2Points += pts;
                        team.TeamPoints += pts;
                        break;
                    }
                }
                Console.WriteLine($"{place}. {name} (+{pts} bodov)");
                Thread.Sleep(100);
                place++;
            }
        }
    }
}
