using ExaminationSystem.API.ViewModels;
using ExaminationSystem.API.ViewModels.Question;
using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Question;
using ExaminationSystem.Domain.Mediators.contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionMediator _questionMediator;

        public QuestionsController(IQuestionMediator questionMediator)
        {
            _questionMediator = questionMediator;
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel<QuestionViewModel>> GetQuestionById(int id)
        {
            var question = (await _questionMediator.GetQuestionById(id)).Mapone<QuestionViewModel>();

            return ResultViewModel<QuestionViewModel>.Success(question);
        }

        [HttpPost]
        public async Task<ResultViewModel<bool>> AddQuestion(QuestionCreateViewModel questionCreateViewModel)
        {
            await _questionMediator.AddQuestion(questionCreateViewModel.Mapone<QuestionCreateDto>());

            return ResultViewModel<bool>.Success(true);
        }

        [HttpPut]
        public async Task<ResultViewModel<bool>> UpdateQuestion(QuestionCreateViewModel questionViewModel)
        {
            await _questionMediator.UpdateQuestion(questionViewModel.Mapone<QuestionUpdateDto>());

            return ResultViewModel<bool>.Success(true);
        }

        //[Authorize("Instructor")]
        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteQuestion(int id)
        {
            await _questionMediator.DeleteQuestion(id);

            return ResultViewModel<bool>.Success(true);
        }

    }
}
