using System;
using System.ComponentModel.DataAnnotations;

namespace Bordfodbold_System.Entities
{
    public class Game
    {
        // Id is auto-incremented.
        [Key]
        public int id { get; set; }

        public int team1_id { get; set; }
        public int team2_id { get; set; }
        public int team1goals { get; set; }
        public int team2goals { get; set; }
        public bool didTeamOneWin { get; set; }
        public bool didTeamTwoWin { get; set; }

        // Mangles i databasen!
        public string date { get; set; }
    }
}