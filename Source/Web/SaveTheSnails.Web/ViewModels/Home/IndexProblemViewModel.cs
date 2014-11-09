using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheSnails.Web.ViewModels.Home
{
    public class IndexProblemViewModel : IMapFrom<Problem>
    {
        public string Title { get; set; }
    }
}