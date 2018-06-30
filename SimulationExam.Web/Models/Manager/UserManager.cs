using SimulationExam.Web.Models.Database;
using SimulationExam.Web.Models.Entity;
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

        public User GetUserById(int id)
        {
            return this.GetDatabase().User.SingleOrDefault(user => user.Id == id);
        }

        public void InsertUser(User user)
        {
            using (var db = this.GetDatabase())
            {
                db.User.Add(user);
                db.SaveChanges();
            }
        }

        public void EditUser(User user)
        {
            using (var db = this.GetDatabase())
            {
                User userDB = db.User.SingleOrDefault(usr => usr.Id == user.Id);
                userDB.Name = user.Name;
                userDB.Email = user.Email;
                userDB.Password = user.Password;
                UserActivityDateManager uadm = new UserActivityDateManager();
                foreach(UserActivityDate userActivityDate in user.UserActivityDate)
                {
                    if(userActivityDate.Id > 0)
                    {
                        uadm.EditUserActivityDate(userActivityDate);
                    }
                    else
                    {
                        userActivityDate.UserId = user.Id;
                        uadm.InsertUserActivityDate(userActivityDate);
                    }
                }
                db.SaveChanges();
            }
        }

        public void DeleteUserById(int id)
        {
            UserActivityDateManager uadm = new UserActivityDateManager();
            uadm.DeleteUserActivityDatesByUserId(id);
            using (var db = this.GetDatabase())
            {
                User user = db.User.SingleOrDefault(usr => usr.Id == id);
                db.User.Remove(user);
                db.SaveChanges();
            }
        }
    }
}