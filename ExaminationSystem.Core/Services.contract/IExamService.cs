using ExaminationSystem.Domain.Dtos.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface IExamService
    {
        Task<IEnumerable<ExamDto>> GetAllExams();

        Task<ExamDto> GetExamById(int id);

        Task<int> CreateExam(ExamCreateDto examCreateDto);
        Task UpdateExam(ExamUpdateDto examUpdateDto);
        Task DeleteExam(int id);

    }
}
