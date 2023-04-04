using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Usermanagement_Domain.Interfaces;

namespace UserManagement_DataAccess.InterfacesImplementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UserManagementContext _context;
        private DbSet<T> dbSet;

        public Repository(UserManagementContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> propertyName)
        {
            T entity = await dbSet.FirstOrDefaultAsync(propertyName);
            if(entity != null)
            {
                dbSet.Remove(entity);
                await SaveAsync();
            }
        }

        public Task DeleteRangeAsync(Expression<Func<T, bool>> propertyName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> propertyName)
        {
            return await dbSet.FirstOrDefaultAsync(propertyName);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();

        }
    }
}
