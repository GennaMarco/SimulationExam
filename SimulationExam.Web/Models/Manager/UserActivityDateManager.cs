using SimulationExam.Web.Models.Database;
using SimulationExam.Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Manager
{
    public class UserActivityDateManager : DatabaseSqlServer
    {
        public void EditUserActivityDate(UserActivityDate userActivityDate)
        {
            using (var db = this.GetDatabase())
            {
                UserActivityDate userActivityDateDB = db.UserActivityDate.SingleOrDefault(activity => activity.Id == userActivityDate.Id);
                userActivityDateDB.IsPartecipant = userActivityDate.IsPartecipant;
                db.SaveChanges();
            }
        }

        public void DeleteUserActivityDatesByUserId(int id)
        {
            using (var db = this.GetDatabase())
            {
                db.UserActivityDate.RemoveRange(db.UserActivityDate.Where(userActivityDate => userActivityDate.UserId == id));
                db.SaveChanges();
            }
        }
    }
}