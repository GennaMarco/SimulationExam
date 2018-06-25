using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimulationExam.Classes.Entity;
using SimulationExam.Web.Models;

namespace SimulationExam.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SimulationExamEntities db = new SimulationExamEntities();
            Models.User user2 = db.User.SingleOrDefault(user => user.Id == 1);

            return View(user2);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}