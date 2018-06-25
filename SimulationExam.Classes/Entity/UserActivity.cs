﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationExam.Classes.Entity
{
    class UserActivity
    {
        public int Id { get; set; }
        public User User_id { get; set; }
        public Activity Activity_id { get; set; }
        public bool IsPartecipant { get; set; }
    }
}
