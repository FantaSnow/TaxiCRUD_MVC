using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCrudCore.Context;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Autos;
using TaxiCrudCore.Repositoryes.Common;

namespace Repositoryes.Orders
{
    public class OrderRepository : Repository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(TaxiContext context) : base(context)
        {
        }
        public async override Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Set<Order>()
                .Include(o => o.Road)
                .ToListAsync();
        }
    }
}
