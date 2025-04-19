using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Question;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IBaseRepository<Question> _qRepo;

        public QuestionService(IBaseRepository<Question> qRepo)
        {
            _qRepo = qRepo;
        }

        public async Task<int> AddQuestion(QuestionCreateDto questionCreateDto)
        {
            var question = await _qRepo.AddAsync(questionCreateDto.Mapone<Question>());
            await _qRepo.SaveChangesAsync();

            return question.Id;
        }

        public async Task DeleteQuestion(int id)
        {
            var question = await _qRepo.GetByIdAsync(id);

            if (question is null)
            {
                throw new Exception("Question is not found");
            }

            _qRepo.Delete(question);

            await _qRepo.SaveChangesAsync();
        }

        public async Task<QuestionDto> GetQuestionById(int id)
        {
            var question = await _qRepo.GetByIdAsync(id);

            return question.Mapone<QuestionDto>();
        }

        public async Task UpdateQuestion(QuestionUpdateDto questionUpdateDto)
        {
            _qRepo.update(questionUpdateDto.Mapone<Question>());

            await _qRepo.SaveChangesAsync();
        }
    }
}
