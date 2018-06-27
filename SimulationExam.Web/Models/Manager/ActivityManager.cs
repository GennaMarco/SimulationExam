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

        public Activity GetActivityById(int id)
        {
            return this.GetDatabase().Activity.SingleOrDefault(activity => activity.Id == id);
        }

        public void InsertActivity(Activity activity)
        {
            using (var db = this.GetDatabase())
            {
                db.Activity.Add(activity); 
                db.SaveChanges();  
            }
        }

        public void EditActivityById(string name, int id)
        {
            using (var db = this.GetDatabase())
            {
                Activity activityDB = db.Activity.SingleOrDefault(activity => activity.Id == id);
                activityDB.Name = name;
                db.SaveChanges();
            }
        }

        public void DeleteActivityById(int id)
        {
            ActivityDateManager adv = new ActivityDateManager();
            adv.DeleteActivityDatesByActivityId(id);
            using (var db = this.GetDatabase())
            {
                Activity activityDB = db.Activity.SingleOrDefault(activity => activity.Id == id);
                db.Activity.Remove(activityDB);
                db.SaveChanges();
            }
        }
    }
}