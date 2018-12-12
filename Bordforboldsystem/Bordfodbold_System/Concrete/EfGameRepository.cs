using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordfodbold_System.Abstract;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Concrete
{
    public class EfGameRepository : IGameRepository
    {
        // Hent IEnumerable liste af Games fra EfDbContext
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<Game> Games => _context.Games;

        // Metoder
    }
}