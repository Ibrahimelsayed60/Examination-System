using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Choice;
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
    public class ChoiceService : IChoiceService
    {
        private readonly IBaseRepository<Choice> _repo;

        public ChoiceService(IBaseRepository<Choice> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ChoiceDto>> GetAllChoices()
        {
            return (await _repo.GetAllAsync()).Map<ChoiceDto>().ToList();
        }

        public async Task<int> AddChoice(ChoiceCreateDto choiceCreateDto)
        {
            var choice = await _repo.AddAsync(choiceCreateDto.Mapone<Choice>());

            await _repo.SaveChangesAsync();

            return choice.Id;
        }

        public async Task AddChoiceRange(int questionId, IEnumerable<ChoiceDto> choices)
        {

            foreach (var choice in choices)
            {
                await _repo.AddAsync(new Choice
                {
                    Text = choice.Text,
                    QuestionId = questionId,
                    IsCorrect = choice.IsCorrect,
                });
            }

            await _repo.SaveChangesAsync();

        }

        public async Task UpdateChoice(ChoiceDto choiceDto)
        {
            var choice = await _repo.GetByIdAsync(choiceDto.Id);

            _repo.update(choiceDto.Mapone<Choice>());

            await _repo.SaveChangesAsync();
        }

        public async Task DeleteChoice(int choiceId)
        {
            var choice = await _repo.getWithTrackingByIdAsync(choiceId);

            _repo.Delete(choice);

            await _repo.SaveChangesAsync();
        }

        public async Task DeleteChoiceRange(IEnumerable<ChoiceDto> choices)
        {
            _repo.DeleteRange(choices.AsQueryable().Map<Choice>());
            await _repo.SaveChangesAsync();
        }
    }
}
