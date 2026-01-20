using F1_Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using System.Media;

namespace F1_Manager_2._0
{
    public class MainMenu
    {
        public bool raceday = false;
        public int efectivity;
        public int howManyRaces = 0;
        public void Menu(Teams teams, PlayerTeam playerTeam)
        {

            while (true)
            {
                Console.WriteLine("Koľko závodov chceš odzávodiť? (max 24)");
                string input = Console.ReadLine();

                // Skúšame previesť string na číslo
                if (int.TryParse(input, out howManyRaces))
                {
                    // Skontrolujeme, či číslo nie je väčšie než 25 a nie menšie než 1
                    if (howManyRaces >= 1 && howManyRaces <= 24)
                    {
                        break; // platné číslo, ukončíme cyklus
                    }
                    else
                    {
                        Console.WriteLine("Maximálny počet závodov je 24. Skús to znova.");
                    }
                }
                else
                {
                    Console.WriteLine("Zadal si neplatné číslo. Skús to znova.");
                }
            }

            Console.WriteLine($"Budeš závodiť {howManyRaces} závodov.");


            List<Teams> allTeams = Teams.TeamList.AllTeams;
            RaceSimulation raceSimulation = new RaceSimulation(allTeams);
            Upgrades upgrades = new Upgrades();
            List<string> tempParts = new List<string>(upgrades.Parts);
            List<string> shownUpgrades = new List<string>();
            Scenes scenes = new Scenes();
            int day = 1;
            while (raceday == false)
            {
                if (playerTeam.Races == howManyRaces)
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
                        List<(string Name, int Points)> driverStandings = new List<(string, int)>();
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

                        string winner = driverStandings[0].Name;
                        SoundPlayer player = null;

                        // Vyber zvuk podľa mena víťaza
                        if (winner == "Max Verstappen")
                        {
                            player = new SoundPlayer("Sounds/Verstappen_celebration.wav");
                        }
                        else if (winner == "Yuki Tsunoda")
                        {
                            player = new SoundPlayer("Sounds/Tsunoda_celebration.wav");
                        }
                        else if (winner == "Charles Leclerc")
                        {
                            player = new SoundPlayer("Sounds/Leclerc_celebration.wav");
                        }
                        else if (winner == "Lewis Hamilton")
                        {
                            player = new SoundPlayer("Sounds/Hamilton_celebration.wav");
                        }
                        else if (winner == "Kimi Antonelli")
                        {
                            player = new SoundPlayer("Sounds/Antonelli_celebration.wav");
                        }
                        else if (winner == "George Russell")
                        {
                            player = new SoundPlayer("Sounds/Russell_celebration.wav");
                        }
                        else if (winner == "Lando Norris")
                        {
                            player = new SoundPlayer("Sounds/Norris_celebration.wav");
                        }
                        else if (winner == "Oscar Piastri")
                        {
                            player = new SoundPlayer("Sounds/Piastri_celebration.wav");
                        }
                        else if (winner == "Pierre Gasly")
                        {
                            player = new SoundPlayer("Sounds/Gasly_celebration.wav");
                        }
                        else if (winner == "Franco Colapinto")
                        {
                            player = new SoundPlayer("Sounds/Colapinto_celebration.wav");
                        }
                        else if (winner == "Fernando Alonso")
                        {
                            player = new SoundPlayer("Sounds/Alonso_celebration.wav");
                        }
                        else if (winner == "Lance Stroll")
                        {
                            player = new SoundPlayer("Sounds/Stroll_celebration.wav");
                        }
                        else if (winner == "Esteban Ocon")
                        {
                            player = new SoundPlayer("Sounds/Ocon_celebration.wav");
                        }
                        else if (winner == "Oliver Bearman")
                        {
                            player = new SoundPlayer("Sounds/Bearman_celebration.wav");
                        }
                        else if (winner == "Alex Albon")
                        {
                            player = new SoundPlayer("Sounds/Albon_celebration.wav");
                        }
                        else if (winner == "Carlos Sainz")
                        {
                            player = new SoundPlayer("Sounds/Sainz_celebration.wav");
                        }
                        else if (winner == "Nico Hulkenberg")
                        {
                            player = new SoundPlayer("Sounds/Hulkenberg_celebration.wav");
                        }
                        else if (winner == "Gabriel Bortoleto")
                        {
                            player = new SoundPlayer("Sounds/Bortoleto_celebration.wav");
                        }
                        else if (winner == "Liam Lawson")
                        {
                            player = new SoundPlayer("Sounds/Lawson_celebration.wav");
                        }
                        else if (winner == "Isack Hadjar")
                        {
                            player = new SoundPlayer("Sounds/Hadjar_celebration.wav");
                        }
                        else if (winner == "Sebastian Vettel")
                        {
                            player = new SoundPlayer("Sounds/Vettel_celebration.wav");
                        }
                        else if (winner == "Josef Král")
                        {

                        }
                        else
                        {
                            Console.WriteLine("Chyba! ");
                        }
                        // Prehratie zvuku a počkanie, kým skončí
                        player.Play();

                        foreach (var t in teamStandings)
                        {
                            // Skontrolujeme, či je to tvoj tím
                            if (t.Name == playerTeam.teamName)
                            {
                                playerTeam.Standings = place;
                            }

                            // Nastavenie farby podľa miesta
                            if (place == 1)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else if (place == 2)
                                Console.ForegroundColor = ConsoleColor.Gray;
                            else if (place == 3)
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            else
                                Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(100);
                            Console.WriteLine($"{place}. {t.Name} - {t.Points} bodov");
                            place++;
                        }

                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\nPORADIE JAZDCOV:");
                        place = 1;
                        foreach (var d in driverStandings)
                        {
                            if (place == 1)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else if (place == 2)
                                Console.ForegroundColor = ConsoleColor.Gray;
                            else if (place == 3)
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            else
                                Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{place}. {d.Name} - {d.Points} bodov");
                            place++;
                            Thread.Sleep(100);
                        }
                        Console.WriteLine("Pre vyhodnotenie sezóny od šéfa zmačkni Enter !");
                        Console.ReadLine();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        day = 1;
                        bool Done = false;
                        if (playerTeam.driver1name == winner || playerTeam.driver2name == winner)
                        {
                            // Po skončení zvuku môžeš vypísať text
                            Thread.Sleep(1000);


                            Console.WriteLine($"{winner} vyhral šampiónsky titul! Úžasný výkon celého tímu.");
                            Thread.Sleep(1000);
                            Console.WriteLine("Bonus za splnenie cieľa je: 150 000 000 $");
                            playerTeam.Money += 150000000;
                            playerTeam.TeamPower += 10;
                            Thread.Sleep(1000);
                            Console.WriteLine("Vaše auto sa zrýchli o 10 bodov na začiatku ďalšej sezóny!");
                            Console.ReadLine();
                            Console.WriteLine("Chceš si ponechať jazdcov ale ich nechať odísť? ");
                            Console.WriteLine($"Tvoj 1. jazdec ťa stojí: {playerTeam.driver1name} - {playerTeam.driver1cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver1}");
                            Console.WriteLine($"Tvoj 2. jazdec ťa stojí: {playerTeam.driver2name} - {playerTeam.driver2cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver2}");
                            Console.WriteLine("1 = Áno, ponechať si jazdcov 2 = Nie, neponechať");
                            string input3 = Console.ReadLine();
                            if (input3 == "1")
                            {
                                if (playerTeam.Money >= playerTeam.driver1cost && playerTeam.Money - playerTeam.driver1cost >= playerTeam.driver2cost)
                                {
                                    playerTeam.Money -= playerTeam.driver1cost;
                                    playerTeam.Money -= playerTeam.driver2cost;
                                    Console.WriteLine("Obaja jazdci boli zaplatení a zostávajú v tíme.");
                                }
                                else
                                {
                                    Console.WriteLine("Nemáš dosť peňazí na zaplatenie oboch jazdcov. Budeš si musieť vybrať nových jazdcov v ďalšom menu."); 
                                    scenes.ChooseDrivers(playerTeam);
                                }
                            }
                            else if (input3 == "2")
                            {
                                Console.WriteLine("Tvojich jazdcov si prepúšťaš.");
                                scenes.ChooseDrivers(playerTeam);
                            }
                            else
                            {
                                Console.WriteLine("Neplatný vstup.");
                            }

                        }
                        if (playerTeam.Standings == 1)
                        {
                            Console.WriteLine("VYHRALI STE KONŠTRUKTÉRSKY TITUL! Úžasný výkon celého tímu. Vaša stratégia, vedenie a odhodlanie priniesli najvyšší úspech.");
                            Console.WriteLine("Bonus za splnenie cieľa je: 100 000 000 $");
                            playerTeam.Money += 100000000;
                            playerTeam.TeamPower += 10;
                            Console.WriteLine("Vaše auto sa zrýchli o 10 bodov na začiatku ďalšej sezóny!");

                            Console.WriteLine("Teraz si počkáme na ďalšiu sezónu...");
                            Console.WriteLine("Načítavam novu sezónu...");
                            Console.ReadLine();
                            Console.Clear();
                            playerTeam.TeamPower += 10;
                            playerTeam.Money += 150000000;
                            foreach (var t in Teams.TeamList.AllTeams)
                            {
                                t.TeamPoints = 0;
                                t.Driver1Points = 0;
                                t.Driver2Points = 0;
                            }
                            playerTeam.pointsDriver1 = 0;
                            playerTeam.pointsDriver2 = 0;
                            playerTeam.Races = 0;
                            break;
                        }
                        else
                        {

                            if (playerTeam.teamtype == "1")
                            {
                                if (playerTeam.Standings <= 9)
                                {
                                    Console.WriteLine($"{winner} VYHRAL TITUL!");
                                    Console.WriteLine("Výborne, práca bola presne podľa očakávaní. Vaša flexibilita a rozhodnosť priniesli výsledok.");
                                    Console.WriteLine("Bonus za splnenie cieľa: 20 000 000 $");
                                    playerTeam.Money += 20000000;
                                    playerTeam.teamtype = "2";
                                    while (true)
                                    {
                                        Console.WriteLine("Chceš si ponechať jazdcov ale ich nechať odísť? ");
                                        Console.WriteLine($"Tvoj 1. jazdec ťa stojí: {playerTeam.driver1name} - {playerTeam.driver1cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver1}");
                                        Console.WriteLine($"Tvoj 2. jazdec ťa stojí: {playerTeam.driver2name} - {playerTeam.driver2cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver2}");
                                        while (true)
                                        {
                                            Console.WriteLine("1 = Áno, ponechať si jazdcov 2 = Nie, neponechať");
                                            string input3 = Console.ReadLine();
                                            if (input3 == "1")
                                            {
                                                if (playerTeam.Money >= playerTeam.driver1cost && playerTeam.Money - playerTeam.driver1cost >= playerTeam.driver2cost)
                                                {
                                                    playerTeam.Money -= playerTeam.driver1cost;
                                                    playerTeam.Money -= playerTeam.driver2cost;
                                                    Console.WriteLine("Obaja jazdci boli zaplatení a zostávajú v tíme.");
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nemáš dosť peňazí na zaplatenie oboch jazdcov. Budeš si musieť vybrať nových jazdcov v ďalšom menu.");
                                                    Console.ReadLine();
                                                }
                                            }
                                            else if (input3 == "2")
                                            {
                                                Console.WriteLine("Tvojich jazdcov si prepúšťaš.");
                                                scenes.ChooseDrivers(playerTeam);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Neplatný vstup.");
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else if (playerTeam.Standings > 9)
                                {
                                    Console.WriteLine("Tento výkon je neprijateľný. Ako riaditeľ tímu ste zlyhal v základných úlohách. Musíme hľadať nového vedúceho.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    Environment.Exit(0);
                                }
                            }
                            else if (playerTeam.teamtype == "2")
                            {
                                if (playerTeam.Standings <= 6)
                                {
                                    Console.WriteLine($"{winner} VYHRAL TITUL!");
                                    Console.WriteLine("Dobrý výkon. Presne takto očakávame, že náš tím bude napredovať. Pokračujte v tejto kvalite.");
                                    Console.WriteLine("Bonus za splnenie cieľa: 50 000 000 $");
                                    playerTeam.Money += 50000000;
                                    Console.Clear();
                                    Console.WriteLine("Chceš si ponechať jazdcov ale ich nechať odísť? ");
                                    Console.WriteLine($"Tvoj 1. jazdec ťa stojí: {playerTeam.driver1name} - {playerTeam.driver1cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver1}");
                                    Console.WriteLine($"Tvoj 2. jazdec ťa stojí: {playerTeam.driver2name} - {playerTeam.driver2cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver2}");
                                    Console.WriteLine("1 = Áno, ponechať si jazdcov 2 = Nie, neponechať");
                                    string input3 = Console.ReadLine();
                                    if (input3 == "1")
                                    {
                                        if (playerTeam.Money >= playerTeam.driver1cost && playerTeam.Money - playerTeam.driver1cost >= playerTeam.driver2cost)
                                        {
                                            playerTeam.Money -= playerTeam.driver1cost;
                                            playerTeam.Money -= playerTeam.driver2cost;
                                            Console.WriteLine("Obaja jazdci boli zaplatení a zostávajú v tíme.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nemáš dosť peňazí na zaplatenie oboch jazdcov. Budeš si musieť vybrať nových jazdcov v ďalšom menu.");
                                            scenes.ChooseDrivers(playerTeam);
                                        }
                                    }
                                    else if (input3 == "2")
                                    {
                                        Console.WriteLine("Tvojich jazdcov si prepúšťaš.");
                                        scenes.ChooseDrivers(playerTeam);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Neplatný vstup.");
                                    }
                                }
                                else if (playerTeam.Standings > 6)
                                {
                                    Console.WriteLine("Výsledky tímu sú katastrofálne. Vaše rozhodnutia výrazne ohrozili budúcnosť projektu. Vaša pozícia sa ruší.");
                                    Console.ReadLine();
                                    Environment.Exit(0);
                                }
                            }
                            else if (playerTeam.teamtype == "3")
                            {
                                if (playerTeam.Standings <= 5)
                                {
                                    Console.WriteLine($"{winner} VYHRAL TITUL!");
                                    Console.WriteLine("Splnenie cieľa je uspokojivé. Tento výsledok posilňuje našu pozíciu a budúcnosť tímu vyzerá perspektívne.");
                                    Console.WriteLine("Bonus za splnenie cieľa: 80 000 000 $");
                                    playerTeam.Money += 80000000;
                                    Thread.Sleep(2000);
                                    Console.WriteLine("Načíavam novu sezónu...");
                                    Console.Clear();
                                    playerTeam.teamtype = "4";
                                    Console.WriteLine("Chceš si ponechať jazdcov ale ich nechať odísť? ");
                                    Console.WriteLine($"Tvoj 1. jazdec ťa stojí: {playerTeam.driver1name} - {playerTeam.driver1cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver1}");
                                    Console.WriteLine($"Tvoj 2. jazdec ťa stojí: {playerTeam.driver2name} - {playerTeam.driver2cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver2}");
                                    Console.WriteLine("1 = Áno, ponechať si jazdcov 2 = Nie, neponechať");
                                    string input3 = Console.ReadLine();
                                    if (input3 == "1")
                                    {
                                        if (playerTeam.Money >= playerTeam.driver1cost && playerTeam.Money - playerTeam.driver1cost >= playerTeam.driver2cost)
                                        {
                                            playerTeam.Money -= playerTeam.driver1cost;
                                            playerTeam.Money -= playerTeam.driver2cost;
                                            Console.WriteLine("Obaja jazdci boli zaplatení a zostávajú v tíme.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nemáš dosť peňazí na zaplatenie oboch jazdcov. Budeš si musieť vybrať nových jazdcov v ďalšom menu.");
                                            scenes.ChooseDrivers(playerTeam);
                                        }
                                    }
                                    else if (input3 == "2")
                                    {
                                        Console.WriteLine("Tvojich jazdcov si prepúšťaš.");
                                        scenes.ChooseDrivers(playerTeam);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Neplatný vstup.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Vaše výkony a chyby sú neprijateľné. Vaša pozícia riaditeľa tímu sa končí okamžite");
                                    Console.ReadLine();
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                if (playerTeam.Standings <= 3)
                                {
                                    Console.WriteLine($"{winner} VYHRAL TITUL!");
                                    Console.WriteLine("Výborný výkon. Naša technológia a know-how sa jasne prejavili a priniesli očakávaný výsledok.");
                                    Console.WriteLine("Bonus za splnenie cieľa: 100 000 000 $");
                                    playerTeam.Money += 100000000;
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if (playerTeam.Standings > 3)
                                {
                                    Console.WriteLine($"Výsledky sú neprijateľné. Tím nedosiahol ani minimálne štandardy. Kvôli vám je teraz značka {playerTeam.teamName} pošpinená. Vaša pozícia riaditeľa tímu sa končí okamžite.");
                                    Console.ReadLine();
                                    Environment.Exit(0);
                                }
                                Console.WriteLine("Chceš si ponechať jazdcov ale ich nechať odísť? ");
                                Console.WriteLine($"Tvoj 1. jazdec ťa stojí: {playerTeam.driver1name} - {playerTeam.driver1cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver1}");
                                Console.WriteLine($"Tvoj 2. jazdec ťa stojí: {playerTeam.driver2name} - {playerTeam.driver2cost.ToString("N0")} $ a za túto sezónu získal {playerTeam.pointsDriver2}");
                                Console.WriteLine("1 = Áno, ponechať si jazdcov 2 = Nie, neponechať");
                                string input3 = Console.ReadLine();
                                if (input3 == "1")
                                {
                                    if (playerTeam.Money >= playerTeam.driver1cost && playerTeam.Money - playerTeam.driver1cost >= playerTeam.driver2cost)
                                    {
                                        playerTeam.Money -= playerTeam.driver1cost;
                                        playerTeam.Money -= playerTeam.driver2cost;
                                        Console.WriteLine("Obaja jazdci boli zaplatení a zostávajú v tíme.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nemáš dosť peňazí na zaplatenie oboch jazdcov. Budeš si musieť vybrať nových jazdcov v ďalšom menu.");
                                        Console.ReadLine();
                                        scenes.ChooseDrivers(playerTeam);
                                    }
                                }
                                else if (input3 == "2")
                                {
                                    Console.WriteLine("Tvojich jazdcov si prepúšťaš.");
                                    scenes.ChooseDrivers(playerTeam);
                                }
                                else
                                {
                                    Console.WriteLine("Neplatný vstup.");
                                }
                            }
                            foreach (var t in Teams.TeamList.AllTeams)
                            {
                                t.TeamPoints = 0;
                                t.Driver1Points = 0;
                                t.Driver2Points = 0;
                            }
                            playerTeam.pointsDriver1 = 0;
                            playerTeam.pointsDriver2 = 0;
                            playerTeam.Races = 0;
                            break;
                        }
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
                Console.WriteLine("5. Instatne preskočiť na deň pred závodom");
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
                    Console.WriteLine($"Peniaze: {playerTeam.Money.ToString("N0")} $ ");
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
                        if (playerTeam.Races == howManyRaces)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sezóna skončila!");
                            break;
                        }
                        else if (raceTomorrow)
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