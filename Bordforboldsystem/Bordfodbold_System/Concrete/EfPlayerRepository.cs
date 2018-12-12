using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordfodbold_System.Abstract;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Concrete
{
    public class EfPlayerRepository : IPlayerRepository
    {
        // Hent IEnumerable liste af Players fra EfDbContext
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<Player> Players => _context.Players;

        public void SavePlayer(Player player) {
            if (player.id == 0) {
                _context.Players.Add(player);
            }
            else {
                Player dbEntry = _context.Players.Find(player.id);
                if (dbEntry != null) {
                    dbEntry.name = player.name;
                    dbEntry.password = player.password;
                }
            }
            _context.SaveChanges();
        }
        
        // Metoder
    }
}