using SaveTheSnails.Data.Common.Repository;
using SaveTheSnails.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data
{
    public interface IAppData
    {
        IAppDbContext Context { get; }

        IDeletableEntityRepository<AppUser> Users { get; }

        IRepository<Coordinator> Coordinators { get; }

        IRepository<ProblemLocation> Locations { get; }

        IRepository<Picture> Pictures { get; }

        IDeletableEntityRepository<Problem> Problems { get; }

        IRepository<ProblemStatus> ProblemStatuses { get; }

        IRepository<Region> Regions { get; }

        IRepository<Mission> Missions { get; }

        int SaveChanges();
    }
}
