using Microsoft.EntityFrameworkCore;
using TaxiCrudCore.Context;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Common;


namespace Repositoryes.Users
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(TaxiContext context) : base(context)
        {
        }
    }
}
