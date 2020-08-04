using EventWebMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventWebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Formats { get; set; }
        public IEnumerable<EventItem> EventItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? CategoryFilterApplied { get; set; }
        public int? FormatFilterApplied { get; set; }


    }
}
