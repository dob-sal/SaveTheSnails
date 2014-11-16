using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheSnails.Web.Areas.Coordinators.ViewModels
{
    public class ProblemViewModel : IMapFrom<Problem>
    {
        public int Id { get; set; }

        public string Title { get; set; }


    }
}