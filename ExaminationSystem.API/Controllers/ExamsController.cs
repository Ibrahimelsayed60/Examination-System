using ExaminationSystem.Domain.Mediators.contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamMediator _examMediator;

        public ExamsController(IExamMediator examMediator)
        {
            _examMediator = examMediator;
        }

    }
}
