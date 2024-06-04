using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;

namespace Repositoryes.Statuses
{
    public interface IStatusRepository : IRepository<Status, Guid>
    {

    }
}
