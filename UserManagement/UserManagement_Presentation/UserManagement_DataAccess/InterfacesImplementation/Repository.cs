using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Usermanagement_Domain.Interfaces;
using Usermanagement_Domain.Models;

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

        public async Task<List<T>> DeleteMultipleAsync(List<T> entitiesToDelete)
        {
            var entities = await dbSet.Where(e=>entitiesToDelete.Contains(e)).ToListAsync();
            dbSet.RemoveRange(entities);
            await SaveAsync();
            return entities;
        }
        public async Task DeleteAllAsync()
        {
            var all = await GetAllAsync();
            dbSet.RemoveRange(all);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        //public async Task<List<T>> GetMultipleAsync(List<T> list)
        //{
        //    return await dbSet.Where(e=>list.Contains(e)).ToListAsync();
        //}
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

        public async Task<List<T>> GetMutipleAsync(IEnumerable<T> list)
        {
            return await dbSet.Where(e => list.Contains(e)).ToListAsync();
        }

        
    }
}
