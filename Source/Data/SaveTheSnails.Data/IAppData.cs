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

        IDeletableEntityRepository<Problem> Problems { get; }

        int SaveChanges();
    }
}
