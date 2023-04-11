using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementApp.DataAccess.DataContext;
using UserManagementApp.Domain.Entities;
using UserManagementApp.Domain.Repository;

namespace UserManagementApp.DataAccess.Implementation
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
       
        public UserRepository(UserManagementDbContext context) : base(context) 
        {
         
        }

    }
}
