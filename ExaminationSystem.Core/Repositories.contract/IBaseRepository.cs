using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Repositories.contract
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IQueryable<T>> GetAllAsync();

        Task<T> GetById(int id);

        Task<T> getWithTrackingById(int id);

        Task<T> Add(T entity);

        void update(T entity);

        void Delete(T entity);

        Task SaveChanges();

    }
}
