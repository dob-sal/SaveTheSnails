using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data.Models
{
    public class Coordinator
    {
        private ICollection<Mission> tasks;

        public Coordinator()
        {
            this.tasks = new HashSet<Mission>();  
        }
        
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }

        public virtual AppUser User { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }


        public virtual ICollection<Mission> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }
        
    }
}
