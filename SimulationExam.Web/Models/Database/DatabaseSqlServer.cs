using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Database
{
    public abstract class DatabaseSqlServer
    {
        private SimulationExamEntities Database;

        protected SimulationExamEntities GetDatabase()
        {
            Database = new SimulationExamEntities();
            return this.Database;
        }
    }
}