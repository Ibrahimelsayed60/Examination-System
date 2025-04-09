using ExaminationSystem.Domain.Dtos.Choice;
using ExaminationSystem.Domain.Mediators.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Mediators
{
    public class ChoiceMediator:IChoiceMediator
    {
        private readonly IChoiceService _choiceService;

        public ChoiceMediator(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }

        public async Task<int> AddChoice(ChoiceCreateDto choice)
        {
            var choiceId = await _choiceService.AddChoice(choice);

            return choiceId;
        }

        public async Task UpdateChoice(ChoiceDto choice)
        {
            await _choiceService.UpdateChoice(choice);
        }

        public async Task DeleteChoice(int choiceId)
        {
            await _choiceService.DeleteChoice(choiceId);
        }

        public async Task<IEnumerable<ChoiceDto>> GetAllChoices()
        {
            return await _choiceService.GetAllChoices();
        }
    }
}
