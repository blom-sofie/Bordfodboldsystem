﻿namespace Bordfodbold_System.Entities
{
    public class TeamEnt
    {
        // Id is auto-incremented.
        public int id { get; }

        public int player1_id { get; set; }
        public int player2_id { get; set; }
    }
}