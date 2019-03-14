using PagedList;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        /**
         * Return panel view 
         **/
        public ActionResult Panel()
        {
            return View();
        }

        /**
         * Return Review view 
         **/
        public ActionResult Reviews()
        {
            ViewBag.Reviews = review_bar.getAllReviews();
            return View();
        }

        /**
         * Delete a review 
         **/
        public ActionResult DeleteReview(int id)
        {
            if (review_bar.DeleteReview(id))
            {
                ViewBag.Reviews = review_bar.getAllReviews();
                return View("Reviews");
            }
            else
            {
                ViewBag.Reviews = review_bar.getAllReviews();
                return View("Reviews");
            }
        }

        /**
         * Return the comments view 
         **/
        public ActionResult Comments()
        {
            ViewBag.Comments = comment_event.getAllComments();
            return View();
        }

        public ActionResult Events(int? page)
        {
            eventFilterModel model = new eventFilterModel();

            model.Page = page;
            model.PagedEvents = @event.GetAllEvents().ToPagedList(model.Page ?? 1, 10);
            model.Genres = @event.getAllGenres();

            return View(model);
        }

        /**
         * Delete a comment 
         **/
        public ActionResult DeleteComment(int id)
        {
            if (comment_event.DeleteComment(id))
            {
                ViewBag.Comments = comment_event.getAllComments();
                return View("Comments");
            }
            else
            {
                ViewBag.Reviews = comment_event.getAllComments();
                return View("Comments");
            }
        }

        /**
         * Add an event 
         **/
        public ActionResult AddEvent()
        {
            ViewBag.Genres = @event.getAllGenres().Take(5).ToList();
            ViewBag.Bars = bar.GetAllBarsSLI();

            ViewBag.Update = false;
            return View(); ;
        }

        /**
         * Submit and send the new event to the database 
         **/
        [HttpPost]
        public ActionResult AddEvent(event_object evnt)
        {
            ViewBag.Genres = @event.getAllGenres().ToList();
            ViewBag.Bars = bar.GetAllBarsSLI();
            ViewBag.Update = false;
            if (ModelState.IsValid)
            {
                @event.addEvent(evnt);
                return View("Panel");

            } else
            {
                return View(evnt);
            }
        }

        public ActionResult UpdateEvent(event_object evnt, int id )
        {
            var tempEv = @event.GetEventByID(id);
            evnt = @event.GetEventByID(id);
            ViewBag.ev = tempEv;

            var tempGenres = @event.getAllGenres().Take(5);
            foreach (var item in tempGenres)
            {
                if (Convert.ToInt32(item.Value) == tempEv.GenreID)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.Genres = tempGenres.ToList();

            var tempBars = bar.GetAllBarsSLI();
            foreach (var item in tempBars)
            {
                if (Convert.ToInt32(item.Value) == tempEv.BarID)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.Bars = tempBars;
            ViewBag.Update = true;
            return View("AddEvent", evnt); ;
        }

        /**
         * Update an event 
         **/
        [HttpPost]
        public ActionResult UpdateEvent(event_object evnt)
        {
            ViewBag.Genres = @event.getAllGenres().ToList();
            ViewBag.Bars = bar.GetAllBarsSLI();
            if (ModelState.IsValid)
            {
                @event.updateEvent(evnt);
                return View("Panel");

            }
            else
            {
                return View(evnt);
            }
        }

        /**
         * Delete an event 
         **/
        public ActionResult DeleteEvent(int id)
        {
            @event.deleteEvent(id);
            return RedirectToAction("Events");
        }

    }
}