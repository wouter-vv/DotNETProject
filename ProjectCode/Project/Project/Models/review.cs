using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class review_bar
    {
        /**
         * get the review for an event for a user
         * id_bar = the id of the bar
         * id_user = the id of the user
         **/ 
        public static review_bar GetReviewForEventByUser(int id_bar, int id_user)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    return db.review_bars.SingleOrDefault(x => x.bars_id == id_bar && x.user_id == id_user);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /**
         * delete a review
         * id = the id of the review
         **/
        public static bool DeleteReview(int id)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    review_bar review = db.review_bars.SingleOrDefault(x => x.id == id);
                    db.review_bars.DeleteOnSubmit(review);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        /**
         * Return all the reviews
         **/
        internal static dynamic getAllReviews()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();
                    options.LoadWith<review_bar>(x => x.user);
                    options.LoadWith<review_bar>(x => x.bar);
                    db.LoadOptions = options;

                    return db.review_bars.OrderByDescending(x => x.id).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /**
         * Add a review
         * rev = an object of the review
         **/
        public static bool Add_Review(review_bar rev)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    if (db.review_bars.SingleOrDefault(x => x.bars_id == rev.bars_id && x.user_id == rev.user_id) == null)
                    {
                       
                        //review_bar r = new review_bar();
                        //r.id = test;
                        //r.rating = rev.rating;
                        //r.description = rev.description;
                        //r.user_id = rev.user_id;
                        //r.bars_id = rev.bars_id;
                        db.review_bars.InsertOnSubmit(rev);
                        db.SubmitChanges();
                        return true;
                    } else
                    {
                        review_bar review = db.review_bars.SingleOrDefault(y => y.id == rev.id);
                        review.rating = rev.rating;
                        review.description = rev.description;
                        db.SubmitChanges();
                        return true;
                    }
                }
            }
            catch (Exception e1)
            {
                return false;
            }
        }
        public static int getNewIdReview ()
        {
            using (PopItUpDataContext db = new PopItUpDataContext())
            {
                return db.review_bars.OrderByDescending(x => x.id).FirstOrDefault().id += 1;
            }
        }
    }


    public partial class comment_event
    {
        public static List<comment_event> GetCommentsFromEventID(int id)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();
                    options.LoadWith<comment_event>(x => x.user);
                    db.LoadOptions = options;

                    return db.comment_events.Where(x => x.events_id == id).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool Add_Comment(comment_event com)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    db.comment_events.InsertOnSubmit(com);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static bool DeleteComment(int id)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    comment_event comment = db.comment_events.SingleOrDefault(x => x.id == id);
                    db.comment_events.DeleteOnSubmit(comment);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        internal static dynamic getAllComments()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();
                    options.LoadWith<comment_event>(x => x.user);
                    options.LoadWith<comment_event>(x => x.@event);
                    db.LoadOptions = options;

                    return db.comment_events.OrderByDescending(x => x.id).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }


    
    public class review_overview
    {
        public int? id { get; set; }
        public int bar_id { get; set; }
        public int user_id { get; set; }
        public int rating { get; set; }
        public string description { get; set; }
    }
}