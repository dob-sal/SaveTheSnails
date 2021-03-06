﻿using Microsoft.AspNet.Identity.EntityFramework;
using SaveTheSnails.Data.Common.CodeFirstConventions;
using SaveTheSnails.Data.Common.Models;
using SaveTheSnails.Data.Migrations;
using SaveTheSnails.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>, IAppDbContext
    {
        public AppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public AppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public virtual IDbSet<Problem> Problems { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Coordinator> Coordinators { get; set; }
        
        public virtual IDbSet<ProblemLocation> Locations { get; set; }

        public virtual IDbSet<Mission> Missions { get; set; }
       
        public virtual IDbSet<Picture> Pictures { get; set; }
         
        public virtual IDbSet<ProblemStatus> ProblemStatuses { get; set; }
        
        public virtual IDbSet<Region> Regions { get; set; }
       


        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

       //Added

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new IsUnicodeAttributeConvention());

             modelBuilder.Entity<ProblemLocation>().Property(l => l.Latitude).HasPrecision(24, 20);
             modelBuilder.Entity<ProblemLocation>().Property(l => l.Longitude).HasPrecision(24, 20);
           
            base.OnModelCreating(modelBuilder); // Without this call EntityFramework won't be able to configure the identity model
        }
    }
}
