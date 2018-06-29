using SimulationExam.Web.Models.Entity;
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
    }
}