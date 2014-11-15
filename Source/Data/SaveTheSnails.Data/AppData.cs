using SaveTheSnails.Data.Common.Models;
using SaveTheSnails.Data.Common.Repository;
using SaveTheSnails.Data.Models;
using SaveTheSnails.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data
{
    public class AppData : IAppData
    {
        private readonly IAppDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public AppData(IAppDbContext context)
        {
            this.context = context;
        }
       
        public IAppDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IDeletableEntityRepository<AppUser> Users
        {
            get { return this.GetDeletableEntityRepository<AppUser>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }
        
        
        public IRepository<Coordinator> Coordinators
        {
            get { return this.GetRepository<Coordinator>(); }
        }

        public IRepository<ProblemLocation> Locations
        {
            get { return this.GetRepository<ProblemLocation>(); }
        }

        public IDeletableEntityRepository<Mission> Missions
        {
            get { return this.GetDeletableEntityRepository<Mission>(); }
        }

        public IRepository<Picture> Pictures
        {
            get { return this.GetRepository<Picture>(); }
        }

        public IDeletableEntityRepository<Problem> Problems
        {
            get
            {
                return this.GetDeletableEntityRepository<Problem>();

            }
        }

        public IRepository<ProblemStatus> ProblemStatuses
        {
            get { return this.GetRepository<ProblemStatus>(); }
        }

        public IRepository<Region> Regions
        {
            get { return this.GetRepository<Region>(); }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
