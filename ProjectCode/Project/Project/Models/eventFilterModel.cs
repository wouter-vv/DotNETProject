using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models
{
    public class eventFilterModel
    {
        public int? Page { get; set; }
        public string Name { get; set; }
        public string Genre_ID { get; set; }
        public string City { get; set; }
        public string BarName { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public IPagedList<event_object> PagedEvents { get; set; }
    }
}