using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMan.Domain.Repository;
using UserMan.Infrastructure.Data.ApplicationDbContext;

namespace UserMan.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) 
        { 
            _context = context;
            User = new UserRepository(_context);
        }

        public IUserRepository User { get; private set; }
        public IUserRepository UserRepository => throw new NotImplementedException();

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        { 
            _context.Dispose();
        }
    }
}
