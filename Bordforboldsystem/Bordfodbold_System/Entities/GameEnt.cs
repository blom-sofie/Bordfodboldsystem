using System;

namespace Bordfodbold_System.Entities
{
    public class GameEnt
    {
        // Id is auto-incremented.
        public int id { get; }

        public int team1_id { get; set; }
        public int team2_id { get; set; }
        public int winner_team_id { get; set; }
        public int team1goals { get; set; }
        public int team2goals { get; set; }

        // Mangles i databasen!
        public DateTime date { get; set; }
    }
}