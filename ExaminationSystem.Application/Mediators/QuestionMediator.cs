using ExaminationSystem.Application.Services;
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
        private readonly IExamQuestionService _examQuestionService;

        public QuestionMediator(IQuestionService questionService, IExamQuestionService examQuestionService)
        {
            _questionService = questionService;
            _examQuestionService = examQuestionService;
        }

        public async Task AddQuestion(QuestionCreateDto questionCreateDto)
        {
            await _questionService.AddQuestion(questionCreateDto);
        }

        public async Task DeleteQuestion(int id)
        {
            var Question = await _questionService.GetQuestionById(id);

            if (Question != null)
            {
                await _questionService.DeleteQuestion(id);

                var examQuestions = await _examQuestionService.Get(eq => eq.QuestionId == id);

                if (examQuestions != null && examQuestions.Count() > 0)
                {
                    await _examQuestionService.DeleteRange(examQuestions);
                }
            }
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
