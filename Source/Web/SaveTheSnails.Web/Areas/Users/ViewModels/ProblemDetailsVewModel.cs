using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheSnails.Web.Areas.Users.ViewModels
{
    public class ProblemDetailsVewModel : IMapFrom<Problem>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? StatusID { get; set; }

        public ProblemStatus Status { get; set; }

        public string ReporterID { get; set; }

        public virtual AppUser Reporter { get; set; }

        public virtual ProblemLocation Location { get; set; }

        public ICollection<Picture> Pictures { get; set; }
  
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public int? MissionID { get; set; }

        public virtual Mission Mission { get; set; }

  

    }
}