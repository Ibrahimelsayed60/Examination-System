using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Infrastructure.Repos
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return  _context.Set<T>().Where(x => !x.IsDeleted).AsNoTrackingWithIdentityResolution();
        }

        public async Task<IQueryable<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return (await GetAllAsync()).Where(expression);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await GetAllAsync();
            return await data.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> getWithTrackingByIdAsync(int id)
        {
            return await _context.Set<T>().Where(x=> !x.IsDeleted && x.Id == id).AsTracking().FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            update(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }

            _context.Set<T>().UpdateRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
