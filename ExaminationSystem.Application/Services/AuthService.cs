using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Account;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Services.contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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

        public async Task<AuthResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var authDto = new AuthResponseDto();

            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                authDto.Message = "Email or Password is incorrect";
                return authDto;
            }

            var token = await CreateJWTToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            authDto.IsAuthenticated = true;
            authDto.Roles = roles.ToList();
            authDto.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authDto.ExpiresOn = token.ValidTo;

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authDto.RefreshToken = activeRefreshToken.Token;
                authDto.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authDto.RefreshToken = refreshToken.Token;
                authDto.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }


            return authDto;
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

            bool RoleExist = await _roleManager.RoleExistsAsync(registerDto.Type);

            if(!RoleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(registerDto.Type));
            }

            if(registerDto.Type == "Instructor")
            {
                await _userManager.AddToRoleAsync(user, "Instructor");
            }
            else if(registerDto.Type == "Student")
            {
                await _userManager.AddToRoleAsync(user, "Student");
            }

            var token = await CreateJWTToken(user);

            #region Refresh Token Part

            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            #endregion

            return new AuthResponseDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo,
                IsAuthenticated = true,
                Message = "Registration Succedded",
                Roles = new List<string>() { "User"},
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn
            };

        }


        public async Task<JwtSecurityToken> CreateJWTToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var signinCredientials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            double.TryParse(_configuration["JWT:DurationInMinutes"], out double DurationInMintues);

            var expiryTime = DateTime.UtcNow.AddMinutes(DurationInMintues);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: expiryTime,
                signingCredentials: signinCredientials
            );

            return token;

        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new Byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow,
            };

        }


    }
}
