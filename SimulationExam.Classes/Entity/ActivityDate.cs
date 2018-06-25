using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationExam.Classes.Entity
{
    public class ActivityDate
    {
        public int Id { get; }
        public DateTime Date { get; set; }
        public Activity ActivityId { get; set; }
    }
}
