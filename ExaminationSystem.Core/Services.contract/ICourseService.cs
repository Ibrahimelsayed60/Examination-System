using ExaminationSystem.Domain.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface ICourseService
    {

        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();

        Task<CourseDto> GetByIdAsync(int id);

        Task<int> AddCourse(CourseCreateDto courseCreateDto);

        void UpdateCourse(CourseUpdateDto courseUpdateDto);

        void DeleteCourse(int id);



    }
}
