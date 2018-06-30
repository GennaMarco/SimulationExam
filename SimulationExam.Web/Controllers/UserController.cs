using SimulationExam.Web.Models;
using SimulationExam.Web.Models.Entity;
using SimulationExam.Web.Models.Manager;
using SimulationExam.Web.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            this.allowedRoles.Add(this.ROLE_MANAGER);
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
                try
                {
                    um.InsertUser(user);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException)
                {
                    TempData["errorMessage"] = "L'email inserita non è valida perchè già esistente";
                }
            }
            ActivityDateManager adv = new ActivityDateManager();
            UserVM userVM = new UserVM();
            userVM.User = new User();
            userVM.ActivityDates = adv.GetActivityDates();

            return View(userVM);
        }

        public ActionResult Edit(int id, User user)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            UserManager um = new UserManager();
            if (user.Name != null && HttpContext.Request.HttpMethod == "POST")
            {
                try
                {
                    um.EditUser(user);
                    id = user.Id;
                }
                catch (DbUpdateException)
                {
                    TempData["errorMessage"] = "L'email inserita non è valida perchè già esistente";
                }
            }
            UserVM userVM = new UserVM();
            ActivityDateManager adm = new ActivityDateManager();

            userVM.User = um.GetUserById(id);
            userVM.ActivityDates = adm.GetActivityDates();

            return View(userVM);
        }

        public ActionResult Delete(int id)
        {
            this.allowedRoles.Add(this.ROLE_MANAGER);
            RedirectToRouteResult redirectToHome = this.RouteAccessAllowedRoles();
            if (redirectToHome != null)
            {
                return redirectToHome;
            }

            UserManager am = new UserManager();
            am.DeleteUserById(id);

            return RedirectToAction("Index");
        }
    }
}