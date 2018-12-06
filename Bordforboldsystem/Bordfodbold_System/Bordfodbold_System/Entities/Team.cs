using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordfodbold_System.Entities
{
    public class Team
    {
        // Id is auto-incremented.
        public int id { get; }

        public Player player1 { get; set; }
        public Player player2 { get; set; }
    }
}