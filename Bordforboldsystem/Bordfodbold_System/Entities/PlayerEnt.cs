using System.ComponentModel.DataAnnotations;

namespace Bordfodbold_System.Entities
{
    public class PlayerEnt
    {
        // Id is auto-incremented.
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public string password { get; set; }
    }
}