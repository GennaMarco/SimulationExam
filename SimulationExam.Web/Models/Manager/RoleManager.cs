using SimulationExam.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Manager
{
    public class RoleManager : DatabaseSqlServer
    {
        public Role GetRoleByName(string name)
        {
            return this.GetDatabase().Role.SingleOrDefault(role => role.Name == name);
        }
    }
}