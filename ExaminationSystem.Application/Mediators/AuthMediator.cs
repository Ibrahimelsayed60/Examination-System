using ExaminationSystem.Domain.Dtos.Account;
using ExaminationSystem.Domain.Mediators.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Mediators
{
    public class AuthMediator : IAuthMediator
    {
        private readonly IAuthService _authService;

        public AuthMediator(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<AuthResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            return await _authService.Login(loginRequestDto);
        }

        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
            return await _authService.Register(registerDto);
        }
    }
}
