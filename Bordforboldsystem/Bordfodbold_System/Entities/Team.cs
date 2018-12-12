using System.ComponentModel.DataAnnotations;

namespace Bordfodbold_System.Entities
{
    public class Team
    {
        // Id is auto-incremented.
        [Key]
        public int id { get; set; }

        public int player1_id { get; set; }
        public int player2_id { get; set; }
    }
}