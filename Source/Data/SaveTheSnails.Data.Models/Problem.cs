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
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string InformantID { get; set; }

        public virtual AppUser Informant { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn  { get; set; }
        
    }
}
