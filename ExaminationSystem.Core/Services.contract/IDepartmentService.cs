using ExaminationSystem.Domain.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface IDepartmentService
    {

        Task<IEnumerable<DepartmentDto>> GetAllDepartments();

        Task<DepartmentDto> GetDepartmentsById(int departmentId);

        Task<int> AddDepartment(DepartmentCreateDto departmentCreateDto);

        Task UpdateDepartment(DepartmentUpdateDto departmentUpdateDto);

        Task DeleteDepartment(int departmentId);

    }
}
