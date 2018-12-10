namespace Bordfodbold_System.Entities
{
    public class PlayerEnt
    {
        // Id is auto-incremented.
        public int id { get; }

        public string name { get; set; }
        public string password { get; set; }
    }
}