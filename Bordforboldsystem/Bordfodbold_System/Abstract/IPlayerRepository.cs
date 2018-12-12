using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Abstract
{
    // Skal implementeres af det konkrete 'EfPlayerRepository'
    // Bindes til EfPlayerRepository vha. Dependency Injection.
    public interface IPlayerRepository
    {
        IEnumerable<Player> Players { get; }

        void SavePlayer(Player player);
        void DeletePlayer(int id);

        // Metoder tilknyttet 'Players'
    }
}
