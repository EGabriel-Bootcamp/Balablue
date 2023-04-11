using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementApp.DataAccess.DataContext;
using UserManagementApp.Domain.Repository;

namespace UserManagementApp.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementDbContext _context;

        public UnitOfWork(UserManagementDbContext context)
        {
            _context = context;
            User = new UserRepository(_context);
        }
       
        public IUserRepository User { get; private set; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
