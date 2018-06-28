using SimulationExam.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationExam.Web.Models.Manager
{
    public class UserManager : DatabaseSqlServer
    {
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return this.GetDatabase().User.SingleOrDefault(user => user.Email == email && user.Password == password);
        }

        public ICollection<User> GetUserByRole(string role)
        {
            return this.GetDatabase().User.Where(user => user.Role.Name == role).ToList();
        }
    }
}