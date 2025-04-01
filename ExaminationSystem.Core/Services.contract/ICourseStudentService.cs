using ExaminationSystem.Domain.Dtos.Course;
using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface ICourseStudentService
    {
        Task<IEnumerable<CourseStudentDto>> Get(Expression<Func<CourseStudent, bool>> predicate);

        Task<int> Add(CourseStudentDto courseStudentDto);

        Task DeleteRange(IEnumerable<CourseStudentDto> courseStudentDtos);

    }
}
