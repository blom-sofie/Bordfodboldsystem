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

        public string player1 { get; set; }
        public string player2 { get; set; }
    }
}