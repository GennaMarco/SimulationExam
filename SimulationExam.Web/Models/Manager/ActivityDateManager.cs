using SimulationExam.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Manager
{
    public class ActivityDateManager : DatabaseSqlServer
    {
        public ActivityDate GetActivityDateById(int id)
        {
            return this.GetDatabase().ActivityDate.SingleOrDefault(activityDate => activityDate.Id == id);
        }

        public void EditActivityDate(ActivityDate activityDate)
        {
            // todo: edit activityDate
            // other changed properties
            this.GetDatabase().SaveChanges();
        }
    }
}