using SimulationExam.Web.Models;
using SimulationExam.Web.Models.Manager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimulationExam.Web.Controllers
{
    public class ActivityController : BaseController
    {
        // GET: Activity
        public ActionResult Index()
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            this.allowedRoles.Add(this.ROLE_PARTECIPANT);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }
            ActivityManager am = new ActivityManager();
            ICollection<Activity> activities = am.GetActivities();
            return View(activities);
        }

        public ActionResult Edit(int id)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }
            ActivityManager am = new ActivityManager();
            Activity activity = am.GetActivty(id);
            return View(activity);
        }

        [HttpPost]
        public ActionResult Save(IList<string> listDates, IList<string> listDateIds)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }
            int activityId = Int32.Parse(Request.Form["activityId"]);
            string activityName = Request.Form["activityName"];

            ActivityManager am = new ActivityManager();
            Activity activity = am.GetActivty(activityId);

            activity.Name = activityName;

            activity.ActivityDate.Clear();
            ActivityDateManager adv = new ActivityDateManager();
            for (int i = 0; i<listDateIds.Count; i++)
            {
                ActivityDate activityDate = adv.GetActivityDateById(Int32.Parse(listDateIds[i]));
                string[] date = listDates[i].Split('/');

                int year = Int32.Parse(date[2]);
                int month = Int32.Parse(date[1]);
                int day = Int32.Parse(date[0]);

                activityDate.Date = new DateTime(year, month, day);
                activity.ActivityDate.Add(activityDate);
            }

            am.EditActivty(activity);

            return RedirectToAction("Index");
        }
    }
}