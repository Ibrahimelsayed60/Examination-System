using AutoMapper;
using ExaminationSystem.Domain.Dtos.Choice;
using ExaminationSystem.Domain.Dtos.Department;
using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Helpers
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
