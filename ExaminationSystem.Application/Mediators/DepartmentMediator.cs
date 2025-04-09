using ExaminationSystem.Domain.Dtos.Department;
using ExaminationSystem.Domain.Mediators.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Mediators
{
    public class DepartmentMediator : IDepartmentMediator
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentMediator(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            return await _departmentService.GetAllDepartments();
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            return await _departmentService.GetDepartmentsById(id);
        }

        public async Task<int> AddDepartment(DepartmentCreateDto departmentCreateDto)
        {
            return await _departmentService.AddDepartment(departmentCreateDto);
        }

        public async Task UpdateDepartment(DepartmentUpdateDto departmentUpdateDto)
        {
            await _departmentService.UpdateDepartment(departmentUpdateDto);
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var department = await _departmentService.GetDepartmentsById(departmentId);

            if (department != null)
            {
                await _departmentService.DeleteDepartment(department.Id);
            }
        }
    }
}
