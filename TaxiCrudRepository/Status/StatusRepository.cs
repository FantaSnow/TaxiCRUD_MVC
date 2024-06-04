using Microsoft.EntityFrameworkCore;
using TaxiCrudCore.Context;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;


namespace Repositoryes.Statuses
{
    public class StatusRepository : Repository<Status, Guid>, IStatusRepository
    {
        public StatusRepository(TaxiContext context) : base(context)
        {
        }
    }
}
