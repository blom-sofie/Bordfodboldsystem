using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordfodbold_System.Abstract;

namespace Bordfodbold_System.Controllers
{
    // Skal være logget ind, for at se indeholdte views!
    // Auto-genereret HomeController til view af Index-siden.
    public class HomeController : Controller
    {
        // Det kommer nogenlunde til at ligne nedenstående, men mon ikke det er muligt, at danne én ny klasse, der kan gøre dette for os?
        // Få klassen til at implementere de 4 interfaces i constructoren, og så anvende dependency injection på ét nyt interface, som vi så implementerer her?
        // Anden ting til note: husk, at interfacet skal indeholde den funktionalitet fra klassen, vi har tænkt os at kalde fra controlleren!

        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IStatisticsRepository _statisticsRepository;

        public HomeController(IPlayerRepository player_repo, ITeamRepository team_repo, IGameRepository game_repo, IStatisticsRepository statistics_repo)
        {
            _playerRepository = player_repo;
            _teamRepository = team_repo;
            _gameRepository = game_repo;
            _statisticsRepository = statistics_repo;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        // Ændring af dette? (Blot en idé)
        public ActionResult NewGame()
        {
            return View();
        }
    }
}