using ExaminationSystem.Domain.Dtos.Course;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Mediators.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Mediators
{
    public class CourseMediator:ICourseMediator
    {
        private readonly ICourseService _courseService;
        private readonly ICourseInstructorService _courseInstructorService;
        private readonly ICourseStudentService _courseStudentService;

        public CourseMediator(ICourseService courseService,
            ICourseInstructorService courseInstructorService,
            ICourseStudentService courseStudentService)
        {
            _courseService = courseService;
            _courseInstructorService = courseInstructorService;
            _courseStudentService = courseStudentService;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            return await _courseService.GetAllCoursesAsync();
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesByInstructor(int instructorId)
        {
            IEnumerable<CourseInstructorDto> coursesInstructors = await _courseInstructorService.Get(ci => ci.InstructorId == instructorId);

            List<int> coursesIds = coursesInstructors.Select(ci => ci.CourseId).ToList();

            if(coursesIds.Count == 0)
            {
                throw new KeyNotFoundException("No Courses was Created");
            }

            IEnumerable<CourseDto> courses = await _courseService.GetAllCoursesByExpression(c => coursesIds.Contains(c.Id));

            return courses.ToList();
        }

        public async Task<int> AddCourse(CourseCreateDto course)
        {
            if(!course.InstructorsIDs.Any())
            {
                throw new KeyNotFoundException("Do not have access to Create Course");
            }

            int courseId = await _courseService.AddCourse(course);

            int ciID = await _courseInstructorService.AddCourseInstructorIDs(new CourseInstructorDto
            {
                CourseId = courseId,
                InstructorId = course.InstructorsIDs.FirstOrDefault(),
            });

            return ciID;
        }

        public async Task UpdateCourse(CourseUpdateDto course)
        {
            var data = await _courseInstructorService.Get(c => c.InstructorId == course.InstructorsIDs.FirstOrDefault() && c.CourseId == course.Id);

            if(data is null)
            {
                throw new Exception();
            }

            await _courseService.UpdateCourse(course);

        }

        public async Task DeleteCourse(int id)
        {
            var courses = await _courseService.GetByIdAsync(id);

            if(courses is not null)
            {
                await _courseService.DeleteCourse(id);

                var courseInstructors = await _courseInstructorService.Get(c => c.CourseId == id);

                if (courseInstructors is not null)
                {
                    await _courseInstructorService.DeleteRange(courseInstructors);
                }

                var courseStudents = await _courseStudentService.Get(c => c.CourseId == id);

                if (courseStudents is not null)
                {
                    await _courseStudentService.DeleteRange(courseStudents);
                }

            }
            else
            {
                new Exception("Course Not Found");
            }

        }

        public async Task<int> assignStudentToCourse(CourseStudentDto courseStudentDto)
        {
            return await _courseStudentService.Add(courseStudentDto);
        }

        public async Task<CourseDto> GetById(int id)
        {
            return await _courseService.GetByIdAsync(id);
        }
    }
}
