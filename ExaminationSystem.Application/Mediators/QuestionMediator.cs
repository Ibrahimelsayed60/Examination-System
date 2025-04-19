using ExaminationSystem.Domain.Dtos.Question;
using ExaminationSystem.Domain.Mediators.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Mediators
{
    public class QuestionMediator : IQuestionMediator
    {
        private readonly IQuestionService _questionService;

        public QuestionMediator(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task AddQuestion(QuestionCreateDto questionCreateDto)
        {
            await _questionService.AddQuestion(questionCreateDto);
        }

        public async Task DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestion(id);
        }

        public async Task<QuestionDto> GetQuestionById(int id)
        {
            return await _questionService.GetQuestionById(id);
        }

        public async Task UpdateQuestion(QuestionUpdateDto questionUpdateDto)
        {
            await _questionService.UpdateQuestion(questionUpdateDto);
        }
    }
}
