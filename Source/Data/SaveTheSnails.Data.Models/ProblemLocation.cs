using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data.Models
{
    public class ProblemLocation
    {
        [Key, ForeignKey("Problem")]
        public int ProblemID { get; set; }

        public virtual Problem Problem { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }

    }
}
