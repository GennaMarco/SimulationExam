using SimulationExam.Web.Models;
using SimulationExam.Web.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimulationExam.Web.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Login(User user)
        {
            if (user.Email != null && user.Password != null)
            {
                UserManager um = new UserManager();
                User userDb = um.GetUserByEmailAndPassword(user.Email, user.Password);
                
                if (userDb != null)
                {
                    Session["ScreenName"] = userDb.Name.ToString();
                    Session["Role"] = userDb.Role.Name.ToString();
                    return RedirectToAction("Index", "Home", null);
                }
                else
                {
                    this.ModelState.AddModelError("", "Username o Password errati");
                }
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Signup(User user)
        {
            if (user.Name != null && user.Email != null && user.Password != null)
            {
                string ConfirmPassword = this.Request["ConfirmPassword"];

                if(user.Password == ConfirmPassword)
                {
                    //TODO: INSERT DB
                }
                else
                {
                    this.ModelState.AddModelError("", "Le due password non coincidono");
                }
            }
            return View();
        }
    }
}