using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models
{
    public class barFilterModel
    {
        public int? Page { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public IPagedList<bar_object> PagedBars { get; set; }
    }
}