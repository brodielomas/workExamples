using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDevAssignment1.Models;

namespace WebDevAssignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult MVCPageView()
        {
            ViewBag.Title = "MVCPageView";
            ViewBag.Message = "This Page successfully loaded!";

            var db = new ThingsDBEntities();
            var things = (from ti in db.Things
                          orderby ti.item_ID ascending
                          select ti).ToList();


            return View(things);
        }
    }
}