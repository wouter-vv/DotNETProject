using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Project.Models;
using PagedList;
using Microsoft.AspNet.Identity;

namespace Project.Controllers
{
    public class BarsController : Controller
    {
        /**
         * Retun the overview of the bars 
         * page = the current page
         **/
        public ActionResult Index(int? page)
        {
            barFilterModel m = new barFilterModel();
            m.Page = page;
            m.PagedBars = bar.GetAllBars().ToPagedList(m.Page ?? 1, 6);
            return View(m);
        }

        /**
         * Detail view of a bar 
         * rev =  the review of the currently logged in user
         * id = the id of the requested bar
         **/
        public ActionResult Detail(review_bar rev, int id)
        {
            ViewBag.bar = bar.GetBarByID(id);
            ViewBag.reviews = bar.GetReviewsFromBarID(id).OrderByDescending(x => x.id); ;
            if (user.getUser() != null)
            {
                rev = null;
                rev = review_bar.GetReviewForEventByUser(id, user.getUser().id);
                if (rev != null)
                {
                    TempData["Review_ID"] = rev.id;
                }
            }

            ViewBag.events = @event.GetAllEvents().Where(x => x.BarID == id).OrderBy(x => x.DT).Take(3);

            TempData["Detail_ID"] = id;

            return View(rev);
        }

        /**
         * Filter for the bars 
         **/
        public ActionResult Filter(barFilterModel m)
        {
            if (m.Page == null)
            {
                TempData["Name"] = m.Name;
                TempData["City"] = m.City;
            }
            else
            {
                m.Name = (string)TempData["Name"];
                m.City = (string)TempData["City"];
            }

            TempData.Keep();

            m.PagedBars = bar.GetFilteredBars(m).ToPagedList(m.Page ?? 1, 6);

            return View("Index", m);
        }

        /**
         * Adds a review to the bar
         * rev = contains the rating and the description
         **/
        [HttpPost]
        public ActionResult Detail(review_bar rev)
        {
            int id = (int)TempData["Detail_ID"];
            rev.id = 0;
            if (TempData["Review_ID"] != null)
            {
                rev.id = (int)TempData["Review_ID"];
            }

            if (ModelState.IsValid)
            {
                if (rev.id == 0)
                {
                    rev.id = review_bar.getNewIdReview();
                }
                rev.user_id = user.getUser().id;
                rev.bars_id = id;

                if (!review_bar.Add_Review(rev))
                {
                    ModelState.AddModelError("Review", "Je kan maximaal 1 review toevoegen aan een bar");
                }
                else
                {
                    return RedirectToAction("Detail", new { id = id });
                }
            }

            ViewBag.bar = bar.GetBarByID(id);
            ViewBag.reviews = bar.GetReviewsFromBarID(id).OrderByDescending(x => x.id);
            ViewBag.events = @event.GetAllEvents().Where(x => x.BarID == id).OrderBy(x => x.DT).Take(3);

            TempData.Keep();
            return View(rev);
        }

       
    }
}