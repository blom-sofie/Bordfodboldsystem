namespace Bordfodbold_System.Entities
{
    public class StatisticsEnt
    {
        // id is auto-incremented
        public int id { get; }

        public int player_id { get; set; }
        public int winCount { get; set; }
        public int goalCount { get; set; }
    }
}