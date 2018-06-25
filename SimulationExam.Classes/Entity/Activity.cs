using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationExam.Classes.Entity
{
    public class Activity
    {
        public int Id { get; }
        public string Name { get; set; }
        public Event EventId { get; set; }
    }
}
