using ExaminationSystem.API.ViewModels;
using ExaminationSystem.API.ViewModels.Exam;
using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Exam;
using ExaminationSystem.Domain.Mediators.contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamMediator _examMediator;

        public ExamsController(IExamMediator examMediator)
        {
            _examMediator = examMediator;
        }

        [HttpGet]
        public async Task<ResultViewModel<IEnumerable<ExamViewModel>>> GetAllExams()
        {
            var exams = (await _examMediator.GetAllExams()).AsQueryable().Map<ExamViewModel>();

            return ResultViewModel<IEnumerable<ExamViewModel>>.Success(exams);
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel<ExamViewModel>> GetExamById(int id)
        {
            var exam = (await _examMediator.GetExamById(id)).Mapone<ExamViewModel>();

            return ResultViewModel<ExamViewModel>.Success(exam);
        }

        [Authorize("Instructor")]
        [HttpPost]
        public async Task<ResultViewModel<int>> CreateExam(ExamCreateViewModel examCreateViewModel)
        {
            var examId = await _examMediator.AddExam(examCreateViewModel.Mapone<ExamCreateDto>());
            return ResultViewModel<int>.Success(examId);
        }

        [Authorize("Instructor")]
        [HttpPut]
        public async Task<ResultViewModel<bool>> EditExam(ExamViewModel examViewModel)
        {
            await _examMediator.UpdateExam(examViewModel.Mapone<ExamUpdateDto>());
            return ResultViewModel<bool>.Success(true);
        }

        [Authorize("Instructor")]
        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteExam(int id)
        {
            await _examMediator.DeleteExam(id);
            return ResultViewModel<bool>.Success(true);
        }


        [Authorize("Student")]
        [HttpPost]
        public async Task<ResultViewModel<bool>> TakeExam(ExamStudentCreateViewModel examStudentCreateViewModel)
        {
            var isSuccess = await _examMediator.TakeExam(examStudentCreateViewModel.Mapone<ExamStudentCreateDto>());
            return ResultViewModel<bool>.Success(isSuccess);
        }

        [HttpPost]
        public async Task<ResultViewModel<bool>> SubmitExam(ExamStudentViewModel examStudentViewModel)
        {
            var isSuccess = await _examMediator.SubmitExam(examStudentViewModel.Mapone<ExamStudentDto>());
            return ResultViewModel<bool>.Success(isSuccess);

        }
    }
}
