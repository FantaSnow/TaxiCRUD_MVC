using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiCrudCore.Context;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;

namespace Repositoryes.Roads
{
    public class RoadRepository : Repository<Road, Guid>, IRoadRepository
    {
        public RoadRepository(TaxiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.Set<City>().ToListAsync();
        }

      
    }
}
