using ExaminationSystem.API.ViewModels;
using ExaminationSystem.API.ViewModels.Department;
using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Department;
using ExaminationSystem.Domain.Mediators.contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentMediator _departmentMediator;

        public DepartmentsController(IDepartmentMediator departmentMediator)
        {
            _departmentMediator = departmentMediator;
        }

        [HttpGet]

        public async Task<ResultViewModel<IEnumerable<DepartmentViewModel>>> GetAllDepartments()
        {
            var departments = (await _departmentMediator.GetAllDepartments()).AsQueryable().Map<DepartmentViewModel>();

            return ResultViewModel<IEnumerable<DepartmentViewModel>>.Success(departments);
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel<DepartmentViewModel>> GetDepartmentById(int id)
        {
            var department  = (await _departmentMediator.GetDepartmentById(id)).Mapone<DepartmentViewModel>();

            return ResultViewModel<DepartmentViewModel>.Success(department);
        }


        [HttpPost]
        public async Task<ResultViewModel<int>> CreateDepartment(DepartmentCreateViewModel departmentCreateViewModel)
        {
            var departmentId = await _departmentMediator.AddDepartment(departmentCreateViewModel.Mapone<DepartmentCreateDto>());

            return ResultViewModel<int>.Success(departmentId);

        }

        [HttpPut]
        public async Task<ResultViewModel<bool>> UpdateDepartment(DepartmentUpdateViewModel departmentUpdateViewModel)
        {
            await _departmentMediator.UpdateDepartment(departmentUpdateViewModel.Mapone<DepartmentUpdateDto>());

            return ResultViewModel<bool>.Success(true);

        }

        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteDepartment(int Id)
        {
            await _departmentMediator.DeleteDepartment(Id);

            return ResultViewModel<bool>.Success(true);
        }
        

    }
}
