using ExaminationSystem.API.ViewModels;
using ExaminationSystem.API.ViewModels.Course;
using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Course;
using ExaminationSystem.Domain.Mediators.contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseMediator _courseMediator;

        public CoursesController(ICourseMediator courseMediator)
        {
            _courseMediator = courseMediator;
        }

        [HttpGet]
        public async Task<ResultViewModel<IEnumerable<CourseViewModel>>> GetAllCourses()
        {
            var courses = (await _courseMediator.GetAllCourses()).AsQueryable().Map<CourseViewModel>();

            return ResultViewModel<IEnumerable<CourseViewModel>>.Success(courses);
        }


        [HttpGet("{id}")]
        public async Task<ResultViewModel<CourseViewModel>> GetCourseById(int id)
        {
            var course =(await _courseMediator.GetById(id)).Mapone<CourseViewModel>();

            return ResultViewModel<CourseViewModel>.Success(course);
        }

        [Authorize("Instructor")]
        [HttpPost]
        public async Task<ResultViewModel<int>> CreateCourse(CourseCreateViewModel courseCreateViewModel)
        {
            var courseId = await _courseMediator.AddCourse(courseCreateViewModel.Mapone<CourseCreateDto>());

            return ResultViewModel<int>.Success(courseId);
        }

        [Authorize("Instructor")]
        [HttpPut]
        public async Task<ResultViewModel<bool>> UpdateCourse(CourseUpdateViewModel courseUpdateViewModel)
        {
            await _courseMediator.UpdateCourse(courseUpdateViewModel.Mapone<CourseUpdateDto>());

            return ResultViewModel<bool>.Success(true);
        }

        [Authorize("Instructor")]
        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteCourse(int id)
        {
            await _courseMediator.DeleteCourse(id);
            return ResultViewModel<bool>.Success(true);
        }


        [Authorize("Student")]
        [HttpPost]
        public async Task<ResultViewModel<int>> EnrollCourse(CourseStudentViewModel courseStudentViewModel)
        {
            int id = await _courseMediator.assignStudentToCourse(courseStudentViewModel.Mapone<CourseStudentDto>());

            return ResultViewModel<int>.Success(id);

        }



    }
}
