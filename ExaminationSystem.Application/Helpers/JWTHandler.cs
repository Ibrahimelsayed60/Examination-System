using ExaminationSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Helpers
{
    public class JWTHandler
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JWT _jwt;

        public JWTHandler( UserManager<AppUser> userManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
        }

        public async Task<JwtSecurityToken> GetTokenAsync(AppUser user)
        {
            return new JwtSecurityToken
            (
               issuer: _jwt.ValidIssuer,
               audience: _jwt.ValidAudience,
               claims: await GetClaimsAsync(user),
               expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
               signingCredentials: GetSigningCredentials()
            );
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaimsAsync(AppUser user)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            return authClaims;
        }

    }
}
