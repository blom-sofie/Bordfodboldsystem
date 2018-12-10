using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordfodbold_System.Abstract;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Concrete
{
    public class EfTeamRepository : ITeamRepository
    {
        // Hent IEnumerable liste af Teams fra EfDbContext
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<TeamEnt> Teams => _context.Teams;

        // Metoder
    }
}