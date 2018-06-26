using SimulationExam.Web.Models;
using SimulationExam.Web.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimulationExam.Web.Controllers
{
    public class ActivityController : BaseController
    {
        private List<string> rolesAllowedToRoute;
        public ActivityController()
        {
            rolesAllowedToRoute = new List<string>();
        }
        // GET: Activity
        public ActionResult Index()
        {
            rolesAllowedToRoute.Add("Partecipante");
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles(rolesAllowedToRoute);
            if (redirectToHome != null)
            {
                return redirectToHome;
            }
            ActivityManager am = new ActivityManager();
            ICollection<Activity> activities = am.GetActivities();
            return View(activities);
        }
    }
}