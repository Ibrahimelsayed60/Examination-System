using ExaminationSystem.Domain.Dtos.Exam;
using ExaminationSystem.Domain.Dtos.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface IQuestionService
    {

        Task<QuestionDto> GetQuestionById(int id);

        Task<int> AddQuestion(QuestionCreateDto questionCreateDto);

        Task UpdateQuestion(QuestionUpdateDto questionUpdateDto);

        Task DeleteQuestion(int id);

    }
}
