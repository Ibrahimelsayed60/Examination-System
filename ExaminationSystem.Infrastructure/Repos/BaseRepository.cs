using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Infrastructure.Repos
{
    public class BaseRepository<T>:IBaseRepository<T> where T : BaseModel
    {
    }
}
