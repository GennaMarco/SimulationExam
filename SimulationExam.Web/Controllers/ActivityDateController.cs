using SimulationExam.Web.Models;
using SimulationExam.Web.Models.Entity;
using SimulationExam.Web.Models.Manager;
using SimulationExam.Web.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimulationExam.Web.Controllers
{
    public class ActivityDateController : BaseController
    {
        public ActionResult Index()
        {
            ActivityDateManager adm = new ActivityDateManager();
            ActivityDateVM activityDateVM = new ActivityDateVM();
            activityDateVM.activityDates = adm.GetActivityDates();
            return View(activityDateVM);
        }

        public ActionResult Delete(int id)
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
            return RedirectToAction("Edit", "Activity", new { id = activity.Id });
        }
    }
}