using Evolvify.Domain.AppSettings;
using Evolvify.Domain.Entities;
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

namespace Evolvify.Application.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly JwtSettings jwtSettings;

        public TokenService(IConfiguration configuration, IOptions<JwtSettings> options)
        {
            this.configuration = configuration;
            jwtSettings = options.Value;
        }
        
        public async Task<TokenResponse> CreateToken(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),

                new Claim(ClaimTypes.Name,user.UserName),

                new Claim(ClaimTypes.Email,user.Email),

            };

            var userRoles=await userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim( ClaimTypes.Role, role));
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                expires: DateTime.Now.AddDays(double.Parse(jwtSettings.TokenExpiry.ToString())),
                claims: claims,
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new TokenResponse()
            {
                TokenType = "Bearer",
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = token.ValidTo, 
                RefreshToken = Guid.NewGuid().ToString() 
            };
              
        }
    }
}
