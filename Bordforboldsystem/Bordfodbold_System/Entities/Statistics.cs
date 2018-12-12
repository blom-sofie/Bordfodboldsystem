using System.ComponentModel.DataAnnotations;

namespace Bordfodbold_System.Entities
{
    public class Statistics
    {
        // id is auto-incremented
        [Key]
        public int id { get; set; }

        public int player_id { get; set; }
        public int winCount { get; set; }
        public int goalCount { get; set; }
    }
}