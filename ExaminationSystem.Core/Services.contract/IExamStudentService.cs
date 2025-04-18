using ExaminationSystem.Domain.Dtos.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface IExamStudentService
    {
        Task<int> AddExamStudent(ExamStudentCreateDto examStudentCreateDto);

        Task<ExamStudentDto> GetExamStudent(ExamStudentDto  examStudentDto);

        Task<ExamStudentDto> GetExamStudentById(int examStudentId);

        Task<ExamStudentDto> SubmitExam(ExamStudentDto examStudentDto);

    }
}
