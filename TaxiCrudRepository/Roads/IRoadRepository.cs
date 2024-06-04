using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;

namespace Repositoryes.Roads
{
    public interface IRoadRepository : IRepository<Road, Guid>
    {
        Task<IEnumerable<City>> GetAllCities();
    }
}
