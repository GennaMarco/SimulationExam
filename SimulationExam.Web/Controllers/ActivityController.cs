using SimulationExam.Web.Models;
using SimulationExam.Web.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimulationExam.Web.Controllers
{
    public class ActivityController : Controller
    {
        private List<string> allowedRoles;

        public ActivityController()
        {
            RoleManager rm = new RoleManager();
            allowedRoles = new List<string>();
            allowedRoles.Add(rm.GetRoleByName("Organizzatore").Name);
        }
        // GET: Activity
        public ActionResult Index()
        {
            if (this.allowedRoles.Contains(Session["Role"]))
            {
                ActivityManager am = new ActivityManager();
                ICollection<Activity> activities = am.GetActivities();
                return View(activities);
            }
            TempData["errorMessage"] = "Non hai i permessi per visualizzare questa pagina";
            return RedirectToAction("Index", "Home", null);
        }
    }
}