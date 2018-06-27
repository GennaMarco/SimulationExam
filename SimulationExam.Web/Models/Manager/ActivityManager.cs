using SimulationExam.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Manager
{
    public class ActivityManager : DatabaseSqlServer
    {
        public ICollection<Activity> GetActivities()
        {
            return this.GetDatabase().Activity.ToList();
        }

        public Activity GetActivty(int id)
        {
            return this.GetDatabase().Activity.SingleOrDefault(activity => activity.Id == id);
        }

        public void EditActivty(Activity activity)
        {
            ActivityDateManager adv = new ActivityDateManager();

            foreach (ActivityDate activityDate in activity.ActivityDate)
            {
                adv.EditActivityDate(activityDate);
            }
        }
    }
}