using ExaminationSystem.Domain.Dtos.Choice;
using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface IChoiceService
    {
        Task<IEnumerable<ChoiceDto>> GetAllChoices();

        Task<int> AddChoice(ChoiceCreateDto choiceCreateDto);

        Task AddChoiceRange(int questionId, IEnumerable<ChoiceDto> choices);

        Task UpdateChoice(ChoiceDto choiceDto);

        Task DeleteChoice(int choiceId);

        Task DeleteChoiceRange(IEnumerable<ChoiceDto> choices);

    }
}
