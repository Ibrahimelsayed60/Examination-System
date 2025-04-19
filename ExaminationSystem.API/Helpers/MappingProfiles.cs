using AutoMapper;
using ExaminationSystem.API.ViewModels.Course;
using ExaminationSystem.API.ViewModels.Department;
using ExaminationSystem.API.ViewModels.Exam;
using ExaminationSystem.Domain.Dtos.Account;
using ExaminationSystem.Domain.Dtos.Choice;
using ExaminationSystem.Domain.Dtos.Course;
using ExaminationSystem.Domain.Dtos.Department;
using ExaminationSystem.Domain.Dtos.Exam;
using ExaminationSystem.Domain.Entities;

namespace ExaminationSystem.API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {

            #region Account
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            #endregion

            #region Choice
            CreateMap<Choice, ChoiceDto>().ReverseMap();

            CreateMap<ChoiceCreateDto, Choice>().ReverseMap();

            #endregion

            #region Department

            CreateMap<DepartmentViewModel, DepartmentDto>().ReverseMap();

            CreateMap<DepartmentCreateViewModel, DepartmentCreateDto>().ReverseMap();
            CreateMap<DepartmentUpdateViewModel, DepartmentUpdateDto>().ReverseMap();

            CreateMap<DepartmentDto, Department>().ReverseMap();

            CreateMap<DepartmentCreateDto, Department>()
                .ForMember(dst => dst.Courses, opt => opt.Ignore())
                .ForMember(dst => dst.Instructors, opt => opt.Ignore())
                .ForMember(dst => dst.Students, opt => opt.Ignore());

            CreateMap<DepartmentUpdateDto, Department>()
                .ForMember(dst => dst.Courses, opt => opt.Ignore())
                .ForMember(dst => dst.Instructors, opt => opt.Ignore())
                .ForMember(dst => dst.Students, opt => opt.Ignore());

            #endregion

            #region Course
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
            CreateMap<CourseInstructor, CourseInstructorDto>().ReverseMap();
            CreateMap<CourseDto, CourseViewModel>().ReverseMap();
            CreateMap<CourseCreateDto, CourseCreateViewModel>() .ReverseMap();
            CreateMap<CourseUpdateDto , CourseUpdateViewModel>() .ReverseMap();
            CreateMap<CourseStudentDto, CourseStudentViewModel>() .ReverseMap();
            CreateMap<CourseStudent, CourseStudentDto>() .ReverseMap();

            #endregion

            #region Exam

            CreateMap<Exam, ExamDto>().ReverseMap();

            CreateMap<ExamCreateDto, Exam>().ReverseMap();

            CreateMap<ExamUpdateDto, Exam>().ReverseMap();

            CreateMap<ExamViewModel, ExamDto>().ReverseMap();

            CreateMap<ExamCreateViewModel, ExamCreateDto>().ReverseMap();

            CreateMap<ExamViewModel, ExamUpdateDto>().ReverseMap();

            CreateMap<ExamStudentCreateViewModel, ExamStudentCreateDto>().ReverseMap();

            CreateMap<ExamStudentViewModel, ExamStudentDto>().ReverseMap();

            #endregion
        }
    }
}
