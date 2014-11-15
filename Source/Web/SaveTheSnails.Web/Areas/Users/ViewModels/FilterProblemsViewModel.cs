using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheSnails.Web.Areas.Users.ViewModels
{
    public class FilterProblemsViewModel
    {
        public int? category { get; set; }

        public int? region { get; set; }
    }
}