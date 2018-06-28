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
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            ActivityManager am = new ActivityManager();
            ICollection<Activity> activities = am.GetActivities();

            return View(activities);
        }

        public ActionResult Create(Activity activity)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            if(activity.Name != null && HttpContext.Request.HttpMethod == "POST")
            {
                ActivityManager am = new ActivityManager();
                activity.EventId = this.EVENT_ID;
                am.InsertActivity(activity);
                return RedirectToAction("Index");
            }
            activity = new Activity();
            
            return View(activity);
        }

        public ActionResult Edit(int id, Activity activity)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            ActivityManager am = new ActivityManager();
            if (activity.Name != null && HttpContext.Request.HttpMethod == "POST")
            {    
                am.EditActivityById(activity.Name, activity.Id);
                ActivityDateManager adv = new ActivityDateManager();
                foreach (ActivityDate activityDate in activity.ActivityDate)
                {
                    if (activityDate.Id > 0)
                    {
                        adv.EditActivityDateById((DateTime)activityDate.Date, activityDate.Id);
                    }
                    else
                    {
                        activityDate.ActivityId = activity.Id;
                        adv.InsertActivityDate(activityDate);
                    }
                }
                id = activity.Id;
            }

            activity = am.GetActivityById(id);

            return View(activity);
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
    }
}