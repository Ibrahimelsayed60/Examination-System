using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Infrastructure.Repos
{
    public class UserRepository<T> : IUserRepository<T> where T : AppUser
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>().Where(x => !x.IsDeleted).AsNoTrackingWithIdentityResolution();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await GetAllAsync();
            return await data.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void SaveChanges()
        {
             _context.SaveChanges();
        }

        
    }
}
