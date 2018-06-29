using SimulationExam.Web.Models;
using SimulationExam.Web.Models.Entity;
using SimulationExam.Web.Models.Manager;
using SimulationExam.Web.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimulationExam.Web.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            UserManager us = new UserManager();
            ICollection<User> partecipants = us.GetUserByRole(this.ROLE_PARTECIPANT);

            return View(partecipants);
        }

        public ActionResult Create(User user)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            if (user.Name != null && HttpContext.Request.HttpMethod == "POST")
            {
                RoleManager rm = new RoleManager();
                user.RoleId = rm.GetRoleByName(this.ROLE_PARTECIPANT).Id;
                UserManager um = new UserManager();
                um.InsertUser(user);
                return RedirectToAction("Index");
            }
            ActivityDateManager adv = new ActivityDateManager();
            UserVM us = new UserVM();
            us.User = new User();
            us.ActivityDates = adv.GetActivityDates();

            return View(us);
        }

        public ActionResult Edit(int id, User user)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            UserManager am = new UserManager();
            if (user.Name != null && HttpContext.Request.HttpMethod == "POST")
            {
                am.EditUser(user);
                id = user.Id;
            }

            user = am.GetUserById(id);

            return View(user);
        }
    }
}