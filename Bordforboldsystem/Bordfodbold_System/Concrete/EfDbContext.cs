using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Concrete
{
    public class EfDbContext : DbContext
    {
        // Get list of players from Database
        public DbSet<Player> Players { get; set; }
        // Get list of Teams from Database
        public DbSet<Team> Teams { get; set; }
        // Get list of Games from Database
        public DbSet<Game> Games { get; set; }
        // Get list of Statistics from Database
        public DbSet<Statistics> Statistics { get; set; }
    }
}