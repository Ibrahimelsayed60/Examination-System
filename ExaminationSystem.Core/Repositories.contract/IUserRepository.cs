using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Repositories.contract
{
    public interface IUserRepository<T> where T : AppUser
    {

        IQueryable<T> GetAll();

        T GetById(int id);

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}
