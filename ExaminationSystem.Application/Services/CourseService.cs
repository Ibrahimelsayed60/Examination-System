using ExaminationSystem.Domain.Dtos.Course;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<int> AddCourse(CourseCreateDto courseCreateDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(CourseUpdateDto courseUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
