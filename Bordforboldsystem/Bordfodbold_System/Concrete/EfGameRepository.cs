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

        public void NewGame(int team1ID, int team2ID, int teamOneGoals, int teamTwoGoals, bool didTeamOneWin, bool didTeamTwoWin, string now)
        {
            Game game = new Game() {
                team1_id = team1ID,
                team2_id = team2ID,
                team1goals = teamOneGoals,
                team2goals = teamTwoGoals,
                didTeamOneWin = didTeamOneWin,
                didTeamTwoWin = didTeamTwoWin,
                date = now
            };

            _context.Games.Add(game);
            _context.SaveChanges();
        }

        // Metoder
    }
}