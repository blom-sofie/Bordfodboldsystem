using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordfodbold_System.Entities
{
    public class Player
    {
        // Id is auto-incremented.
        public int id { get; }

        public string name { get; set; }
        public string password { get; set; }
    }
}