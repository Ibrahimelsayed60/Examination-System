using ExaminationSystem.Domain.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Mediators.contract
{
    public interface ICourseMediator
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();

        Task<CourseDto> GetById(int id);

        Task<IEnumerable<CourseDto>> GetCoursesByInstructor(int instructorId);

        Task<int> AddCourse(CourseCreateDto course);

        Task UpdateCourse(CourseUpdateDto course);

        Task DeleteCourse(int id);

        Task<int> assignStudentToCourse(CourseStudentDto courseStudentDto);

    }
}
