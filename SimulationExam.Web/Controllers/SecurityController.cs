//using SimulationExam.Classes.Entity;
using SimulationExam.Classes.Manager;
using SimulationExam.Web.Models;
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
                //ChristmasApplicationMongoDB db = new ChristmasApplicationMongoDB();
                //var usr = db.GetUserByEmailAndPassword(user);

                SimulationExamEntities db = new SimulationExamEntities();
                User userDb = db.User.SingleOrDefault(usr => usr.Email == user.Email && usr.Password == user.Password);
                UserManager um = new UserManager();
                
                if (userDb != null)
                {
                    Session["ScreenName"] = userDb.Name.ToString();
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