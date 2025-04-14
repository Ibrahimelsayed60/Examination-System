using ExaminationSystem.Domain.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Services.contract
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto registerDto);

        Task<AuthResponseDto> Login(LoginRequestDto loginRequestDto);

    }
}
