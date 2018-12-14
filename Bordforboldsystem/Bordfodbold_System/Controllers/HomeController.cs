using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordfodbold_System.Abstract;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IStatisticsRepository _statisticsRepository;

        public HomeController(IPlayerRepository playerRepo, ITeamRepository teamRepo, IGameRepository gameRepo, IStatisticsRepository statisticsRepo)
        {
            _playerRepository = playerRepo;
            _teamRepository = teamRepo;
            _gameRepository = gameRepo;
            _statisticsRepository = statisticsRepo;
        }

        public ActionResult Index()
        {
            List<Player> player_repo = _playerRepository.Players.ToList();
            List<Team> team_repo = _teamRepository.Teams.ToList();
            List<Game> game_repo = _gameRepository.Games.OrderByDescending(g => g.date).Take(50).ToList();
            List<Statistics> statistics_repo = _statisticsRepository.Statistics.ToList();

            List<dynamic> list = new List<dynamic>();

            if (game_repo != null && game_repo.Any())
            {
                foreach (var game in game_repo)
                {
                    dynamic to = new ExpandoObject();
                    to.player_one_name = player_repo.FirstOrDefault(x => x.id == team_repo.FirstOrDefault(y => y.id == game.team1_id).player1_id).name;
                    to.player_two_name = player_repo.FirstOrDefault(x => x.id == team_repo.FirstOrDefault(y => y.id == game.team1_id).player2_id).name;
                    to.player_thr_name = player_repo.FirstOrDefault(x => x.id == team_repo.FirstOrDefault(y => y.id == game.team2_id).player1_id).name;
                    to.player_fou_name = player_repo.FirstOrDefault(x => x.id == team_repo.FirstOrDefault(y => y.id == game.team2_id).player2_id).name;
                    to.team1_id = game.team1_id;
                    to.team2_id = game.team2_id;
                    to.team1goals = game.team1goals;
                    to.team2goals = game.team2goals;
                    to.date = game.date;
                    list.Add(to);
                }
            }
            return View(list);
        }

        public ViewResult NewGame()
        {
            return View(_playerRepository.Players.Where(x => x.deleted != true).Where(y => y.id != 1));
        }

        [HttpPost]
        public ActionResult NewGame
        (
            string DropDownListForTeamOnePlayerOne,
            string DropDownListForTeamOnePlayerTwo,
            string DropDownListForTeamTwoPlayerOne,
            string DropDownListForTeamTwoPlayerTwo,
            int PlayerOneTeamOneGoals,
            int PlayerTwoTeamOneGoals,
            int PlayerOneTeamTwoGoals,
            int PlayerTwoTeamTwoGoals
        )
        {
            bool isTeamOneWinner = false;
            bool isTeamTwoWinner = false;
            if(PlayerOneTeamOneGoals + PlayerTwoTeamOneGoals > PlayerOneTeamTwoGoals + PlayerTwoTeamTwoGoals)
            {
                isTeamOneWinner = true;
            }
            else if(PlayerOneTeamOneGoals + PlayerTwoTeamOneGoals == PlayerOneTeamTwoGoals + PlayerTwoTeamTwoGoals)
            {
                isTeamOneWinner = true;
                isTeamTwoWinner = true;
            }
            else
            {
                isTeamTwoWinner = true;
            }

            if (isTeamOneWinner && !isTeamTwoWinner)
            {
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamOnePlayerOne), true, PlayerOneTeamOneGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamOnePlayerTwo), true, PlayerTwoTeamOneGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamTwoPlayerOne), false, PlayerOneTeamTwoGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamTwoPlayerTwo), false, PlayerTwoTeamTwoGoals);
            }
            else if (isTeamOneWinner && isTeamTwoWinner)
            {
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamOnePlayerOne), true, PlayerOneTeamOneGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamOnePlayerTwo), true, PlayerTwoTeamOneGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamTwoPlayerOne), true, PlayerOneTeamTwoGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamTwoPlayerTwo), true, PlayerTwoTeamTwoGoals);
            }
            else
            {
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamOnePlayerOne), false, PlayerOneTeamOneGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamOnePlayerTwo), false, PlayerTwoTeamOneGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamTwoPlayerOne), true, PlayerOneTeamTwoGoals);
                _statisticsRepository.SaveStatistics(int.Parse(DropDownListForTeamTwoPlayerTwo), true, PlayerTwoTeamTwoGoals);
            }

            _teamRepository.NewTeam(int.Parse(DropDownListForTeamOnePlayerOne), int.Parse(DropDownListForTeamOnePlayerTwo));
            _teamRepository.NewTeam(int.Parse(DropDownListForTeamTwoPlayerOne), int.Parse(DropDownListForTeamTwoPlayerTwo));

            int Team1ID = _teamRepository.Teams.OrderByDescending(item => item.id).First().id;
            int Team2ID = _teamRepository.Teams.OrderByDescending(item => item.id).Skip(1).First().id;

            _gameRepository.NewGame
            (
                Team1ID,
                Team2ID,
                (PlayerOneTeamOneGoals + PlayerTwoTeamOneGoals),
                (PlayerOneTeamTwoGoals + PlayerTwoTeamTwoGoals),
                isTeamOneWinner,
                isTeamTwoWinner,
                DateTime.Now.ToString()
            );
            return RedirectToAction("index");
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
        public ActionResult NewUser(Entities.Player player)
        {
            if (ModelState.IsValid)
            {
                _playerRepository.SavePlayer(player);
                TempData["message"] = string.Format("{0} has been saved", player.name);

                return RedirectToAction("Index");
            }
            else
            {
                return View(player);
            }
        }

        public ActionResult EditUser()
        {
            return View(_playerRepository.Players.Where(x => x.deleted != true).OrderByDescending(x => x.id));
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