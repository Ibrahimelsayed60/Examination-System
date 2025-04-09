using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Department;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IBaseRepository<Department> _repo;

        public DepartmentService(IBaseRepository<Department> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            return (await _repo.GetAllAsync()).Map<DepartmentDto>().ToList();
        }

        public async Task<DepartmentDto> GetDepartmentsById(int departmentId)
        {
            return (await _repo.GetByIdAsync(departmentId)).Mapone<DepartmentDto>();
        }

        public async Task<int> AddDepartment(DepartmentCreateDto departmentCreateDto)
        {
            var department = await _repo.AddAsync(departmentCreateDto.Mapone<Department>());
            await _repo.SaveChangesAsync();
            return department.Id;

        }

        public async Task UpdateDepartment(DepartmentUpdateDto departmentUpdateDto)
        {
            var department = await _repo.GetByIdAsync(departmentUpdateDto.Id);

            if(department is null)
            {
                throw new Exception("Department is not found");
            }

            department = departmentUpdateDto.Mapone<Department>();

            _repo.update(department);

            await _repo.SaveChangesAsync();

        }

        public async Task DeleteDepartment(int departmentId)
        {
            var department = await _repo.getWithTrackingByIdAsync(departmentId);

            if(department is null)
            {
                throw new Exception("Department not found");
            }

            _repo.Delete(department);

            await _repo.SaveChangesAsync();
        }

        

        

        
    }
}
