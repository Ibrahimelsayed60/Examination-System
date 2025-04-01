using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Course;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Services
{
    public class CourseInstructorService : ICourseInstructorService
    {
        private readonly IBaseRepository<CourseInstructor> _repo;

        public CourseInstructorService(IBaseRepository<CourseInstructor> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CourseInstructorDto>> Get(Expression<Func<CourseInstructor, bool>> predicate)
        {
            IQueryable<CourseInstructor> data = await _repo.GetAllByExpressionAsync(predicate);

            return data.Map<CourseInstructorDto>();
        }


        public async Task DeleteRange(IEnumerable<CourseInstructorDto> courseInstructorDtos)
        {
            var courseInstructors = courseInstructorDtos.AsQueryable().Map<CourseInstructor>();
            
            _repo.DeleteRange(courseInstructors);

            await _repo.SaveChangesAsync();
        }

        
    }
}
