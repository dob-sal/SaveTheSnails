using SaveTheSnails.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data.Models
{
    public class Mission : AuditInfo, IDeletableEntity
    {
        private ICollection<AppUser> joinedUsers;
        private ICollection<Problem> problems { get; set; }

        public Mission()
        {
            this.joinedUsers = new HashSet<AppUser>();
            this.problems = new HashSet<Problem>();  
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int CoordinatorID { get; set; }

        public virtual Coordinator Coordinator { get; set; }

        public virtual ICollection<Problem> Problems
        {
            get { return problems; }
            set { problems = value; }
        }

        public int RequiredParticipants { get; set; }

        public virtual ICollection<AppUser> JoinedUsers
        {
            get { return joinedUsers; }
            set { joinedUsers = value; }
        }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
