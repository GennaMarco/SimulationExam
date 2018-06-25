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
    }
}