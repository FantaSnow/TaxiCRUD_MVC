using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;

namespace Repositoryes.Cityes
{
    public interface ICityRepository : IRepository<City, Guid>
    {

    }
}
