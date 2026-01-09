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
        public int Driver1Cost { get; set; }
        public int Driver2Cost { get; set; }

        public static class TeamList
        {
            public static List<Teams> AllTeams = new List<Teams>()
            {
                new Teams() { TeamName = "Red Bull", TeamPoints = 0, TeamRating = 120,
                    Driver1Name = "Max Verstappen", Driver1Rating = 120, Driver1Points = 0, Driver1Cost = 85000000,
                    Driver2Name = "Yuki Tsunoda", Driver2Rating = 50, Driver2Points = 0, Driver2Cost = 1000000 },

                new Teams() { TeamName = "Ferrari", TeamPoints = 0, TeamRating = 110,
                    Driver1Name = "Charles Leclerc", Driver1Rating = 100, Driver1Points = 0, Driver1Cost = 70000000,
                    Driver2Name = "Lewis Hamilton", Driver2Rating = 90, Driver2Points = 0, Driver2Cost = 83000000 },

                new Teams() { TeamName = "Mercedes", TeamPoints = 0, TeamRating = 130,
                    Driver1Name = "Kimi Antonelli", Driver1Rating = 80, Driver1Points = 0, Driver1Cost = 38000000,
                    Driver2Name = "George Russell", Driver2Rating = 90, Driver2Points = 0, Driver2Cost = 45000000 },

                new Teams() { TeamName = "McLaren", TeamPoints = 0, TeamRating = 150,
                    Driver1Name = "Lando Norris", Driver1Rating = 100, Driver1Points = 0, Driver1Cost = 70000000,
                    Driver2Name = "Oscar Piastri", Driver2Rating = 95, Driver2Points = 0, Driver2Cost = 67000000 },

                new Teams() { TeamName = "Alpine", TeamPoints = 0, TeamRating = 80,
                    Driver1Name = "Pierre Gasly", Driver1Rating = 70, Driver1Points = 0, Driver1Cost = 15000000,
                    Driver2Name = "Franco Colapinto", Driver2Rating = 10, Driver2Points = 0, Driver2Cost = 500000 },

                new Teams() { TeamName = "Aston Martin", TeamPoints = 0, TeamRating = 90,
                    Driver1Name = "Fernando Alonso", Driver1Rating = 90, Driver1Points = 0, Driver1Cost = 50000000,
                    Driver2Name = "Lance Stroll", Driver2Rating = 5, Driver2Points = 0, Driver2Cost = 1000000 },

                new Teams() { TeamName = "Haas", TeamPoints = 0, TeamRating = 90,
                    Driver1Name = "Esteban Ocon", Driver1Rating = 60, Driver1Points = 0, Driver1Cost = 5000000,
                    Driver2Name = "Oliver Bearman", Driver2Rating = 70, Driver2Points = 0, Driver2Cost = 1000000 },

                new Teams() { TeamName = "Williams", TeamPoints = 0, TeamRating = 100,
                    Driver1Name = "Alex Albon", Driver1Rating = 75, Driver1Points = 0, Driver1Cost = 25000000,
                    Driver2Name = "Carlos Sainz", Driver2Rating = 90, Driver2Points = 0, Driver2Cost = 42000000 },

                new Teams() { TeamName = "Kick Sauber", TeamPoints = 0, TeamRating = 80,
                    Driver1Name = "Nico Hulkenberg", Driver1Rating = 65, Driver1Points = 0, Driver1Cost = 10000000,
                    Driver2Name = "Gabriel Bortoleto", Driver2Rating = 72, Driver2Points = 0, Driver2Cost = 5000000 },

                new Teams() { TeamName = "Racing Bulls", TeamPoints = 0, TeamRating = 90,
                    Driver1Name = "Liam Lawson", Driver1Rating = 60, Driver1Points = 0, Driver1Cost = 1000000,
                    Driver2Name = "Isack Hadjar", Driver2Rating = 80, Driver2Points = 0, Driver2Cost = 1000000 },
            };
        }
    }
}
