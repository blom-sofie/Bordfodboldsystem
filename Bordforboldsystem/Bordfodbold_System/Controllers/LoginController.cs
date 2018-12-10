using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordfodbold_System.Controllers;

namespace Bordfodbold_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Player userModel)
        {
            using (LoginDataBaseEntities db = new LoginDataBaseEntities())
            {
                var userDetails = db.Players.FirstOrDefault(x => x.name == userModel.name && x.password == userModel.password);
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Incorrect credentials!";
                    return View("Login", userModel);
                }
                Session["userID"] = userDetails.id;
                Session["userName"] = userDetails.name;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            //int userId = (int) Session["userID"];
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}