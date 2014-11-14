using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SaveTheSnails.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AppUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Problem> reportedProblems;
        private ICollection<Mission> joinedMissions;

        public AppUser()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;
            this.reportedProblems = new HashSet<Problem>();
            this.joinedMissions = new HashSet<Mission>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Mission> JoinedMissions
        {
            get { return joinedMissions; }
            set { joinedMissions = value; }
        }

        public virtual ICollection<Problem> ReportedProblems
        {
            get { return reportedProblems; }
            set { reportedProblems = value; }
        }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
