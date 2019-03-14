using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models
{
    public partial class @event
    {
        public static List<event_object> GetAllEvents()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();
                    options.LoadWith<@event>(x => x.genre);
                    options.LoadWith<@event>(x => x.bar);
                    db.LoadOptions = options;
                    return db.events.ToList()
                                        .Select(ev => new event_object
                                        {
                                            ID = ev.id,
                                            Description = ev.description,
                                            Name = ev.name,
                                            Genre = ev.genre.name,
                                            Barname = ev.bar.name,
                                            BarID = ev.bar.id,
                                            DT = ev.date.Value

                                        })
                                        .ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static event_object GetEventByID(int id)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();
                    options.LoadWith<@event>(ev => ev.genre);
                    options.LoadWith<@event>(ev => ev.bar);
                    db.LoadOptions = options;

                    return db.events.Where(@event => @event.id == id).Select(ev => new event_object
                    {
                        ID = ev.id,
                        Name = ev.name,
                        Description = ev.description,
                        Barname = ev.bar.name,
                        BarID = ev.bar.id,
                        DT = ev.date.Value,
                        GenreID = ev.genre.id
                    }).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<event_object> GetFilteredEvents(eventFilterModel m)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    DataLoadOptions options = new DataLoadOptions();
                    options.LoadWith<@event>(x => x.genre);
                    options.LoadWith<@event>(x => x.bar);
                    db.LoadOptions = options;

                    List<@event> listEvents;

                    //listEvents = db.events.Where(x => 
                    //    m.Name != null ? (x.name.Contains(m.Name)) : 1 == 1 &&
                    //    m.Genre_ID != "-1" ? (x.genre.id == Convert.ToInt32(m.Genre_ID)) : 1 == 1 &&
                    //    m.City != null ? (x.bar.city.Contains(m.City)) : 1 == 1 &&
                    //    m.BarName != null ? (x.bar.name.Contains(m.BarName)) : 1 == 1
                    //    ).ToList();

                    

                    if (m.Name != null && m.Genre_ID == "-1" && m.City == null && m.BarName == null)
                    {
                        listEvents = db.events.Where(x => x.name.Contains(m.Name)).ToList();
                    }

                    else if (m.Name != null && m.Genre_ID != "-1" && m.City == null && m.BarName == null)
                    {
                        listEvents = db.events.Where(x => x.name.Contains(m.Name) && x.genre.id == Convert.ToInt32(m.Genre_ID)).ToList();
                    }

                    else if (m.Name != null && m.Genre_ID != "-1" && m.City != null && m.BarName == null)
                    {
                        listEvents = db.events.Where(x => x.name.Contains(m.Name) && x.genre.id == Convert.ToInt32(m.Genre_ID) && x.bar.city.Contains(m.City)).ToList();
                    }
                    else if (m.Name != null && m.Genre_ID != "-1" && m.City != null && m.BarName != null)
                    {
                        listEvents = db.events.Where(x => x.name.Contains(m.Name) && x.genre.id == Convert.ToInt32(m.Genre_ID) && x.bar.city.Contains(m.City) && x.bar.name.Contains(m.BarName)).ToList();
                    }

                    else if (m.Name == null && m.Genre_ID != "-1" && m.City == null && m.BarName == null)
                    {
                        listEvents = db.events.Where(x => x.genre.id == Convert.ToInt32(m.Genre_ID)).ToList();
                    }
                    else if (m.Name == null && m.Genre_ID != "-1" && m.City != null && m.BarName == null)
                    {
                        listEvents = db.events.Where(x => x.genre.id == Convert.ToInt32(m.Genre_ID) && x.bar.city.Contains(m.City)).ToList();
                    }
                    else if (m.Name == null && m.Genre_ID != "-1" && m.City != null && m.BarName != null)
                    {
                        listEvents = db.events.Where(x => x.genre.id == Convert.ToInt32(m.Genre_ID) && x.bar.city.Contains(m.City) && x.bar.name.Contains(m.BarName)).ToList();
                    }
                    else if (m.Name == null && m.Genre_ID == "-1" && m.City != null && m.BarName == null)
                    {
                        listEvents = db.events.Where(x => x.bar.city.Contains(m.City)).ToList();
                    }
                    else if (m.Name == null && m.Genre_ID == "-1" && m.City != null && m.BarName != null)
                    {
                        listEvents = db.events.Where(x => x.bar.city.Contains(m.City) && x.bar.name.Contains(m.BarName)).ToList();
                    }
                    else if (m.Name == null && m.Genre_ID == "-1" && m.City == null && m.BarName != null)
                    {
                        listEvents = db.events.Where(x =>  x.bar.name.Contains(m.BarName)).ToList();
                    }
                    else if (m.Name != null && m.Genre_ID == "-1" && m.City != null && m.BarName == null)
                    {
                        listEvents = db.events.Where(x => x.name.Contains(m.Name) && x.bar.city.Contains(m.City)).ToList();
                    }
                    else if (m.Name != null && m.Genre_ID == "-1" && m.City != null && m.BarName != null)
                    {
                        listEvents = db.events.Where(x => x.name.Contains(m.Name) && x.bar.city.Contains(m.City) && x.bar.name.Contains(m.BarName)).ToList();
                    }
                    else if (m.Name != null && m.Genre_ID == "-1" && m.City == null && m.BarName != null)
                    {
                        listEvents = db.events.Where(x => x.name.Contains(m.Name) && x.bar.name.Contains(m.BarName)).ToList();
                    }
                    else if (m.Name != null && m.Genre_ID != "-1" && m.City == null && m.BarName != null)
                    {
                        listEvents = db.events.Where(x => x.name.Contains(m.Name) && x.genre.id == Convert.ToInt32(m.Genre_ID) && x.bar.name.Contains(m.BarName)).ToList();
                    }
                    else if (m.Name == null && m.Genre_ID != "-1" && m.City == null && m.BarName != null)
                    {
                        listEvents = db.events.Where(x => x.genre.id == Convert.ToInt32(m.Genre_ID) && x.bar.name.Contains(m.BarName)).ToList();
                    }
                    else
                    {
                        listEvents = db.events.ToList();
                    }

                    return listEvents.Select(ev => new event_object
                    {
                        ID = ev.id,
                        Name = ev.name,
                        Description = ev.description,
                        Genre = ev.genre.name,
                        Barname = ev.bar.name,
                        BarID = ev.bar.id,
                        DT = ev.date.Value
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<SelectListItem> getAllGenres()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    List<SelectListItem> genres = db.genres.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.name }).ToList();
                    genres.Add(new SelectListItem { Value = "-1", Text = "All Genres", Selected = true });
                    return genres;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        internal static void addEvent(event_object evnt)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    @event ev = new @event();
                    ev.name = evnt.Name;
                    ev.description = evnt.Description;
                    ev.date = evnt.DT;
                    ev.genre_id = db.genres.SingleOrDefault(g => g.id == Convert.ToInt32(evnt.Genre)).id;
                    ev.bars_id = db.bars.SingleOrDefault(b => b.id == Convert.ToInt32(evnt.Barname)).id;

                    db.events.InsertOnSubmit(ev);
                    db.SubmitChanges();
                }
            }
            catch (Exception e) { }
        }

        internal static void updateEvent(event_object evnt)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    @event ev = db.events.SingleOrDefault(y => y.id == evnt.ID);
                    ev.name = evnt.Name;
                    ev.description = evnt.Description;
                    ev.date = evnt.DT;
                    ev.genre_id = db.genres.SingleOrDefault(g => g.id == Convert.ToInt32(evnt.Genre)).id;
                    ev.bars_id = db.bars.SingleOrDefault(b => b.id == Convert.ToInt32(evnt.Barname)).id;

                    db.SubmitChanges();
                }
            }
            catch (Exception e) { }
        }

        public static void deleteEvent(int id)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    @event ev = db.events.SingleOrDefault(x => x.id == id);

                    db.comment_events.DeleteAllOnSubmit(db.comment_events.Where(x => x.events_id == ev.id).ToList());
                    db.events.DeleteOnSubmit(ev);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex) { }
        }
    }
    public class event_object
    {
        public int? ID { get; set; }
        //public int Average_Rating { get; set; }
        [Required(ErrorMessage = "please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter a Description")]
        public string Description { get; set; }
        public int? GenreID { get; set; }
        [Required(ErrorMessage = "please select a Genre")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "please enter a Barname")]
        public string Barname { get; set; }
        public int? BarID { get; set; }
        [Required(ErrorMessage = "please fill in a DateTime")]
        [DisplayName("Estimate Time: Gebruik volgend formaal: 'yyyy/MM/dd hh:mm:ss'"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime DT { get; set; }
    }
}