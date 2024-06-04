using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;

namespace TaxiCrudCore.Repositoryes.Autos
{
    public interface IAutoRepository : IRepository<Auto, Guid>
    {

    }
}
