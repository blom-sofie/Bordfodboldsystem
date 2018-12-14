using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Abstract
{
    // Skal implementeres af det konkrete 'EfGameRepository'
    // Bindes til EfGameRepository vha. Dependency Injection.
    public interface IGameRepository
    {
        IEnumerable<Game> Games { get; }

        void NewGame(int team1ID, int team2ID, int teamOneGoals, int teamTwoGoals, bool didTeamOneWin, bool didTeamTwoWin, string now);

        // Metoder tilknyttet 'Games'

        // test
    }
}