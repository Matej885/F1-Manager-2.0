using F1_Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;

namespace F1_Manager_2._0
{
    public class MainMenu
    {
        public bool raceday = false;
        public int efectivity;
        public void Menu(Teams teams, PlayerTeam playerTeam)
        {
            List<Teams> allTeams = Teams.TeamList.AllTeams;
            RaceSimulation raceSimulation = new RaceSimulation(allTeams);
            Upgrades upgrades = new Upgrades();
            List<string> tempParts = new List<string>(upgrades.Parts);
            List<string> shownUpgrades = new List<string>();
            Scenes scenes = new Scenes();
            int day = 1;
            while (raceday == false)
            {
                if (playerTeam.Races == 24)
                {
                    Console.WriteLine("Koniec sezóny!");
                    Console.WriteLine("Tu sú výsledky tvojej sezóny:");
                    while (true)
                    {
                        List<(string Name, int Points)> teamStandings = new List<(string, int)>();

                        // AI tímy
                        foreach (var t in Teams.TeamList.AllTeams)
                        {
                            teamStandings.Add((t.TeamName, t.TeamPoints));
                        }

                        // moj tím
                        int myTeamPoints = playerTeam.pointsDriver1 + playerTeam.pointsDriver2;
                        teamStandings.Add((playerTeam.teamName, myTeamPoints));

                        // zoradenie (DESC)
                        teamStandings.Sort((a, b) => b.Points.CompareTo(a.Points));

                        Console.WriteLine("PORADIE TÍMOV:");
                        int place = 1;
                        foreach (var t in teamStandings)
                        {
                            if (place == 1)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else if (place == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else if (place == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine($"{place}. {t.Name} - {t.Points} bodov");
                            place++;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        List<(string Name, int Points)> driverStandings = new List<(string, int)>();

                        // AI jazdci
                        foreach (var t in Teams.TeamList.AllTeams)
                        {
                            driverStandings.Add((t.Driver1Name, t.Driver1Points));
                            driverStandings.Add((t.Driver2Name, t.Driver2Points));
                        }

                        // tvoji jazdci
                        driverStandings.Add((playerTeam.driver1name, playerTeam.pointsDriver1));
                        driverStandings.Add((playerTeam.driver2name, playerTeam.pointsDriver2));

                        // zoradenie
                        driverStandings.Sort((a, b) => b.Points.CompareTo(a.Points));

                        Console.WriteLine("\nPORADIE JAZDCOV:");
                        place = 1;
                        foreach (var d in driverStandings)
                        {
                            if (place == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                if (d.Name == playerTeam.driver1name || d.Name == playerTeam.driver2name)
                                {
                                    playerTeam.Standings = place;
                                }
                            }
                            else if (place == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                if (d.Name == playerTeam.driver1name || d.Name == playerTeam.driver2name)
                                {
                                    playerTeam.Standings = place;
                                }
                            }
                            else if (place == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                if (d.Name == playerTeam.driver1name || d.Name == playerTeam.driver2name)
                                {
                                    playerTeam.Standings = place;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                if (d.Name == playerTeam.driver1name || d.Name == playerTeam.driver2name)
                                {
                                    playerTeam.Standings = place;
                                }
                            }
                            Console.WriteLine($"{place}. {d.Name} - {d.Points} bodov");
                            place++;
                            Console.ReadLine();
                        }
                        Console.WriteLine("Počkaj si na vyhodnotenie sezóny od šéfa! ");
                        Thread.Sleep(5000);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        day = 0;
                        if (playerTeam.teamtype == "1")
                        {
                            if (playerTeam.Standings >= 9)
                            {
                                Console.WriteLine("Výborne, práca bola presne podľa očakávaní. Vaša flexibilita a rozhodnosť priniesli výsledok.");
                                Console.WriteLine("Bonus za splnenie cieľa: 20 000 000 $");
                                playerTeam.Money += 20000000;
                                playerTeam.teamtype = "2";
                                Console.WriteLine("Teraz si počkáme na ďalšiu sezónu...");
                                Console.WriteLine("Načítavam novu sezónu...");
                                Thread.Sleep(10000);
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Tento výkon je neprijateľný. Ako riaditeľ tímu ste zlyhal v základných úlohách. Musíme hľadať nového vedúceho.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("Bohužiaľ, bol si prepustený z pozície riaditeľa tímu kvôli nedostatočnému výkonu.");
                                Console.WriteLine("Koniec hry!");
                                Environment.Exit(0);
                            }
                        }
                        else if (playerTeam.teamtype == "2")
                        {
                            if (playerTeam.Standings >= 6)
                            {
                                Console.WriteLine("Dobrý výkon. Presne takto očakávame, že náš tím bude napredovať. Pokračujte v tejto kvalite.");
                                Console.WriteLine("Bonus za splnenie cieľa: 50 000 000 $");
                                playerTeam.Money += 50000000;
                                Console.WriteLine("Teraz si môžete zaplatiť jazdcov na ďalšiu sezónu!");
                                scenes.ChooseDrivers(playerTeam);
                                Console.WriteLine("Teraz si počkáme na ďalšiu sezónu...");
                                Console.WriteLine("Načítavam novu sezónu...");
                                Console.ReadLine();
                                Thread.Sleep(10000);
                                Console.Clear();
                                playerTeam.teamtype = "3";
                            }
                            else
                            {
                                Console.WriteLine("Výsledky tímu sú katastrofálne. Vaše rozhodnutia výrazne ohrozili budúcnosť projektu. Vaša pozícia sa ruší.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("Bohužiaľ, bol si prepustený z pozície riaditeľa tímu kvôli nedostatočnému výkonu.");
                                Console.WriteLine("Koniec hry!");
                                Environment.Exit(0);
                            }
                        }
                        else if (playerTeam.teamtype == "3")
                        {
                            if (playerTeam.Standings >= 5)
                            {
                                Console.WriteLine("Splnenie cieľa je uspokojivé. Tento výsledok posilňuje našu pozíciu a budúcnosť tímu vyzerá perspektívne.");
                                Console.WriteLine("Bonus za splnenie cieľa: 80 000 000 $");
                                playerTeam.Money += 80000000;
                                Thread.Sleep(2000);
                                Console.WriteLine("Teraz si môžete zaplatiť jazdcov na ďalšiu sezónu!");
                                scenes.ChooseDrivers(playerTeam);
                                Console.WriteLine("Teraz si počkáme na ďalšiu sezónu...");
                                Console.WriteLine("Načítavam novu sezónu...");
                                Console.ReadLine();
                                Thread.Sleep(10000);
                                Console.Clear();
                                playerTeam.teamtype = "4";
                            }
                            else
                            {
                                Console.WriteLine("Výkon tímu je pod hranicou prijateľného. Vaše chyby sú neodpustiteľné. Ukončujeme vašu zodpovednosť za tím.");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            if (playerTeam.Standings >= 3)
                            {
                                Console.WriteLine("Výborný výkon. Naša technológia a know-how sa jasne prejavili a priniesli očakávaný výsledok.");
                                Console.WriteLine("Bonus za splnenie cieľa: 100 000 000 $");
                                playerTeam.Money += 100000000;
                                Thread.Sleep(2000);
                                Console.WriteLine("Teraz si môžete zaplatiť jazdcov na ďalšiu sezónu!");
                                scenes.ChooseDrivers(playerTeam);
                                Console.WriteLine("Teraz si počkáme na ďalšiu sezónu...");
                                Console.WriteLine("Načítavam novu sezónu...");
                                Console.ReadLine();
                                Thread.Sleep(10000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine($"Výsledky sú neprijateľné. Tím nedosiahol ani minimálne štandardy. Kvôli vám je teraz značka {playerTeam.teamName} pošpinená. Vaša pozícia riaditeľa tímu sa končí okamžite.");
                                Environment.Exit(0);
                            }
                        }
                        playerTeam.Races = 0;
                        break;
                    }
                }
                Tracks tracks = new Tracks();
                tracks.CheckRaceDay(day, playerTeam);
                Console.WriteLine($"{playerTeam.teamName}");
                Console.WriteLine($"Day: {day}");
                Console.WriteLine($"Odjazdených závodov: {playerTeam.Races}");
                Console.WriteLine($"Peniaze: {playerTeam.Money.ToString("N0")} $");
                Console.WriteLine("1. Zobrazit štatistiky timu");
                Console.WriteLine("2. Prejsť do garáže a prezrieť si upgrady");
                Console.WriteLine("3. Zobraziť poradie jazdcov a tímov");
                Console.WriteLine("4. Zobraziť kalendár závodov");
                Console.WriteLine("5. Instatne preskočiť na další závod");
                Console.WriteLine("Enter - Pokračovať na ďalší deň");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    int teampoints = playerTeam.pointsDriver1 + playerTeam.pointsDriver2;
                    Console.WriteLine("Team Stats: ");
                    Console.WriteLine($"Body tímu: {teampoints}");
                    Console.WriteLine($"Jazdec 1: {playerTeam.driver1name} - Body: {playerTeam.pointsDriver1}");
                    Console.WriteLine($"Jazdec 2: {playerTeam.driver2name} - Body: {playerTeam.pointsDriver2}");
                    Console.WriteLine($"Sila monopostu: {playerTeam.TeamPower}");
                    Console.WriteLine($"Peniaze: {playerTeam.Money.ToString("N0")}");
                    Console.ReadLine();
                    Console.Clear();
                    day++;
                }
                else if (input == "2")
                {
                    upgrades.AddUpgrades();
                    int i = 0;
                    Random random = new Random();
                    Random randomprice = new Random();
                    Random randomefectivity1 = new Random();
                    Console.WriteLine("Dostupné upgrady: ");
                    int nameindex = random.Next(upgrades.Parts.Count);
                    string partname = upgrades.Parts[nameindex];
                    int price = randomprice.Next(5000000, 15000000);
                    int effectivity = randomefectivity1.Next(1, 8);
                    Console.WriteLine($"{partname} - {price.ToString("N0")}$ a má {effectivity} bodov efektivity na aute");
                    Console.WriteLine("Chcete si tento upgrade kúpiť? (1 - Áno /2 - Nie)");
                    string upgradeinput = Console.ReadLine();
                    if (upgradeinput == "1")
                    {
                        if (playerTeam.Money >= price)
                        {
                            playerTeam.Money -= price;
                            playerTeam.TeamPower += effectivity;
                            Console.WriteLine("Upgrade úspešne nainštalovaný!");
                            upgrades.Parts.RemoveAt(nameindex);
                        }
                        else
                        {
                            Console.WriteLine("Nemáte dosť peňazí na tento upgrade.");
                        }
                    }
                    Console.ReadLine();
                    Console.Clear();
                    day++;
                }
                else if (input == "3")
                {
                    while (true)
                    {
                        List<(string Name, int Points)> teamStandings = new List<(string, int)>();

                        // AI tímy
                        foreach (var t in Teams.TeamList.AllTeams)
                        {
                            teamStandings.Add((t.TeamName, t.TeamPoints));
                        }

                        // tvoj tím
                        int myTeamPoints = playerTeam.pointsDriver1 + playerTeam.pointsDriver2;
                        teamStandings.Add((playerTeam.teamName, myTeamPoints));

                        // zoradenie (DESC)
                        teamStandings.Sort((a, b) => b.Points.CompareTo(a.Points));

                        Console.WriteLine("PORADIE TÍMOV:");
                        int place = 1;
                        foreach (var t in teamStandings)
                        {
                            if (place == 1)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else if (place == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else if (place == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine($"{place}. {t.Name} - {t.Points} bodov");
                            place++;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        List<(string Name, int Points)> driverStandings = new List<(string, int)>();

                        // AI jazdci
                        foreach (var t in Teams.TeamList.AllTeams)
                        {
                            driverStandings.Add((t.Driver1Name, t.Driver1Points));
                            driverStandings.Add((t.Driver2Name, t.Driver2Points));
                        }

                        // tvoji jazdci
                        driverStandings.Add((playerTeam.driver1name, playerTeam.pointsDriver1));
                        driverStandings.Add((playerTeam.driver2name, playerTeam.pointsDriver2));

                        // zoradenie
                        driverStandings.Sort((a, b) => b.Points.CompareTo(a.Points));

                        Console.WriteLine("\nPORADIE JAZDCOV:");
                        place = 1;
                        foreach (var d in driverStandings)
                        {
                            if (place == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            else if (place == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else if (place == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine($"{place}. {d.Name} - {d.Points} bodov");
                            place++;
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ReadLine();
                        Console.Clear();
                        day++;
                        break;
                    }


                }
                else if (input == "4")
                {
                    foreach (var race in tracks.AllRaces)
                    {
                        Console.WriteLine($"Pretek na trati {race.TrackName} sa bude konať v dni {race.RaceDay}");
                    }
                    Console.ReadLine();
                    Console.Clear();
                    day++;
                }
                else if (input == "5")
                {
                    while (true)
                    {
                        bool raceTomorrow = tracks.IsRaceDay(day);

                        if (raceTomorrow)
                        {
                            Console.Clear();
                            break;
                        }

                        day++;
                    }
                }
                else
                {
                    Console.Clear();
                    day++;
                }
            }
        }
    }
}