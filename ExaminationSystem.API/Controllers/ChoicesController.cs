using ExaminationSystem.API.ViewModels;
using ExaminationSystem.API.ViewModels.Choices;
using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Choice;
using ExaminationSystem.Domain.Mediators.contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChoicesController : ControllerBase
    {
        private readonly IChoiceMediator _choiceMediator;

        public ChoicesController(IChoiceMediator choiceMediator)
        {
            _choiceMediator = choiceMediator;
        }

        [HttpGet]
        public async Task<ResultViewModel<IEnumerable<ChoiceViewModel>>> GetAllChoices()
        {
            var choices = (await _choiceMediator.GetAllChoices()).AsQueryable().Map<ChoiceViewModel>();

            return ResultViewModel<IEnumerable<ChoiceViewModel>>.Success(choices);

        }

        [HttpPost]
        public async Task<ResultViewModel<int>> CreateChoice(ChoiceCreateViewModel choiceCreateViewModel)
        {
            var choiceId = await _choiceMediator.AddChoice(choiceCreateViewModel.Mapone<ChoiceCreateDto>());

            return ResultViewModel<int>.Success(choiceId);
        }

        [HttpPut]
        public async Task<ResultViewModel<bool>> UpdateChoice(ChoiceCreateViewModel choiceCreateViewModel)
        {
            await _choiceMediator.UpdateChoice(choiceCreateViewModel.Mapone<ChoiceDto>());

            return ResultViewModel<bool>.Success(true);
        }

        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteChoice(int id)
        {
            await _choiceMediator.DeleteChoice(id);

            return ResultViewModel<bool>.Success(true);
        }


    }
}
