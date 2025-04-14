using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class SecuredController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult secured()
        {
            return Ok("Hello from secured Endpoint");
        }
    }
}
