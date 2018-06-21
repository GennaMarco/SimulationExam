using SimulationExam.Classes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimulationExam.Web.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login(User user)
        {
            if (user.Email != null && user.Password != null){
                //ChristmasApplicationMongoDB db = new ChristmasApplicationMongoDB();
                //var usr = db.GetUserByEmailAndPassword(user);
                User usr = null;
                if (usr != null)
                {
                    Session["ScreenName"] = usr.ScreenName.ToString();
                    return RedirectToAction("Index", "Home", null);
                }
                else
                {
                    ModelState.AddModelError("", "Username o Password errati");
                }
                return View();
            }
            return View();
        }
    }
}