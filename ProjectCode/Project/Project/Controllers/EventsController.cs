using PagedList;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index(int? page)
        {
            eventFilterModel model = new eventFilterModel();

            model.Page = page;
            model.PagedEvents = @event.GetAllEvents().OrderBy(x=> x.DT).ToPagedList(model.Page ?? 1, 6);
            model.Genres = @event.getAllGenres();

            return View(model);
        }

        /**
         * Return the Detail view
         * id = the id of the event
         **/
        public ActionResult Detail(int id)
        {

            var test = @event.GetEventByID(id);
            ViewBag.ev = test;
            ViewBag.events = @event.GetAllEvents().Where(x => x.BarID == test.BarID && x.ID != test.ID).OrderBy(x => x.DT).Take(3);
            TempData["Detail_ID"] = id;
            ViewBag.Reviews = comment_event.GetCommentsFromEventID(id).OrderByDescending(x => x.id);
            return View();
        }

        /**
         * return the filtered events
         * m = an object of the filters
         **/
        public ActionResult Filter(eventFilterModel m)
        {
            if (m.Page == null)
            {
                TempData["Name"] = m.Name;
                TempData["Genre"] = m.Genre_ID;
                TempData["City"] = m.City;
                TempData["Barname"] = m.BarName;
            }
            else
            {
                m.Name = (string)TempData["Name"];
                m.Genre_ID = (string)TempData["Genre"];
                m.City = (string)TempData["City"];
                m.BarName = (string)TempData["Barname"];
            }

            TempData.Keep();

            m.PagedEvents = @event.GetFilteredEvents(m).OrderBy(x=> x.DT).ToPagedList(m.Page ?? 1, 6);

            m.Genres = @event.getAllGenres();

            return View("Index", m);
        }

        /**
         * Return the Detail view after adding a new comment to an event
         * com = the new comment
         **/
        [HttpPost]
        public ActionResult Detail(comment_event com)
        {
            int id = (int)TempData["Detail_ID"];

            if (ModelState.IsValid)
            {
                com.events_id = id;
                com.user_id = user.getUser().id;

                if (!comment_event.Add_Comment(com))
                {
                    ModelState.AddModelError("Review", "Er ging iets mis, probeer opnieuw.");
                }
                else
                {
                    return RedirectToAction("Detail", new { id = id });
                }
            }
            
            ViewBag.reviews = bar.GetReviewsFromBarID(id);
            
            ViewBag.ev = @event.GetEventByID(id);

            TempData.Keep();
            return View(com);
        }
    }
}