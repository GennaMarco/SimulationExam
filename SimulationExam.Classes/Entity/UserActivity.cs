using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationExam.Classes.Entity
{
    class UserActivity
    {
        public int Id { get; }
        public User UserId { get; set; }
        public Activity ActivityId { get; set; }
        public bool IsPartecipant { get; set; }
    }
}
