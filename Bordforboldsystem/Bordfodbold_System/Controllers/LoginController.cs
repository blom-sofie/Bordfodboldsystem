using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordfodbold_System.Abstract;
using Bordfodbold_System.Controllers;
using Bordfodbold_System.Entities;

namespace Bordfodbold_System.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public LoginController(IPlayerRepository repo)
        {
            _playerRepository = repo;
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Player userModel)
        {
            try
            {
                var exists = _playerRepository.Players.Where(pla => pla.name == userModel.name)
                    .Where(pla => pla.password == userModel.password).ToArray()[0];
                if (exists != null)
                {
                    Session["userID"] = exists.id;
                    Session["userName"] = exists.name;
                    return RedirectToAction("Index", "Home");

                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return RedirectToAction("Login", "Login");
        }

        public ActionResult LogOut()
        {
            //int userId = (int) Session["userID"];
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}