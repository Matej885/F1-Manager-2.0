    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace F1_Manager_2._0
    {
        public class Teams
        {
            public string TeamName { get; set; }
            public int TeamPoints { get; set; }
            public int TeamRating { get; set; }
            public string Driver1Name { get; set; }
            public int Driver1Rating { get; set; }
            public int Driver1Points { get; set; }
            public string Driver2Name { get; set; }
            public int Driver2Rating { get; set; }
            public int Driver2Points { get; set; }
            public void TeamInfo(string teamname, int teampoints, int teamrating, string driver1name, int driver1rating, int driver1points, string driver2name, int driver2rating, int driver2points)
            {
                TeamName = teamname;
                TeamPoints = teampoints;
                TeamRating = teamrating;
                Driver1Name = driver1name;
                Driver1Rating = driver1rating;
                Driver1Points = driver1points;
                Driver2Name = driver2name;
                Driver2Rating = driver2rating;
                Driver2Points = driver2points;
            }
            public static class TeamList
            {
                public static List<Teams> AllTeams = new List<Teams>()
                {
                    new Teams() { TeamName = "Red Bull", TeamPoints = 0, TeamRating = 95,
                                  Driver1Name = "Max Verstappen", Driver1Rating = 99, Driver1Points = 0,
                                  Driver2Name = "Yuki Tsunoda", Driver2Rating = 90, Driver2Points = 0 },

                    new Teams() { TeamName = "Ferrari", TeamPoints = 0, TeamRating = 92,
                                  Driver1Name = "Charles Leclerc", Driver1Rating = 95, Driver1Points = 0,
                                  Driver2Name = "Lewis Hamilton", Driver2Rating = 88, Driver2Points = 0 },

                    new Teams() { TeamName = "Mercedes", TeamPoints = 0, TeamRating = 90,
                                  Driver1Name = "Kimi Antonelli", Driver1Rating = 94, Driver1Points = 0,
                                  Driver2Name = "George Russell", Driver2Rating = 91, Driver2Points = 0 },

                    new Teams() { TeamName = "McLaren", TeamPoints = 0, TeamRating = 85,
                                  Driver1Name = "Lando Norris", Driver1Rating = 82, Driver1Points = 0,
                                  Driver2Name = "Oscar Piastri", Driver2Rating = 88, Driver2Points = 0 },

                    new Teams() { TeamName = "Alpine", TeamPoints = 0, TeamRating = 80,
                                  Driver1Name = "Pierre Gasly", Driver1Rating = 80, Driver1Points = 0,
                                  Driver2Name = "Franco Colapinto", Driver2Rating = 75, Driver2Points = 0 },

                    new Teams() { TeamName = "Aston Martin", TeamPoints = 0, TeamRating = 82,
                                  Driver1Name = "Fernando Alonso", Driver1Rating = 90, Driver1Points = 0,
                                  Driver2Name = "Lance Stroll", Driver2Rating = 70, Driver2Points = 0 },

                    new Teams() { TeamName = "Haas", TeamPoints = 0, TeamRating = 70,
                                  Driver1Name = "Esteban Ocon", Driver1Rating = 68, Driver1Points = 0,
                                  Driver2Name = "Oliver Bearman", Driver2Rating = 72, Driver2Points = 0 },

                    new Teams() { TeamName = "Williams", TeamPoints = 0, TeamRating = 65,
                                  Driver1Name = "Alex Albon", Driver1Rating = 70, Driver1Points = 0,
                                  Driver2Name = "Carlos Sainz", Driver2Rating = 60, Driver2Points = 0 },

                    new Teams() { TeamName = "Kick Sauber", TeamPoints = 0, TeamRating = 68,
                                  Driver1Name = "Nico Hulkenberg", Driver1Rating = 62, Driver1Points = 0,
                                  Driver2Name = "Gabriel Bortoleto", Driver2Rating = 60, Driver2Points = 0 },

                    new Teams() { TeamName = "Racing Bulls", TeamPoints = 0, TeamRating = 60,
                                  Driver1Name = "Liam Lawson", Driver1Rating = 65, Driver1Points = 0,
                                  Driver2Name = "Isack Hadjar", Driver2Rating = 69, Driver2Points = 0 },
                };
            }
        }
    }



