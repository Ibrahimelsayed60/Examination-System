using AutoMapper;
using ExaminationSystem.API.ViewModels.Department;
using ExaminationSystem.Domain.Dtos.Choice;
using ExaminationSystem.Domain.Dtos.Department;
using ExaminationSystem.Domain.Entities;

namespace ExaminationSystem.API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
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

            #endregion
        }
    }
}
