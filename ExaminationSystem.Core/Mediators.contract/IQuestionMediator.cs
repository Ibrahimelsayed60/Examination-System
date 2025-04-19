using ExaminationSystem.Domain.Dtos.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Mediators.contract
{
    public interface IQuestionMediator
    {
        Task<QuestionDto> GetQuestionById(int id);

        Task AddQuestion(QuestionCreateDto questionCreateDto);

        Task DeleteQuestion(int id);

        Task UpdateQuestion(QuestionUpdateDto questionUpdateDto);

    }
}
