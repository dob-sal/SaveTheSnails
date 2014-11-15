namespace SaveTheSnails.Data.Models
{
    using SaveTheSnails.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Problem : AuditInfo, IDeletableEntity
    {
        private ICollection<Picture> pictures;
          
        public Problem()
        {
            this.pictures = new HashSet<Picture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int? StatusID { get; set; }

        public virtual ProblemStatus Status { get; set; }

        public string ReporterID { get; set; }

        public virtual AppUser Reporter { get; set; }

        public virtual ProblemLocation Location { get; set; }

        public virtual ICollection<Picture> Pictures
        {
            get { return pictures; }
            set { pictures = value; }
        }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn  { get; set; }
        
    }
}
