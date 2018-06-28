using SimulationExam.Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Database
{
    public abstract class DatabaseSqlServer
    {
        private SimulationExamEntitiesMyLaptop Database;

        protected SimulationExamEntitiesMyLaptop GetDatabase()
        {
            Database = new SimulationExamEntitiesMyLaptop();
            return this.Database;
        }
    }
}