using SimulationExam.Web.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimulationExam.Web.Controllers
{
    public class BaseController : Controller
    {
        protected List<string> allowedRoles;
        protected RoleManager rm;

        public BaseController()
        {
            rm = new RoleManager();
            allowedRoles = new List<string>();
        }

        protected RedirectToRouteResult RouteAccessAllowedRoles(List<string> roles)
        {
            foreach(string role in roles)
            {
                this.allowedRoles.Add(rm.GetRoleByName(role).Name);
            }
            
            if (!this.allowedRoles.Contains(Session["Role"]))  
            {
                TempData["errorMessage"] = "Non hai i permessi per visualizzare questa pagina";
                return RedirectToAction("Index", "Home", null);
            }
            return null;
        }
    }
}