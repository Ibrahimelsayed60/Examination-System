using ExaminationSystem.Domain.Dtos.Exam;
using ExaminationSystem.Domain.Mediators.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Mediators
{
    public class ExamMediator : IExamMediator
    {
        private readonly IExamService _examService;


        public ExamMediator(IExamService examService)
        {
            _examService = examService;
        }

        public async Task<IEnumerable<ExamDto>> GetAllExams()
        {
            return await _examService.GetAllExams();
        }

        public async Task<ExamDto> GetExamById(int id)
        {
            return await _examService.GetExamById(id);
        }

        public async Task<int> AddExam(ExamCreateDto examCreateDto)
        {
            return await _examService.CreateExam(examCreateDto);
        }

        public async Task UpdateExam(ExamUpdateDto updateDto)
        {
            await _examService.UpdateExam(updateDto);
        }

        public async Task DeleteExam(int id)
        {
            await _examService.DeleteExam(id);
        }

        

        
    }
}
