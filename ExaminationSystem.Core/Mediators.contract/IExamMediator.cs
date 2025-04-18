using ExaminationSystem.Domain.Dtos.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Mediators.contract
{
    public interface IExamMediator
    {

        Task<IEnumerable<ExamDto>> GetAllExams();

        Task<ExamDto> GetExamById(int id);

        Task<int> AddExam(ExamCreateDto examCreateDto);

        Task UpdateExam(ExamUpdateDto updateDto);

        Task DeleteExam(int id);


    }
}
