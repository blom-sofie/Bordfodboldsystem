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
        public IEnumerable<Team> Teams => _context.Teams;

        public void NewTeam(int player1ID, int player2ID)
        {
            var team = Teams.FirstOrDefault(cus => cus.player1_id == player1ID && cus.player2_id == player2ID) ?? new Team();
            team.player1_id = player1ID;
            team.player2_id = player2ID;
            
            _context.Teams.Add(team);
            _context.SaveChanges();
        }
    }
}