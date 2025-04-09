using ExaminationSystem.Domain.Dtos.Choice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Mediators.contract
{
    public interface IChoiceMediator
    {
        Task<IEnumerable<ChoiceDto>> GetAllChoices();

        Task<int> AddChoice(ChoiceCreateDto choice);

        Task UpdateChoice(ChoiceDto choice);

        Task DeleteChoice(int choiceId);

    }
}
