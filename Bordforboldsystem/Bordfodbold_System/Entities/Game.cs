using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordfodbold_System.Entities
{
    public class Game
    {
        // Id is auto-incremented.
        public int id { get; }

        public Team team1 { get; set; }
        public Team team2 { get; set; }
        public int winner { get; set; }
        public int team1goals { get; set; }
        public int team2goals { get; set; }

        // Mangles i databasen!
        public DateTime date { get; set; }
    }
}