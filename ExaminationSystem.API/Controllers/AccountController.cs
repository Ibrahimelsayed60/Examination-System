using ExaminationSystem.API.ViewModels;
using ExaminationSystem.Domain.Dtos.Account;
using ExaminationSystem.Domain.Mediators.contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthMediator _authMediator;

        public AccountController(IAuthMediator authMediator)
        {
            _authMediator = authMediator;
        }

        [HttpPost]
        public async Task<ResultViewModel<AuthResponseDto>> Register(RegisterDto registerDto)
        {
            var authResponse = await _authMediator.Register(registerDto);

            if (!authResponse.IsAuthenticated)
            {
                return new ResultViewModel<AuthResponseDto>
                {
                    IsSuccess = false,
                    Result = authResponse
                };
            }


            return new ResultViewModel<AuthResponseDto>
            {
                IsSuccess = true,
                Result = authResponse
            };
        }


        [HttpPost]
        public async Task<ResultViewModel<AuthResponseDto>> Login(LoginRequestDto loginDto)
        {
            var authResponse = await _authMediator.Login(loginDto);

            if (!authResponse.IsAuthenticated)
            {
                return new ResultViewModel<AuthResponseDto>
                {
                    IsSuccess = false,
                    Result = authResponse
                };
            }

            //if (!string.IsNullOrEmpty(authResponse.RefreshToken))
            //{

            //}

            return new ResultViewModel<AuthResponseDto>
            {
                IsSuccess = true,
                Result = authResponse
            };

        }

    }
}
