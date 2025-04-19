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
    public class CourseService : ICourseService
    {
        private readonly IBaseRepository<Course> _courseRepo;

        public CourseService(IBaseRepository<Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            return (await _courseRepo.GetAllAsync()).Map<CourseDto>().ToList();
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesByExpression(Expression<Func<Course, bool>> predicate)
        {
            return (await _courseRepo.GetAllByExpressionAsync(predicate)).Map<CourseDto>().ToList();
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            return (await _courseRepo.GetByIdAsync(id)).Mapone<CourseDto>();
        }

        public async Task<int> AddCourse(CourseCreateDto courseCreateDto)
        {
            var course = await _courseRepo.AddAsync(courseCreateDto.Mapone<Course>());

            await _courseRepo.SaveChangesAsync();

            return course.Id;
        }

        public async Task UpdateCourse(CourseUpdateDto courseUpdateDto)
        {
            var course = await _courseRepo.GetByIdAsync(courseUpdateDto.Id);

            if(course is null)
            {
                throw new KeyNotFoundException("Course not found");
            }

            _courseRepo.update(courseUpdateDto.Mapone<Course>());
            await _courseRepo.SaveChangesAsync();
        }

        public async Task DeleteCourse(int id)
        {
            var course = await _courseRepo.getWithTrackingByIdAsync(id);

            if (course is null)
            {
                throw new KeyNotFoundException("Course not found");
            }

            _courseRepo.Delete(course.Mapone<Course>());
            await _courseRepo.SaveChangesAsync();
        }

        
    }
}
