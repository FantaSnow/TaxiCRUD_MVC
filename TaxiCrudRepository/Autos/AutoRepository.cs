using Microsoft.EntityFrameworkCore;
using TaxiCrudCore.Context;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;



namespace TaxiCrudCore.Repositoryes.Autos
{
    public class AutoRepository : Repository<Auto, Guid>, IAutoRepository
    {
        public AutoRepository(TaxiContext context) : base(context)
        {
            
        }
    }
}
