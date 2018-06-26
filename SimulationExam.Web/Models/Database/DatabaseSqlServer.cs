using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Database
{
    public abstract class DatabaseSqlServer
    {
        private SimulationExamEntitiesPCITS Database;

        protected SimulationExamEntitiesPCITS GetDatabase()
        {
            Database = new SimulationExamEntitiesPCITS();
            return this.Database;
        }
    }
}