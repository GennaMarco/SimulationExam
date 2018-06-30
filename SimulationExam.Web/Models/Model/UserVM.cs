using SimulationExam.Web.Models.Entity;
using SimulationExam.Web.Models.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Model
{
    public class UserVM
    {
        public User User {get; set;}
        public ICollection<ActivityDate> ActivityDates {get; set;}


        public UserActivityDate GetUserActivityDateByUserAndActivityDate(ActivityDate activityDate)
        {
            UserActivityDate userActivityDate = this.User.UserActivityDate.SingleOrDefault(
                        userActivityDateDB => 
                        userActivityDateDB.UserId == this.User.Id && 
                        userActivityDateDB.ActivityDateId == activityDate.Id
                    );
            return userActivityDate != null ? userActivityDate : new UserActivityDate();
        }
    }
}