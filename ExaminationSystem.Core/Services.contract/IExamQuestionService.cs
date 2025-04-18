using ExaminationSystem.Domain.Dtos.Exam;
using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface IExamQuestionService
    {
        Task<IEnumerable<ExamQuestionDto>> Get(Expression<Func<ExamQuestion, bool>> predicate);

        Task Add(ExamQuestionCreateDto examQuestionCreateDto);

        Task AddRange(int examId, IEnumerable<int> QuestionIDs);
        Task DeleteRange(IEnumerable<ExamQuestionDto> examQuestions);

    }
}
