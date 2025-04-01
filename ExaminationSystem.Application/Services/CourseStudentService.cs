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
    public class CourseStudentService : ICourseStudentService
    {
        private readonly IBaseRepository<CourseStudent> _repo;

        public CourseStudentService(IBaseRepository<CourseStudent> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CourseStudentDto>> Get(Expression<Func<CourseStudent, bool>> predicate)
        {
            IQueryable<CourseStudent> data = await _repo.GetAllByExpressionAsync(predicate);

            return data.Map<CourseStudentDto>().ToList();
        }

        public async Task<int> Add(CourseStudentDto courseStudentDto)
        {
            var courseStudent = courseStudentDto.Mapone<CourseStudent>();

            await _repo.AddAsync(courseStudent);
            await _repo.SaveChangesAsync();
            return courseStudent.Id;
        }

        public async Task DeleteRange(IEnumerable<CourseStudentDto> courseStudentDtos)
        {
            var data = courseStudentDtos.AsQueryable().Map<CourseStudent>();

            _repo.DeleteRange(data);
            await _repo.SaveChangesAsync();
        }

        
    }
}
