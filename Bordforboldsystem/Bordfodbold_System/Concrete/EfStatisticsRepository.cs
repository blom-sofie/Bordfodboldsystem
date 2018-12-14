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
        public IEnumerable<Statistics> Statistics => _context.Statistics;


        public void SaveStatistics(int playerId, bool didPlayerWin, int playerGoals)
        {
            var statistics = Statistics.FirstOrDefault(cus => cus.player_id == playerId) ?? new Statistics();
            var a1 = statistics.goalCount;

            statistics.player_id = playerId;
            statistics.goalCount += playerGoals;

            if (didPlayerWin)
                statistics.winCount++;
            else
                statistics.lossCount++;

            if(statistics.id == 0)
            {
                _context.Statistics.Add(statistics);
            }
            _context.SaveChanges();
        }
    }
}