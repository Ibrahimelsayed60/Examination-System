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
    }
}
