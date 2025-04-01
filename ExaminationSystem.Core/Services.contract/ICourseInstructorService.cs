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
    public interface ICourseInstructorService
    {
        Task<IEnumerable<CourseInstructorDto>> Get(Expression<Func<CourseInstructor, bool>> predicate);

        Task DeleteRange(IEnumerable<CourseInstructorDto> courseInstructorDtos);
    }
}
