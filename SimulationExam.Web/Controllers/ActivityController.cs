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
        private int EVENT_ID = 1;

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

        public ActionResult Create()
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            Activity activity = new Activity();

            return View(activity);
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
            Activity activity = am.GetActivityById(id);

            return View(activity);
        }

        public ActionResult Save(Activity activity)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            ActivityManager am = new ActivityManager();
            activity.EventId = this.EVENT_ID;
            am.InsertActivity(activity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(IList<string> listDates, IList<string> listDateIds)
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
            am.EditActivityById(activityName, activityId); 
            ActivityDateManager adv = new ActivityDateManager();
            for (int i = 0; i<listDateIds.Count; i++)
            {
                string[] date = listDates[i].Split('/');
                int year = Int32.Parse(date[2]);
                int month = Int32.Parse(date[1]);
                int day = Int32.Parse(date[0]);
                adv.EditActivityDateById(new DateTime(year, month, day), Int32.Parse(listDateIds[i]));
            }
       
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            ActivityManager am = new ActivityManager();
            am.DeleteActivityById(id);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteActivityDate(int id)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            ActivityDateManager adm = new ActivityDateManager();
            ActivityDate activityDate = adm.GetActivityDateById(id);
            adm.DeleteActivityDateById(id);

            int activityId = (int)activityDate.ActivityId;

            ActivityManager am = new ActivityManager();
            Activity activity = am.GetActivityById(activityId);
            return RedirectToAction("Edit", new { id = activity.Id });
        }
    }
}