using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordfodbold_System.Abstract;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Controllers
{
    // Skal være logget ind, for at se indeholdte views!
    // Auto-genereret HomeController til view af Index-siden.
    public class HomeController : Controller
    {
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

        public HomeController(IPlayerRepository player_repo) {
        _playerRepository = player_repo;
    }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult NewGame()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            bool found = _playerRepository.Players.Any(m => m.id == id);
            if (found && id != 1)
            {
                _playerRepository.DeletePlayer(id);
            }
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult NewUser(Entities.Player player) {
            if (ModelState.IsValid) {
                _playerRepository.SavePlayer(player);
                TempData["message"] = string.Format("{0} has been saved", player.name);
               
                return RedirectToAction("Index");
            }
            else {
                return View(player);
            }
        }

        public ActionResult EditUser()
        {
            return View(_playerRepository.Players);
        }

        [HttpPost]
        public ActionResult EditUser(Entities.Player player)
        {
            if (ModelState.IsValid)
            {
                _playerRepository.SavePlayer(player);
                TempData["message"] = string.Format("{0} has been edited", player.name);

                return RedirectToAction("Index");
            }
            else
            {
                return View(_playerRepository.Players);
            }
        }



    }
}