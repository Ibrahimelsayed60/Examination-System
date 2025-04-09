using ExaminationSystem.Domain.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Mediators.contract
{
    public interface IDepartmentMediator
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartments();
        
        Task<DepartmentDto> GetDepartmentById(int id);

        Task<int> AddDepartment(DepartmentCreateDto departmentCreateDto);

        Task UpdateDepartment(DepartmentUpdateDto departmentUpdateDto);

        Task DeleteDepartment(int departmentId);


    }
}
