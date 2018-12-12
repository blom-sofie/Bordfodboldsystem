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

        // Metoder tilknyttet 'Games'

        // test
    }
}