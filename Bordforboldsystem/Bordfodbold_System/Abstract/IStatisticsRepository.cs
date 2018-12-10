using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Abstract
{
    // Skal implementeres af det konkrete 'EfStatisticsRepository'
    // Bindes til EfStatisticsRepository vha. Dependency Injection.
    public interface IStatisticsRepository
    {
        IEnumerable<StatisticsEnt> Statistics { get; }

        // Metoder tilknyttet 'Statistics'
    }
}