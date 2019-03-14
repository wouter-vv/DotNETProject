using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models
{
    public partial class bar
    {
        /**
         * Return all bars 
         **/
        public static List<bar_object> GetAllBars()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();
                    return db.bars.ToList()
                                        .Select(x => new bar_object
                                        {
                                            ID = x.id,
                                            Average_Rating = x.Avg_Rating,
                                            City = x.city,
                                            Description = x.description,
                                            Name = x.name
                                        })
                                        .OrderByDescending(x => x.Average_Rating)
                                        .ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /**
         * Retrn all the bars as a selectlist for a dropdown 
         **/
        public static List<SelectListItem> GetAllBarsSLI()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    List<SelectListItem> bars = db.bars.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.name }).ToList();
                    return bars;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /**
         * return all the reviews that belong to a bar
         * id = the id of the bar
         **/
        public static List<review_bar> GetReviewsFromBarID(int id)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();
                    options.LoadWith<review_bar>(x => x.user);
                    db.LoadOptions = options;

                    return db.review_bars.Where(x => x.bars_id == id).OrderByDescending(x => x.rating).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /**
         * Get a bar from the id
         * id = the id of the bar
         **/
        public static bar_object GetBarByID(int id)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();

                    return db.bars.Where(bar => bar.id == id).Select(x => new bar_object
                    {
                        ID = x.id,
                        Name = x.name,
                        Description = x.description,
                        City = x.city,
                        Number = (int)x.number,
                        Street = x.street,
                        Average_Rating = x.Avg_Rating
                        
                    }).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /**
         * Return the filtered bars
         * m = the filters for the bars
         **/
        public static List<bar_object> GetFilteredBars(barFilterModel m)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    List<bar> barList;

                    if (m.Name == null && m.City == null)
                    {
                        barList = db.bars.ToList();
                    }

                    else if (m.Name != null && m.City == null)
                    {
                        barList = db.bars.Where(x => x.name.Contains(m.Name)).ToList();
                    }

                    else if (m.Name == null && m.City != null)
                    {
                        barList = db.bars.Where(x =>  x.city.Contains(m.City)).ToList();
                    }

                    else
                    {
                        barList = db.bars.Where(x => x.name.Contains(m.Name) && x.city.Contains(m.City)).ToList();
                    }

                    return barList.Select(x => new bar_object
                    {
                        ID = x.id,
                        Description = x.description,
                        Name = x.name,
                        Average_Rating = x.Avg_Rating,
                        City = x.city
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /**
         * Method to calculate the average rating of a bar 
         **/
        public int Avg_Rating
        {
            get
            {
                try
                {
                    using (PopItUpDataContext db = new PopItUpDataContext())
                    {
                        return Convert.ToInt32(db.review_bars.Where(x => x.bars_id == this.id).Average(y => y.rating));
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        /**
         * Get all the bars, used for the API 
         **/
        public static IEnumerable<bar_object> GetAllBarsAPI()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    /*DataLoadOptions options = new DataLoadOptions();
                    options.LoadWith<bar>(x => x.genre);
                    options.LoadWith<bar>(x => x.type);
                    db.LoadOptions = options;*/

                    return db.bars.Select(x => new bar_object
                    {
                        ID = x.id,
                        Name = x.name,
                        Description = x.description,
                        City = x.city,
                        Number = (int)x.number,
                        Street = x.street,
                        Average_Rating = x.Avg_Rating
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        /**
         * Get a single bar, used for the API 
         **/
        public static IEnumerable<bar_object> GetBarByIDAPI(int id)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    return db.bars.Where(bar => bar.id == id).Select(x => new bar_object
                    {
                        ID = x.id,
                        Name = x.name,
                        Description = x.description,
                        City = x.city,
                        Number = (int)x.number,
                        Street = x.street,
                        Average_Rating = x.Avg_Rating
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }


    /**
     * an object to store a bar
     **/
    public class bar_object
    {
        public int ID { get; set; }
        //public int Average_Rating { get; set; }
        [Required(ErrorMessage = "please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please select a city")]
        public string City { get; set; }
        [Required(ErrorMessage = "please select a city")]
        public string Street { get; set; }
        [Required(ErrorMessage = "please select a city")]
        public int Number { get; set; }
        [Required(ErrorMessage = "please enter a description")]
        public string Description { get; set; }
        public int Average_Rating { get; set; }
    }


    /**
     * an object to store a review
     **/
    public class review_object
    {
        public int ID { get; set; }
        //public int Average_Rating { get; set; }
        [Required(ErrorMessage = "please enter a rating")]
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}