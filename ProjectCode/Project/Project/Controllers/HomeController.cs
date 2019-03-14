using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        /**
         * Home index 
         **/
        public ActionResult Index()
        {
            ViewBag.bars = bar.GetAllBars().OrderBy(a => Guid.NewGuid()).Take(3).ToList();
            ViewBag.events = @event.GetAllEvents().OrderBy(a => Guid.NewGuid()).Take(3);
            return View();
        }
    }
}