using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data.Models
{
    public class Region
    {
        private ICollection<ProblemLocation> locations;
        private ICollection<Coordinator> coordinators;
        public Region()
        {
            this.locations = new HashSet<ProblemLocation>();
            this.coordinators = new HashSet<Coordinator>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProblemLocation> MyProperty
        {
            get { return locations; }
            set { locations = value; }
        }

        public virtual ICollection<Coordinator> Coordinators
        {
            get { return coordinators; }
            set { coordinators = value; }
        }
        
        
    }
}
