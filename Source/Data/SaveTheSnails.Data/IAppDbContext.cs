using SaveTheSnails.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data
{
    public interface IAppDbContext
    {
        IDbSet<AppUser> Users { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Coordinator> Coordinators { get; set; }

        IDbSet<ProblemLocation> Locations { get; set; }

        IDbSet<Mission> Missions { get; set; }

        IDbSet<Picture> Pictures { get; set; }
        
        IDbSet<Problem> Problems { get; set; }

        IDbSet<ProblemStatus> ProblemStatuses { get; set; }

        IDbSet<Region> Regions { get; set; }
        
        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
