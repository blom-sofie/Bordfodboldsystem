using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Abstract
{
    // Skal implementeres af det konkrete 'EfTeamRepository'
    // Bindes til EfTeamRepository vha. Dependency Injection.
    public interface ITeamRepository
    {
        IEnumerable<TeamEnt> Teams { get; }

        // Metoder tilknyttet 'Teams'
    }
}