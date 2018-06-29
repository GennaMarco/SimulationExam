using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimulationExam.Web.Models.Database;
using SimulationExam.Web.Models.Entity;

namespace SimulationExam.Web.Models.Manager
{
    public class ActivityDateManager : DatabaseSqlServer
    {
        public ICollection<ActivityDate> GetActivityDates()
        {
            return this.GetDatabase().ActivityDate.ToList();
        }

        public ActivityDate GetActivityDateById(int id)
        {
            return this.GetDatabase().ActivityDate.SingleOrDefault(activityDate => activityDate.Id == id);
        }

        public void InsertActivityDate(ActivityDate activityDate)
        {
            using (var db = this.GetDatabase())
            {
                db.ActivityDate.Add(activityDate);
                db.SaveChanges();
            }
        }

        public void EditActivityDateById(DateTime date, int id)
        {
            using (var db = this.GetDatabase())
            {
                ActivityDate activityDateDB = db.ActivityDate.SingleOrDefault(activityDate => activityDate.Id == id);   
                activityDateDB.Date = date;
                db.SaveChanges();
            }
        }

        public void DeleteActivityDatesByActivityId(int id)
        {
            string sql = "SELECT * FROM ActivityDate WHERE ActivityId = " + id;
            using (var db = this.GetDatabase())
            {
                List<ActivityDate> activityDates = db.ActivityDate.SqlQuery(sql).ToList();
                foreach(ActivityDate activityDate in activityDates)
                {
                    db.ActivityDate.Remove(activityDate);
                }
                db.SaveChanges();
            }
        }

        public void DeleteActivityDateById(int id)
        {
            using (var db = this.GetDatabase())
            {
                ActivityDate activityDateDB = db.ActivityDate.SingleOrDefault(activityDate => activityDate.Id == id);
                db.ActivityDate.Remove(activityDateDB);
                db.SaveChanges();
            }
        }
    }
}