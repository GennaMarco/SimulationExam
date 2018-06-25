using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationExam.Classes.Entity
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User UserManager { get; set; }
    }
}
