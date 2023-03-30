using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMan.Domain.Entities;
using UserMan.Domain.Repository;
using UserMan.Infrastructure.Data.ApplicationDbContext;

namespace UserMan.DataAccess.Implementation
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
