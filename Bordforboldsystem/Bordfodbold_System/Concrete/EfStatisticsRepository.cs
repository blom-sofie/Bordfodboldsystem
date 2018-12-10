using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordfodbold_System.Abstract;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Concrete
{
    public class EfStatisticsRepository : IStatisticsRepository
    {
        // Hent IEnumerable liste af Statistics fra EfDbContext
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<StatisticsEnt> Statistics => _context.Statistics;

        // Metoder
    }
}