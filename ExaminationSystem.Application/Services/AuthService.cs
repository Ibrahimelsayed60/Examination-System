using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Account;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Services.contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public Task<AuthResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
            if ( await _userManager.FindByEmailAsync(registerDto.Email) is not null)
            {
                return new AuthResponseDto()
                {
                    Message = "Email is already registered!"
                };
            }

            if( await _userManager.FindByNameAsync(registerDto.UserName) is not null)
            {
                return new AuthResponseDto()
                {
                    Message = "Username is already registered!"
                };
            }

            var user = registerDto.Mapone<AppUser>();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description} ,";
                }

                return new AuthResponseDto()
                {
                    Message = errors
                };
            }

            if(registerDto.Type == "Instructor")
            {
                await _userManager.AddToRoleAsync(user, "Instructor");
            }
            else if(registerDto.Type == "Student")
            {
                await _userManager.AddToRoleAsync(user, "Student");
            }

            var token = CreateJWTToken(user);

            #region Refresh Token Part

            #endregion

            return new AuthResponseDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo,
                IsAuthenticated = true,
                Message = "Registration Succedded",
                Roles = new List<string>() { "User"},

            };

        }


        public JwtSecurityToken CreateJWTToken(AppUser user)
        {

        }
    }
}
