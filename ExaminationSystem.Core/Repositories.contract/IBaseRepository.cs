using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Repositories.contract
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(int id);

        Task<T> getWithTrackingByIdAsync(int id);


        Task<T> AddAsync(T entity);

        void update(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        Task SaveChangesAsync();

    }
}
