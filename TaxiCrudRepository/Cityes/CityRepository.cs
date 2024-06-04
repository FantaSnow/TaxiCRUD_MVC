using Microsoft.EntityFrameworkCore;
using TaxiCrudCore.Context;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;


namespace Repositoryes.Cityes
{
    public class CityRepository : Repository<City, Guid>, ICityRepository
    {
        public CityRepository(TaxiContext context) : base(context)
        {
        }
    }
}
