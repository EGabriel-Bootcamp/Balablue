using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usermanagement_Domain.DTOs;
using Usermanagement_Domain.Interfaces;
using Usermanagement_Domain.Models;

namespace UserManagement_DataAccess.InterfacesImplementation
{
    public class UserRepository : Repository<Users>, IUser
    {
        private readonly UserManagementContext _context;
        private DbSet<Users> dbSet;

        public UserRepository(UserManagementContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Users;
        }
        public async Task<List<Users>> GetFilteredUsersAsync(UserFilter filter)
        {
            var query = dbSet.AsQueryable();
            if (filter.Age > 0)
            {
                query = query.Where(u => filter.Age > 0);
            }
            return await query.ToListAsync();
        }
    }
}
